﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.Core.Entitites
{
    public class Slider : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonLink { get; set; }
        public string? ImageURL { get; set; }
    }
}
