//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017.04.15 - 23:41:29
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Collections.Generic;
using System;

namespace DTO
{
    public partial class BiddingDto
    {
        public int Id { get; set; }

        public DateTime? Timestamp { get; set; }

        public int IdOffer { get; set; }

        public int? IdParentBidding { get; set; }

        public double? UnitPrice { get; set; }

        public double? Quantity { get; set; }

        public bool? IsFinal { get; set; }

        public int? SmjerBiddingReply { get; set; }

        public int? IdBuyerComany { get; set; }

        public int? IdUser { get; set; }

        public int IdCreated { get; set; }

        public DateTime DateCreated { get; set; }

        public int? IdUpdated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public List<int> Bidding1_Id { get; set; }

        public int Bidding2_Id { get; set; }

        public BiddingDto()
        {
        }

        public BiddingDto(int id, DateTime? timestamp, int idOffer, int? idParentBidding, double? unitPrice, double? quantity, bool? isFinal, int? smjerBiddingReply, int? idBuyerComany, int? idUser, int idCreated, DateTime dateCreated, int? idUpdated, DateTime? dateUpdated, List<int> bidding1_Id, int bidding2_Id)
        {
			this.Id = id;
			this.Timestamp = timestamp;
			this.IdOffer = idOffer;
			this.IdParentBidding = idParentBidding;
			this.UnitPrice = unitPrice;
			this.Quantity = quantity;
			this.IsFinal = isFinal;
			this.SmjerBiddingReply = smjerBiddingReply;
			this.IdBuyerComany = idBuyerComany;
			this.IdUser = idUser;
			this.IdCreated = idCreated;
			this.DateCreated = dateCreated;
			this.IdUpdated = idUpdated;
			this.DateUpdated = dateUpdated;
			this.Bidding1_Id = bidding1_Id;
			this.Bidding2_Id = bidding2_Id;
        }
    }
}