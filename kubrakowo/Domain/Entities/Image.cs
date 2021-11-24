using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain.Entities
{
    public class Image
    {
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public long OfferId { get; set; }
    }
}
