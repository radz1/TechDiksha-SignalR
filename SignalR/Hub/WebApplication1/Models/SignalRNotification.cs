using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SignalRNotification
    {
        [Required]
        public string GroupId { get; set; }
        
        [Required]
        public string SignalRMessage { get; set; }
    }
}