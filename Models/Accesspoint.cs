using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    public class Accesspoint
    {
        public string Location { get; set; }
        public string SSID { get; set; }
        public string Encryption { get; set; }
    }
}