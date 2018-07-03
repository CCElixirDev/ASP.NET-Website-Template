using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TestWebsite.Models
{
    public class ServiceModel
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }
    }

}
