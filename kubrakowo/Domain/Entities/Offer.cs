using Kubrakowo.WebApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain.Entities
{
    public class Offer
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public GenderEnum Gender { get; set; }
        public CategoryEnum Category { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
