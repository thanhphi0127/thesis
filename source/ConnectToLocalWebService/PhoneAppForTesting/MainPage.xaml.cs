using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneAppForTesting.Resources;

namespace PhoneAppForTesting
{
    public partial class MainPage : PhoneApplicationPage
    {
        int testValue = 7;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void TestWebService()
        {
            

            ServiceReference1.Service1Client clientForTesting = new ServiceReference1.Service1Client();
            clientForTesting.GetDataCompleted += new EventHandler<ServiceReference1.GetDataCompletedEventArgs>(TestCallback);
            clientForTesting.GetDataAsync(testValue);
        }

        private void TestCallback(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            this.tbWebServiceResult.Text = e.Result;
        }

        private void btnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            testValue++;
            TestWebService();
        }
    }
}