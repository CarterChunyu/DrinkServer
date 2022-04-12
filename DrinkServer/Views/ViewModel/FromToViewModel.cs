using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Views.ViewModel
{
    public class FromToViewModel
    {
        public string FromName { get; set; }

        public string ToName { get; set; }

        [Key]
        public int OrderPlaceMappingId { get; set; }
    }
}
