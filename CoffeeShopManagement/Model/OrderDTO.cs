﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public UserDetailDTO User { get; set; }
        public DateTime Time { get; set; }
        public float Total { get; set; }
    }
}
