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

using GingerPlugInsNET.ActionsLib;
using GingerWebServicesPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GingerWebServicesPluginTest
{
    [TestClass]
    public class UnitTest1
    {

        static WebServicesDriver mWebServicesDriver;

        [ClassInitialize]
        public static void ClassInit(TestContext TC)
        {
            mWebServicesDriver = new WebServicesDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }


        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanUp()
        {

        }

        

        [TestMethod]
        public void HTTPGoogle()
        {
            // Arrange
            string URL = "https://www.google.com";
            GingerAction GA = new GingerAction("HTTP");

            // Act      
            mWebServicesDriver.HTTP(GA, URL);
            
            // Assert
            Assert.AreEqual(GA.ExInfo, "URL: " + URL);
            Assert.AreEqual(GA.Errors, null);            
        }



        [TestMethod]
        public void HTTPs()
        {
            // Arrange
            List<string> URLs = new List<string>();
            URLs.Add("https://www.google.com");
            URLs.Add("https://www.facebook.com");
            URLs.Add("https://www.att.com");
            GingerAction GA = new GingerAction("HTTPs");
            // Act      
            mWebServicesDriver.HTTPs(GA, URLs);

            // Assert
            // Assert.AreEqual(GA.ExInfo, "URL: " + URLs);
            Assert.AreEqual(GA.Errors, null);
            Assert.AreEqual("Total URLs: 3", GA.ExInfo);
            Assert.AreEqual("OK", GA.Output.Values[0].ValueString);
            //TODO: add validation to all output with path

        }
    }
}
