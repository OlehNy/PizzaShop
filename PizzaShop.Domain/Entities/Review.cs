﻿using System;

namespace PizzaShop.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Comment { get; set; }
    }
}
