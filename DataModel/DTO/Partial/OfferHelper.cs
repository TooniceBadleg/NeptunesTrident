using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EF;



namespace DTO
{
    public static partial class OfferHelper
    {


        public static OfferDto ToDtoCustom(this Offer argEntity)
        {
            OfferDto objekt = OfferHelper.ToDTO(argEntity);
            
            if (argEntity.Ship != null)
                objekt.ShipName = argEntity.Ship.ShipName;

            //try
            //{
            if (argEntity.OfferItem != null)   // ako nema Include("OfferItem") onda ovaj property skoro da uopce ne postoji pa ce ovo pucati bez try catch
                objekt.OfferItemDTO = OfferItemHelper.ToDTOs(argEntity.OfferItem);
            //} catch { }

            return objekt;   
        }

        public static List<OfferDto> ToDTOsCustom(this IEnumerable<Offer> entities)
        {
            if (entities == null) return null;
            return entities.Select(e => e.ToDtoCustom()).ToList();
        }
    }
}
