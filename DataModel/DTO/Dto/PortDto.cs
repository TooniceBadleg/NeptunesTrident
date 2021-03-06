//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017.04.03 - 18:58:45
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Collections.Generic;
using System;

namespace DTO
{
    public partial class PortDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int? IdRegion { get; set; }

        public int? IdPortType { get; set; }

        public bool? FishUnload { get; set; }

        public string Country { get; set; }

        public int IdCreated { get; set; }

        public DateTime DateCreated { get; set; }

        public int? IdUpdated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public PortDto()
        {
        }

        public PortDto(int id, string code, string name, string text, string description, bool active, int? idRegion, int? idPortType, bool? fishUnload, string country, int idCreated, DateTime dateCreated, int? idUpdated, DateTime? dateUpdated)
        {
			this.Id = id;
			this.Code = code;
			this.Name = name;
			this.Text = text;
			this.Description = description;
			this.Active = active;
			this.IdRegion = idRegion;
			this.IdPortType = idPortType;
			this.FishUnload = fishUnload;
			this.Country = country;
			this.IdCreated = idCreated;
			this.DateCreated = dateCreated;
			this.IdUpdated = idUpdated;
			this.DateUpdated = dateUpdated;
        }
    }
}