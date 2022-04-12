using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Fielid { get; set; }
        public string Old { get; set; }
        public string New { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
