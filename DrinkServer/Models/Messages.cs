using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public DateTime? DateTime { get; set; }
        public int? UserId { get; set; }
        public byte[] MappingTable { get; set; }
        public int? OtherId { get; set; }
    }

    public class MessagesVM
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public byte[] MappingTable { get; set; }
        public int OtherId { get; set; }
        public string DisplayName { get; set; }
    }
}
