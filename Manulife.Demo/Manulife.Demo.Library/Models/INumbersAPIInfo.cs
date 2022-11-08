using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.Demo.Library.Models
{
    public interface INumbersAPIInfo
    {
        public string URI { get; set; }
        public string Type { get; set; }
        [Required]
        public int Param { get; set; }
        public string JSONResult { get; set; }
    }
}
