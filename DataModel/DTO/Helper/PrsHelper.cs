using EF;
using System.Linq;
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017.04.03 - 18:58:56
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Collections.Generic;
using System;

namespace DTO
{

    /// <summary>
    /// Assembler for <see cref="Prs"/> and <see cref="PrsDto"/>.
    /// </summary>
    public static partial class PrsHelper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PrsDto"/> converted from <see cref="Prs"/>.</param>
        static partial void OnDTO(this Prs entity, PrsDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Prs"/> converted from <see cref="PrsDto"/>.</param>
        static partial void OnEntity(this PrsDto dto, Prs entity);

        /// <summary>
        /// Converts this instance of <see cref="PrsDto"/> to an instance of <see cref="Prs"/>.
        /// </summary>
        /// <param name="dto"><see cref="PrsDto"/> to convert.</param>
        public static Prs ToEntity(this PrsDto dto)
        {
            if (dto == null) return null;

            var entity = new Prs();

            entity.Id = dto.Id;
            entity.Firstname = dto.Firstname;
            entity.Lastname = dto.Lastname;
            entity.Active = dto.Active;
            entity.Email = dto.Email;
            entity.EmailVerified = dto.EmailVerified;
            entity.IdCompany = dto.IdCompany;
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.Phone = dto.Phone;
            entity.Mobile = dto.Mobile;
            entity.IdCreated = dto.IdCreated;
            entity.DateCreated = dto.DateCreated;
            entity.IdUpdated = dto.IdUpdated;
            entity.DateUpdated = dto.DateUpdated;
            entity.IdShip = dto.IdShip;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Prs"/> to an instance of <see cref="PrsDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Prs"/> to convert.</param>
        public static PrsDto ToDTO(this Prs entity)
        {
            if (entity == null) return null;

            var dto = new PrsDto();

            dto.Id = entity.Id;
            dto.Firstname = entity.Firstname;
            dto.Lastname = entity.Lastname;
            dto.Active = entity.Active;
            dto.Email = entity.Email;
            dto.EmailVerified = entity.EmailVerified;
            dto.IdCompany = entity.IdCompany;
            dto.Address = entity.Address;
            dto.City = entity.City;
            dto.Country = entity.Country;
            dto.Phone = entity.Phone;
            dto.Mobile = entity.Mobile;
            dto.IdCreated = entity.IdCreated;
            dto.DateCreated = entity.DateCreated;
            dto.IdUpdated = entity.IdUpdated;
            dto.DateUpdated = entity.DateUpdated;
            dto.IdShip = entity.IdShip;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="PrsDto"/> to an instance of <see cref="Prs"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Prs> ToEntities(this IEnumerable<PrsDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Prs"/> to an instance of <see cref="PrsDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PrsDto> ToDTOs(this IEnumerable<Prs> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}