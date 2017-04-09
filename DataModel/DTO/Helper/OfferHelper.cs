using EF;
using System.Linq;
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017.04.04 - 22:49:35
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
    /// Assembler for <see cref="Offer"/> and <see cref="OfferDto"/>.
    /// </summary>
    public static partial class OfferHelper
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="OfferDto"/> converted from <see cref="Offer"/>.</param>
        static partial void OnDTO(this Offer entity, OfferDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Offer"/> converted from <see cref="OfferDto"/>.</param>
        static partial void OnEntity(this OfferDto dto, Offer entity);

        /// <summary>
        /// Converts this instance of <see cref="OfferDto"/> to an instance of <see cref="Offer"/>.
        /// </summary>
        /// <param name="dto"><see cref="OfferDto"/> to convert.</param>
        public static Offer ToEntity(this OfferDto dto)
        {
            if (dto == null) return null;

            var entity = new Offer();

            entity.Id = dto.Id;
            entity.IdCompany = dto.IdCompany;
            entity.IdShip = dto.IdShip;
            entity.Timestamp = dto.Timestamp;
            entity.IdReturnPort = dto.IdReturnPort;
            entity.ReturnTime = dto.ReturnTime;
            entity.HandoverTimeInPort = dto.HandoverTimeInPort;
            entity.HandoverLocationOutPort = dto.HandoverLocationOutPort;
            entity.HandoverTimeOutPort = dto.HandoverTimeOutPort;
            entity.ValidTime = dto.ValidTime;
            entity.IdPaymentMethod = dto.IdPaymentMethod;
            entity.IdUser = dto.IdUser;
            entity.Note = dto.Note;
            entity.Active = dto.Active;
            entity.IdCreated = dto.IdCreated;
            entity.DateCreated = dto.DateCreated;
            entity.IdUpdated = dto.IdUpdated;
            entity.DateUpdated = dto.DateUpdated;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Offer"/> to an instance of <see cref="OfferDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Offer"/> to convert.</param>
        public static OfferDto ToDTO(this Offer entity)
        {
            if (entity == null) return null;

            var dto = new OfferDto();

            dto.Id = entity.Id;
            dto.IdCompany = entity.IdCompany;
            dto.IdShip = entity.IdShip;
            dto.Timestamp = entity.Timestamp;
            dto.IdReturnPort = entity.IdReturnPort;
            dto.ReturnTime = entity.ReturnTime;
            dto.HandoverTimeInPort = entity.HandoverTimeInPort;
            dto.HandoverLocationOutPort = entity.HandoverLocationOutPort;
            dto.HandoverTimeOutPort = entity.HandoverTimeOutPort;
            dto.ValidTime = entity.ValidTime;
            dto.IdPaymentMethod = entity.IdPaymentMethod;
            dto.IdUser = entity.IdUser;
            dto.Note = entity.Note;
            dto.Active = entity.Active;
            dto.IdCreated = entity.IdCreated;
            dto.DateCreated = entity.DateCreated;
            dto.IdUpdated = entity.IdUpdated;
            dto.DateUpdated = entity.DateUpdated;

            if (entity.Ship != null)
                dto.ShipName = entity.Ship.ShipName;

            //try
            //{
            //    if (entity.OfferItem != null)   // ako nema Include("OfferItem") onda ovaj property skoro da uopce ne postoji pa ce ovo pucati bez try catch
            //        dto.OfferItemDTO = OfferItemHelper.ToDTOs(entity.OfferItem);
            //} catch { }

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="OfferDto"/> to an instance of <see cref="Offer"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Offer> ToEntities(this IEnumerable<OfferDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Offer"/> to an instance of <see cref="OfferDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<OfferDto> ToDTOs(this IEnumerable<Offer> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}