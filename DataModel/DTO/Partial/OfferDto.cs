using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class OfferDto
    {

        public string ShipName { get; set; }

        public List<OfferItemDto> OfferItemDTO { get; set; }

    }
}
