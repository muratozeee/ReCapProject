﻿
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity //Other class can reach this class..! others layers can reach here...!
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public long ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
