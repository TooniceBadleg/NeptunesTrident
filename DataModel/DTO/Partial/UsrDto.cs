using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public partial class UsrDto
    {



        //dodatak
        public int? IdShip { get; set; }
        //dodatak
        //public int? IdCompany { get; set; }
        public CompanyDto Company { get; set; }



    }
}
