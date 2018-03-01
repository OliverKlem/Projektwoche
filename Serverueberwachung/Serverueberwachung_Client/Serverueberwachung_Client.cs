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

namespace Serverueberwachung_Client
{
    public partial class Serverueberwachung_Client : Form
    {
        private AsyncTcpClient client;
        private byte[] raw;
        private string hostname, ipAdresse;

        public Serverueberwachung_Client()
        {
            InitializeComponent();
        }

        private void Serverueberwachung_Client_Load(object sender, EventArgs e)
        {
            client = new AsyncTcpClient();
            client.PacketReceived += Client_PacketReceived; ;
            client.Connected += Client_Connected; ;

            lblStatus.ForeColor = Color.Red;
        }

        private void Client_Connected(object sender, ClientConnectedEventArgs e)
        {
            Invoke((MethodInvoker)(() => { btnVerbinden.Enabled = false; }));
            Invoke((MethodInvoker)(() => { txtPort.Enabled = false; }));
            Invoke((MethodInvoker)(() => { txtIp.Enabled = false; }));
            Invoke((MethodInvoker)(() => { lblStatus.Text = string.Format("Verbindungsstatus: Verbunden"); }));
            Invoke((MethodInvoker)(() => { lblStatus.ForeColor = Color.Green; }));
        }

        private void btnVerbinden_Click(object sender, EventArgs e)
        {
            string ip = txtIp.Text;
            int port = Convert.ToInt32(txtPort.Text);

            client.Connect(IPAddress.Parse(ip), port);
        }

        private void Client_PacketReceived(object sender, PacketReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
