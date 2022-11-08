
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manulife.Demo.Library.Models;

namespace Manulife.Demo.Library.Services
{
    public interface INumbersAPIService
    {
        public INumbersAPIInfo NumbersAPIInfo { get; set; }
        public bool GetFact();

    }
}
