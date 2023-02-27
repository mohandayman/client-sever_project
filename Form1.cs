using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Xml.Schema;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Sockets;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Threading;


namespace GameServer
{

    public partial class Form1 : Form
    {
        Queue<Socket> players_Sockets;   // list all client players 
        public Form1()
        {
            InitializeComponent();
            IPAddress ipAd = IPAddress.Parse("192.168.1.10");
            TcpListener serverListner = new TcpListener(ipAd, 8001);
            serverListner.Start();
            players_Sockets = new Queue<Socket>();

            Thread thread = new Thread(new ThreadStart(() =>
            {

                while (true)
                {
                    players_Sockets.Enqueue(serverListner.AcceptSocket());
                }
                     }));

            thread.Start();





        }

        private void start_server_click(object sender, EventArgs e)
        {
            foreach (Socket player in players_Sockets)
            {
                MessageBox.Show("The remote  End point is  :" +
                                          player.RemoteEndPoint);
            }

        }

        private void recieve_btn_Click(object sender, EventArgs e)
        {

        }
    }


}



  /*  public class server
    {
        Socket connection;
        TcpListener listener;
        IPAddress localHost;
        int portNumber;
        string ip;
        NetworkStream serverstream;
        BinaryReader server_reader;
        public server()
        {
            portNumber = 13000;
            localHost = IPAddress.Parse("192.168.1.10");
            listener = new TcpListener(localHost, portNumber);

            Thread thread = new Thread(new ThreadStart(() =>
            {
                listener.Start();
                while (true)
                {
                    connection = listener.AcceptSocket();
                }
            }));
            thread.Start();
            if (connection.Connected)
            {
                serverstream = new NetworkStream(connection);
                server_reader = new BinaryReader(serverstream);
                server_reader.Read();
            }
        }

    }
*/

