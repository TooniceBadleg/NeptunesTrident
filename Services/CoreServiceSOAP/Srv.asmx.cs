using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using DTO;
using EF;
using CoreServiceSOAP.Code;
using System.Configuration;
using System.Net.Mail;

namespace CoreServiceSOAP
{
    /// <summary>
    /// Summary description for Srv
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Srv : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string CurrentTime()
        {
            return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        [WebMethod]
        public string ServiceVersion()
        {
            return "08.04.2017. 08:24:00";
        }


        [WebMethod]
        public List<DirUsrTypeDto> DbAccessTest()
        {
            List<DirUsrTypeDto> data;// = new List<DirUsrTypeDto>();

            using (TridentEntities ctx = new TridentEntities())
            {
                var q = from ut in ctx.DirUsrType
                        where ut.Active == true
                        orderby ut.Text
                        select ut;
                data = DirUsrTypeHelper.ToDTOs(q.ToList());
            }

            return data;
        }









        #region PHASE one, GetUserType, RegisterUserDTO

        [WebMethod]
        public List<DirUsrTypeDto> GetUserType()
        {
            List<DirUsrTypeDto> data;// = new List<DirUsrTypeDto>();


            using (TridentEntities ctx = new TridentEntities())
            {
                var q = from ut in ctx.DirUsrType
                        where ut.Active == true
                        orderby ut.Text
                        select ut;
                data = DirUsrTypeHelper.ToDTOs(q.ToList());
            }

            return data;
        }

        // ovdje se nalazi primjer kako se hvataju ef greske
        [WebMethod]
        public ReturnData RegisterUserDTO(UsrDto argUser, PrsDto argPerson, CompanyDto argCompany, ShipDto argShip)
        {
            ReturnData dd = new ReturnData();
            //ako je sve ok vraca se id od usr i vraca se data objekt, has error je false, error je prazan
            // Ako nije ok onda je haserror true.

            int dbResponse = -1;
            using (TridentEntities ctx = new TridentEntities())
            {
                bool usernameExists = (from usr in ctx.Usr where usr.Username == argUser.Username select usr).Any();
                if (usernameExists == true)
                {
                    dd.Id = 0;
                    dd.Data = null;
                    dd.HasError = true;
                    dd.ErrorMsg = "Username already exists.";
                    return dd;
                }

                argUser.ConfirmationCode = (new Random()).Next(10000000, 99999999).ToString(); // creates a 8 digit random no.
                /////argUser.IdCreated = 1;
                argUser.DateCreated = DateTime.Now;
                Usr usrData = UsrHelper.ToEntity(argUser);

                argPerson.EmailVerified = false;
                //argPerson.IdCreated = 1;
                argPerson.DateCreated = DateTime.Now;
                Prs prsData = PrsHelper.ToEntity(argPerson);

                //AuditUser  tablica   // biljeska da je napravljena registracija za id usera......
                AuditUser usrLog = new AuditUser();
                usrLog.Usr = usrData;           // post usrdata jos nije spremljeno u bazu onda ne mogu ovdje direktno stavljati id, usrlog bi trebao biti automatski ubacen u context preko ove veze.
                usrLog.ApplicationCode = "DEMO01";
                usrLog.Code = "LOG01";
                usrLog.Action = "Registracija korisnika. Podaci spremljeni u bazu.";
                //usrLog.Description = 
                usrLog.SystemDatetime = DateTime.Now;

                usrData.Prs = prsData;
                ctx.Usr.Add(usrData);

                try
                {
                    dbResponse = ctx.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    // ovo je nacin 
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string msg1 = "Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            //   eve.ValidationErrors je kljuc price

                            //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            //ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                //compani i ship ni ne treba spremati pri registraciji
                //if (argCompany != null)
                //{
                //}


                //if (dbResponse == 3)
                if (dbResponse > 0)
                {

                    //posalji mail sa code-om:
                    SendConfirmatioCodeEmail(prsData.Email, usrData.ConfirmationCode);

                    dd.Id = usrData.Id;
                    dd.Data = null;  // usrData;   ////??????
                    dd.HasError = false;
                    dd.ErrorMsg = "";
                }
            }
            return dd;
        }


        [WebMethod]
        public ReturnData LoginUserDTO(UsrDto argUser)
        {
            // u cijeloj login prici fali provjera valjanosti accounta. da li je account istekao. ta provjera se radi samo kod normalnog logina !!!!
            ReturnData rDdata = new ReturnData();
            Usr currentUser = null;
            bool successfullLogin = false;
            AuditLogin loginItem = null;

            int dbResponse = -1;
            using (TridentEntities ctx = new TridentEntities())
            {
                var q = from user in ctx.Usr.Include("Prs").Include("Prs.Company") where user.Username == argUser.Username select user;
                var data = q.ToList();

                if (data.Count == 1)
                {
                    currentUser = data[0];
                    UsrDto USRTEST = UsrHelper.ToDTO(currentUser);   // cisto za pokus da vidim da li ce ici konverzija sa podobjektom Prs U USER OBJEKTU


                    if (currentUser.ConfirmationCode != null && currentUser.ConfirmationCode != "")
                    {
                        //radi se o prvom loginu i za password se ocekuje ConfirmationCode
                        // izbrisi aktivacijski kod, zabiljezi da je mail potvrdjen, napravi log u AuditLogin o prvom loginu
                        if (currentUser.ConfirmationCode == argUser.ConfirmationCode)
                        {
                            currentUser.ConfirmationCode = null;
                            currentUser.Prs.EmailVerified = true;
                            //currentUser.EmailVerified = true;

                            loginItem = new AuditLogin();
                            loginItem.IdUser = currentUser.Id;
                            loginItem.ApplicationCode = "DEMO01";    //prvi demo, ribarska aplikacija. desktop
                            loginItem.IpAddress = "";   // ip nema smisla jer je to i tako samo lokalni ip koji mi nista ne govori.
                            loginItem.Hostname = "";    // nema smisla iz istog razloga kao gore
                            loginItem.LogIn = DateTime.Now;
                            //trebalo bi dodati polje: log.Description = "Inicijalni login je napravljen sa conf code = " + argUserLogin.ConfirmationCode;    // !!!!!!!!!!!!!    !!!!!!!!!!!!!!
                            loginItem.SystemDatetime = DateTime.Now;
                            ctx.AuditLogin.Add(loginItem);

                            //AuditUser    // biljeska da je aktivacijski kod prosao i napravljen je inicijalni login
                            AuditUser usrLog = new AuditUser();
                            usrLog.IdUser = currentUser.Id;
                            usrLog.ApplicationCode = "DEMO01";
                            usrLog.Code = "LOG02";
                            usrLog.Action = "Inicijalni login uspjesan.";
                            //usrLog.Description = 
                            usrLog.SystemDatetime = DateTime.Now;
                            ctx.AuditUser.Add(usrLog);

                            successfullLogin = true;
                        }
                        else
                        {
                            successfullLogin = false;
                            rDdata.ErrorMsg = "Aktivacijski kod nije se poklopio.";
                            //AuditUser    // biljeziti neuspjesan inicijalni login
                            AuditUser usrLog = new AuditUser();
                            usrLog.IdUser = currentUser.Id;
                            usrLog.ApplicationCode = "DEMO01";
                            usrLog.Code = "LOG03";
                            usrLog.Action = "Inicijalni login nije uspio.";
                            usrLog.Description = "Aktivacijski kod nije se poklopio.";
                            usrLog.SystemDatetime = DateTime.Now;
                            ctx.AuditUser.Add(usrLog);
                        }
                    }
                    else
                    {
                        //radi se klasicni login,  username i password u hashu
                        if (currentUser.Password == argUser.Password)
                        {
                            loginItem = new AuditLogin();
                            loginItem.IdUser = currentUser.Id;
                            loginItem.ApplicationCode = "DEMO01";
                            loginItem.IpAddress = "";   // ip nema smisla jer je to i tako samo lokalni ip koji mi nista ne govori.
                            loginItem.Hostname = "";    // nema smisla iz istog razloga kao gore
                            loginItem.LogIn = DateTime.Now;
                            //trebalo bi dodati polje:  log.Description = "Korisnik {currentUser.Username} je napravio login.";    // !!!!!!!!!!!!!    !!!!!!!!!!!!!!
                            loginItem.SystemDatetime = DateTime.Now;
                            ctx.AuditLogin.Add(loginItem);

                            //AuditUser   nema nikakve biljeske u AuditUser jer je samo obican login


                            successfullLogin = true;
                        }
                        else
                        {
                            successfullLogin = false;
                            rDdata.ErrorMsg = "Lozinka se ne poklapa.";
                            //AuditUser    // biljeziti neuspjesan redovni login, razlog zasto nije login uspio, istekao, krivi password......
                            AuditUser usrLog = new AuditUser();
                            usrLog.IdUser = currentUser.Id;
                            usrLog.ApplicationCode = "DEMO01";
                            usrLog.Code = "LOG04";
                            usrLog.Action = "Redovni login nije uspio.";
                            usrLog.Description = "Lozinka se ne poklapa.";
                            usrLog.SystemDatetime = DateTime.Now;
                            ctx.AuditUser.Add(usrLog);
                        }
                    }
                }
                else
                {
                    successfullLogin = false;  // zato jer je izvuceno vise od jednog usera ili je izvucen ni jedan user za zadani username!!
                    rDdata.ErrorMsg = "U bazi podataka je nadjeno " + data.Count.ToString() + " zapisa za username " + argUser.Username + ".";
                    //AuditUser    // izvuceno je vise od jednog usera ili ni jedan user
                    AuditUser usrLog = new AuditUser();
                    usrLog.IdUser = currentUser.Id;
                    usrLog.ApplicationCode = "DEMO01";
                    usrLog.Code = "LOG05";
                    usrLog.Action = "Nije pronadjen jedinstveni korisnik.";
                    usrLog.Description = "U bazi podataka je nadjeno " + data.Count.ToString() + " zapisa za username " + argUser.Username + ".";
                    usrLog.SystemDatetime = DateTime.Now;
                    ctx.AuditUser.Add(usrLog);
                }

                ctx.SaveChanges();
            }

            if (successfullLogin == true)
            {
                if (loginItem != null)
                    rDdata.Id = loginItem.Id;
                else rDdata.Id = 0;
                UsrDto usr = UsrHelper.ToDTO(currentUser);
                //usr.IdCompany = currentUser.Prs.IdCompany;
                usr.Company = CompanyHelper.ToDTO(currentUser.Prs.Company);
                usr.IdShip = currentUser.Prs.IdShip;
                rDdata.Data = usr;
                rDdata.HasError = false;
                rDdata.ErrorMsg = "";
            }
            else
            {
                rDdata.Id = 0;
                rDdata.Data = null;    // da li ce ovo proci van, posto je ovo entity objekt
                rDdata.HasError = true;
                //rDdata.ErrorMsg =    //   poruka je vec napunjena
            }

            return rDdata;
        }

        [WebMethod]
        public bool LogoutUserDTO(UsrDto argUser, int argIdAuditLogin)
        {
            //////int dbResponse = -1;
            using (TridentEntities ctx = new TridentEntities())
            {
                var q = from l in ctx.AuditLogin where l.Id == argIdAuditLogin select l;
                AuditLogin logItemFromDb = q.FirstOrDefault();
                if (logItemFromDb != null)
                {
                    logItemFromDb.LogOut = DateTime.Now;
                    ctx.SaveChanges();
                    return true;  // uspjesni logout
                }
                else
                    return false;
            }
        }





        /// <summary>
        /// Slanje maila.
        /// </summary>
        /// <param name="argSubject"></param>
        /// <param name="argMessage"></param>
        public static void SendConfirmatioCodeEmail(string argDestinationEmail, string argMessage)
        {
            try
            {
                string subject = "fishfinder activation code";
                string from = ConfigurationManager.AppSettings["ErrorMailFrom"].ToString();
                string to = argDestinationEmail;
                string subjectPrefix = ConfigurationManager.AppSettings["ErrorMailSubjectPrefix"].ToString();
                string outgoingServer = ConfigurationManager.AppSettings["ErrorMailSmtpServerIp"].ToString();
                string smtpLogin = ConfigurationManager.AppSettings["ErrorMailSmtpServerLogin"].ToString();
                string smtpPassword = ConfigurationManager.AppSettings["ErrorMailSmtpServerPassword"].ToString();

                if (to != "")
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(from);
                    message.To.Add(new MailAddress(to));
                    message.Subject = subjectPrefix + subject;
                    message.Body = argMessage;
                    message.IsBodyHtml = true;

                    SmtpClient emailClient = new SmtpClient(outgoingServer);
                    emailClient.Credentials = new System.Net.NetworkCredential(smtpLogin, smtpPassword);

                    emailClient.Send(message);  // u ovom slucaju kad se salje sa web servisa mora biti SEND a ne SendAsync. SendAsync nece raditi.                    
                }

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }


        #endregion



    }
}
