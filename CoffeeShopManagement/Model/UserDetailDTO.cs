﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDetailDTO
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int role { get; set; } 
        
        
    }
}
