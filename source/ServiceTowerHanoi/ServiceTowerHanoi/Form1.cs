using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceTowerHanoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ServiceHost HostProxy;

        private void Form1_Load(object sender, EventArgs e)
        {
            string address = "http://localhost:8001/test";
            HostProxy = new ServiceHost(typeof(Test), new Uri(address));

            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            HostProxy.Description.Behaviors.Add(smb);

            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            try
            {
                HostProxy.Open();
                MessageBox.Show("The service is ready at " + address);
            }
            catch (AddressAccessDeniedException)
            {
                MessageBox.Show("You need to reserve the address for this service");
                HostProxy = null;
            }
            catch (AddressAlreadyInUseException)
            {
                MessageBox.Show("Something else is already using this address");
                HostProxy = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something bad happened on startup: " + ex.Message);
                HostProxy = null;
            }
        }
 
    }
}
