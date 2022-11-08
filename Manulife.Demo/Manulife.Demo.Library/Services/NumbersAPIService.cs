using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Manulife.Demo.Library.Models;
using Microsoft.Extensions.Logging;

namespace Manulife.Demo.Library.Services
{
    /// <summary>
    /// <para>Numbers API service to call public API (//numbersapi.com)</para>
    /// <para> API provides interesting facts on various types of Numbers: Date, year,  </para>
    /// </summary>
    public class NumbersAPIService : INumbersAPIService
    {

        public INumbersAPIInfo NumbersAPIInfo { get; set; }
        private readonly ILogger<NumbersAPIService> _logger;

        public NumbersAPIService(INumbersAPIInfo aPIInfo, ILogger<NumbersAPIService> logger)
        {
            this.NumbersAPIInfo = aPIInfo;
            this._logger = logger;
        }

        /// <summary>
        /// <para>GET wrapper. Retrieves fact about number param provided.</para>
        /// <para>Method will utilize Restsharp libaries for API calls</para>
        /// <para>NumbersAPIInfo.JSONResult returns results from API, including errors</para>
        /// </summary>
        /// <param name="type">Type must match one of the APIConstants. Values: trivia (default), math, year & date </param> 
        /// <param name="param"></param>
        /// <returns>true if successfull API call.</returns>

        public bool GetFact()
        {
            bool success = false;       

            try
            {
                using (var apiClient = new RestClient(NumbersAPIInfo.URI))
                {
                    apiClient.AddDefaultUrlSegment("number", NumbersAPIInfo.Param.ToString());
                    apiClient.AddDefaultUrlSegment("type", NumbersAPIInfo.Type);
                    var response = apiClient.Execute(new RestRequest());

                    if (!String.IsNullOrWhiteSpace(response.Content))
                    {
                        NumbersAPIInfo.JSONResult = response.Content;
                        success = true;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error retreiving data");
               
            }

            return success;
        }

    }
}
