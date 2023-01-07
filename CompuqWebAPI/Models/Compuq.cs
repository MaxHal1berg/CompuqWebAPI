using System;
using System.Collections.Generic;


namespace CompuqWebAPI.Models
{
    public class Compuq
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public int phone_number { get; set; }
        public string phone_make { get; set; } 
        public string phone_monthlypay { get; set; }
        public string phone_plan_monthlypay { get; set; }

    }
}
