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

        private void Serverueberwachung_Server_Load(object sender, EventArgs e)
        {
            server = new AsyncTcpServer(IPAddress.Parse("127.0.0.1"), 49001);
            server.Start();
            server.PacketReceived += Server_PacketReceived;
            server.ClientConnected += Server_ClientConnected;
        }

        private void Server_PacketReceived(object sender, PacketReceivedEventArgs e)
        {
        }

        private void Server_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
        }
    }
}
