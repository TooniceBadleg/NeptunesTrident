//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017.04.03 - 16:35:16
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Collections.Generic;
using System;

namespace DTO
{
    public partial class AuditLoginDto
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public string ApplicationCode { get; set; }

        public string IpAddress { get; set; }

        public string Hostname { get; set; }

        public DateTime LogIn { get; set; }

        public DateTime? LogOut { get; set; }

        public bool? Repair { get; set; }

        public DateTime? SystemDatetime { get; set; }
    }
}