using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using DTO;

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
        public UsrDto UserData()
        {
            UsrDto obj = new UsrDto();
            obj.IdShip = 2;
            obj.Username = "misko";            

            return obj;
        }

    }
}
