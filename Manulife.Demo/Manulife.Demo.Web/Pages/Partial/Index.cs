using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

using Manulife.Demo.Library.Models;
using Manulife.Demo.Library.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Manulife.Demo.Web.Pages
{
    public partial class Index
    {
        private InputNumber<int>? txtNumber;
        protected EditContext? DemoContext { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Injected via DI. See Startup.cs for list of objects injected. 
        /// </summary>
        [Inject] public INumbersAPIService APIService { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #region Events
        /// <summary>
        /// View Init. Declare context here
        /// </summary>
        protected override void OnInitialized()
        {
            DemoContext = new EditContext(this);
        }

        /// <summary>
        /// This event fires when page params are initialized
        /// </summary>
        protected override void OnParametersSet()
        {
            //Demo does not use params & query strings
        }

        /// <summary>
        /// Event is used to set focus on input
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                if (txtNumber != null && txtNumber.Element != null)
                    await txtNumber.Element.Value.FocusAsync();
        }

        /// <summary>
        /// <para>Handles page submit event & validation </para> 
        /// <para>If using Async, use only TASK, avoid using Void</para>
        /// </summary>
        protected void HandleValidSubmitEvent()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value. ***DEMO***. 
            try
            {
                if (APIService != null)
                {
                    APIService.GetFact();
                }
            }
            //Sample Exception block
            //Working demo may be available in Service method calls. 
            catch (Exception e)
            {
                //DI. Logging providers are used to log exceptions here           
            }
#pragma warning restore IDE0059 // Unnecessary assignment of a value. ***DEMO***
        }
        #endregion
    }
}