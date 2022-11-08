using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.Demo.Library.Models
{
    /// <summary>
    /// <para>URI can be set dynamically. Hold similar values in appsettings. </para>
    /// <para> Values may be hardcoded for demo purposes ONLY.</para>
    /// <para> Exceptions/ Unit tests are not handled for this demo.</para>
    /// </summary>
    public class NumbersAPIInfo : INumbersAPIInfo
    {
        public string URI { get; set; } = "http://numbersapi.com/{number}/{type}";

        [JsonProperty]
        public string Type { get; set; } = APIConstants.API_Numbers_Type_Year;

        [JsonProperty]
        [Required(ErrorMessage = "A numeric value is required")]
        public int Param { get; set; } = DateTime.Today.Year;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Demo ONLY.
        public string JSONResult { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Demo ONLY.
    }
}
