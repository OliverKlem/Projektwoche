using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Management;
using System.Diagnostics;

namespace Serverueberwachung_Server
{
    public partial class Serverueberwachung_Server : Form
    {
        private AsyncTcpServer server;
        private byte[] raw;

        public Serverueberwachung_Server()
        {
            InitializeComponent();

        }
        PerformanceCounter perfCPUCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter perfMemCounter = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter perfSystemCounter = new PerformanceCounter("System", "System Up Time");



     
        private void Serverueberwachung_Server_Load(object sender, EventArgs e)
        {
            server = new AsyncTcpServer(IPAddress.Parse("127.0.0.1"), 49001);
            server.Start();
            server.PacketReceived += Server_PacketReceived;
            server.ClientConnected += Server_ClientConnected;
            timer1.Start();
           // GetComponent();
        }

        private void Server_PacketReceived(object sender, PacketReceivedEventArgs e)
        {
        }

        private void Server_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "CPU Auslastung:" + "   " + (int)perfCPUCounter.NextValue() + "   " + "%";
            label2.Text = "Verfügbarer RAM" + "  " + (int)perfMemCounter.NextValue() + "  " + "MB";
            label3.Text = "Betriebszeit" + "  " + (int)perfSystemCounter.NextValue() / 60 / 60 + " Stunden" ;  
                }
    }
}
