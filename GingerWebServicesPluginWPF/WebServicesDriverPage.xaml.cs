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
using System;
using System.Windows;
using System.Windows.Controls;

namespace GingerWebServicesPluginWPF
{
    /// <summary>
    /// Interaction logic for WebServicesDriverPage.xaml
    /// </summary>
    public partial class WebServicesDriverPage : Page, IWebServicesDriverDisplay 
    {
        public IWebServicesDriver mWebServicesDriverProxy;
        
        public string URL
        {
            get { return URLTextBox.Text; }
            set {  URLTextBox.Text = value;                                
            }
        }

        public IWebServicesDriver Driver;

        public WebServicesDriverPage()
        {
            InitializeComponent();
        }

        public void InitDriver(IWebServicesDriver webServicesDriverProxy)
        {
            mWebServicesDriverProxy = webServicesDriverProxy; 
        }

        public void Close()   
        {
            this.Close();
        }

        public void InitScreen(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void show()
        {
            throw new NotImplementedException();
        }
        
        public void WriteLine(string txt)
        {
            throw new NotImplementedException();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            Driver.DoHTTP(URLTextBox.Text);
        }

        public void SetURL(string url)
        {           
            URLTextBox.Text = url;
        }

        public void ShowDisplay()
        {
            throw new NotImplementedException();
        }

        public void SetRequest(string req)
        {
            throw new NotImplementedException();
        }

        public void SetResponse(string req)
        {
            throw new NotImplementedException();
        }

        public void AttachEventHandler(IWebServicesDriver webServicesDriver)
        {
            throw new NotImplementedException();
        }

        public void AddLog(string txt)
        {
            LogTextBlock.Text += DateTime.Now + " " + txt + Environment.NewLine;
        }
    }
}
