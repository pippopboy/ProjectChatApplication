﻿using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
using OptionContract;
using Hosting;

namespace Hosting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        
        
        public Uri baseAddress;
        Type contractType = typeof(IChat);
        Type instanceType = typeof(ChatServer);
        private ServiceHost host;
        private bool ServiceStarted = false;
        private void BtStartServiceClick(object sender, EventArgs e)
        {
            if (ServiceStarted)
            {
                host.Close();
                ServiceStarted = false;
            }
            else
            {
                
                baseAddress = new Uri(txbaseaddress.Text);
                host = new ServiceHost(instanceType, baseAddress);
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(behavior);
                WSDualHttpBinding ws = new WSDualHttpBinding();
                ws.MaxBufferPoolSize = int.MaxValue;
                ws.MaxReceivedMessageSize = int.MaxValue;
                ws.ReaderQuotas.MaxArrayLength = int.MaxValue;
                ws.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                ws.ReaderQuotas.MaxStringContentLength = int.MaxValue;
        
                host.AddServiceEndpoint(contractType, ws, "");
                //host.AddServiceEndpoint(contractType, new NetMsmqBinding(), "");
               
                if (cbMex.Checked)
                { 
                    host.AddServiceEndpoint(typeof(IMetadataExchange), ws, "MEX");
                }
                host.Open();
                lbmessage.Visible = true;
                lbmessage.Text = "Host Option is running...";
                //MessageBox.Show(" " + svcEndpoint.Address);
                ServiceStarted = true;
                
            }
        }

        private void BtStopServiceClick(object sender, EventArgs e)
        {
            lbmessage.Visible = true;
            if (ServiceStarted)
            {
                host.Close();
                lbmessage.Text = "Host stopped!";
            }
            else
            {
                lbmessage.Text = "Host is not running!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txbaseaddress.Text = "http://localhost:8000/Chat";
        }

        private void txLocation_MouseClick(object sender, MouseEventArgs e)
        {
            txLocation.Text = "";
        }

        private void txtServiceContract1_MouseClick(object sender, MouseEventArgs e)
        {
            txtServiceContract1.Text = "";
        }

        private void txtServiceContract2_MouseClick(object sender, MouseEventArgs e)
        {
            txtServiceContract2.Text = "";
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            Xml xml = new Xml();
            XmlDocument doc = new XmlDocument();
            if (!cbServiceContract1.Checked && !cbServiceContract2.Checked)
            {
                MessageBox.Show("Please choose Service Contract!");
            }
            else
            {
                if (cbBinding.Text != "" && txLocation.Text != "")
                {
                    xml.CreateXmlService(doc);
                    if (cbServiceContract1.Checked)
                    {
                        xml.AddService(doc, txLocation.Text, cbBinding.Text, "Option");
                    }
                    if (cbServiceContract2.Checked)
                    {
                        xml.AddService(doc, txLocation.Text, cbBinding.Text, "Option1");
                    }
                    doc.Save(@"appconfig.xml");
                    MessageBox.Show("Save successfully! Appconfig.xml is saved at bin/debug folder! Please check again!");

                }
                else
                {
                    MessageBox.Show("Please enter endpoint binding and location!");
                }
            }
        }

    }
}
