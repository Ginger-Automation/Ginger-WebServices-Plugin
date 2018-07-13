#region License
/*
Copyright © 2014-2018 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion

using Amdocs.Ginger.WebServices;
using GingerPlugInsNET.ActionsLib;
using GingerPlugInsNET.DriversLib;
using GingerPlugInsNET.PlugInsLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace GingerWebServicesPlugin
{
    public class WebServicesDriver : PluginDriverBase  , IDriverDisplay, IWebServicesDriver
    {
        IWebServicesDriverDisplay mDisplay = null;

        public void AttachDisplay(object display)
        {           
            mDisplay = (IWebServicesDriverDisplay)display;
        }

        public override string Name { get { return "Web Services driver";  } }

        public override void CloseDriver()
        {
            Console.WriteLine("Closing Web Services driver");
        }

        public override void StartDriver()
        {
            Console.WriteLine("Starting Web Services driver");
        }

        [GingerAction(ID: "HTTP", Description: "Get URL via HTTP")]
        public void HTTP(GingerAction gingerAction, string url)
        {
            if (mDisplay != null)
            {
                mDisplay.URL = url;
            }
            // example to show error checks
            if (!url.StartsWith("HTTP", StringComparison.InvariantCultureIgnoreCase))
            {
                gingerAction.AddError("WebServicesDriver.HTTP", "URL must start with HTTP - " + url);
                return;
            }

            using (var client = new HttpClient())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var result = client.GetAsync(url).Result;
                stopwatch.Stop();
                    
                gingerAction.Output.Add("Status Code", result.StatusCode.ToString());
                gingerAction.Output.Add("Elapsed", stopwatch.ElapsedMilliseconds.ToString());
                if (mDisplay != null)
                {
                    mDisplay.AddLog("Elapsed - " + stopwatch.ElapsedMilliseconds);
                }
            }
            
            gingerAction.ExInfo = "URL: " + url;            
        }

        // Enable to send several urls in one shot
        [GingerAction("HTTPs", "Get several URLs via HTTP")]
        public void HTTPs(GingerAction gingerAction, List<string> URLs)
        {
            using (var client = new HttpClient())
            {
                foreach (string url in URLs)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    var result = client.GetAsync(url).Result;
                    stopwatch.Stop();

                    gingerAction.Output.Add("Status Code", result.StatusCode.ToString(), url);
                    gingerAction.Output.Add("Elapsed", stopwatch.ElapsedMilliseconds.ToString(), url);                    
                }
            }
            
            gingerAction.ExInfo = "Total URLs: " + URLs.Count;            
        }

        // Activated from Display
        public void DoHTTP(string url)
        {
            throw new NotImplementedException();
        }
    }
}
