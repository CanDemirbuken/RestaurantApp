﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.Core.Entitites
{
    public class About : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
