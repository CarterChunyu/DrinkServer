using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Views.ViewModel
{
    public class TestVM
    {
        public int Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public int LocationId { get; set; }
        public DateTime CreateTime { get; set; }

        public string Name1 { get; set; }

    }
}
