﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class CarModel
    {
        public ulong Id { get; set; }
        public uint CarBrandId { get; set; }
        public string Name { get; set; }
    }
}
