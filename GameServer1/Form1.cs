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
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace GameServer
{



    public delegate void MyEventHandler(object source);
    public delegate void sendMassegeHandler(object source,string massege);




    public partial class Form1 : Form
    {
        
        server GameServer;

       
        public Form1()
        {
            InitializeComponent();

            GameServer = new server(this);
            GameServer.New_player_connect += new MyEventHandler(GameServer.On_player_connected);
            GameServer.massege_recieved += new sendMassegeHandler(GameServer.On_massege_recieved);
            GameServer.player_disconected += new MyEventHandler(GameServer.catch_disconected);



        }

            private void recieve_btn_Click(object sender, EventArgs e)
            {

            GameServer.read_massege();



              }

        private void send_massege_Click(object sender, EventArgs e)
        {
            GameServer.current_sender.player_writer.WriteLine("acknolgment");
        }
    }












    // Start Server Class 

   public class player
    {

       public NetworkStream player_stream{get;}
       public StreamReader player_reader {get;}
       public StreamWriter player_writer { get; }
        public Socket player_socket { get;}
        static public int count { get; set; }
        static  player()
        {
            count = 0;
        }
        public player (NetworkStream player_stream, StreamReader player_reader, StreamWriter player_writer , Socket player_socket)
            {
            this.player_writer = player_writer;
            this.player_stream = player_stream;
            this.player_reader = player_reader;
            this.player_socket = player_socket;
            count++;
               }
}
    class server
    {
        // events --
        public event MyEventHandler New_player_connect;
        public event MyEventHandler player_disconected;
        public event sendMassegeHandler massege_recieved;


        //  server members --

        Form1 form;
        public string last_one;
        public player current_sender;
        int port;
        Socket client_socket;
        public TcpListener serverListner;
        public IPAddress ipAd;
        public List<player> player_list;   // list all client players 
        public NetworkStream server_network_stream, client_network_stream;
        public StreamReader Server_stream_reader, client_stream_reader;
        public StreamWriter client_stream_writer;






        public server(Form1 form) {  // server Constractor 

            this.form = form;

            Wifi_Ip();
            int port = 10024;
            serverListner = new TcpListener(IPAddress.Parse(last_one), port);// the serve listner 
            serverListner.Start();
            player_list = new List<player>();
            AcceptNewConnection();      ///     Handle the Connection with new one
            read_massege();
            Thread keep_listenning = new Thread(read_massege);
            keep_listenning.Start();

        }
        public void On_player_connected(object sender) // handle when the player connect TO THe server 
        {
            client_network_stream = new NetworkStream(client_socket);
            client_stream_writer = new StreamWriter(client_network_stream);
            client_stream_reader = new StreamReader(client_network_stream, Encoding.UTF8);
            client_stream_writer.AutoFlush = true;
            player new_player = new player(client_network_stream, client_stream_reader, client_stream_writer, client_socket);
            player_list.Add(new_player);
            form.Invoke(new MethodInvoker(delegate () { form.listBox1.Items.Add($"player {player.count} conected"); }));
            form.Invoke(new MethodInvoker(delegate () { form.connected_players.Text = $"connected Players {player.count} "; }));


        }

        public void read_massege()      // Thread to keep listenning To Incomming Masseges 
        {
            
                try
                {
                    foreach (var player in player_list)

                    {
                        Thread accept_masseges = new Thread(() =>
                        {
                            while (true)

                                if (player != null)
                                {
                                    var massege = player.player_reader.ReadLine();
                                    form.Invoke(new MethodInvoker(delegate () { form.textBox1.Text = massege;  }));
                                     
                                    massege_recieved(player.player_reader, massege); // fire on the event 
                                }

                        });

                        accept_masseges.Start();


                    }

                }
                catch (Exception ex) { player_disconected(this); }


            


        }

        public void On_massege_recieved(object client_reader, string massege)  // Catch The Player Who Send The Massege 
        {

            foreach (player player in player_list)
            {
                if (client_reader == player.player_reader)
                {
                    current_sender = player;
                    break;
                }
            }

            current_sender.player_writer.WriteLine($"servr aknolgment on massege  =>  {massege}");

        }

        public void catch_disconected(object disconnected_player)       ///  when player disconnected ---
        {
           
                foreach (player player1 in player_list.ToList())
                {
                    if (player1 != null) {
                        if (player1.player_socket.Connected == false) {
                            form.Invoke(new MethodInvoker(delegate () { form.listBox1.Items.Remove(player1); }));
                             player_list.Remove(player1);

                        }
                    }
                }
            
        }


        private void AcceptNewConnection()
        {

            Thread connection_thread = new Thread(new ThreadStart(() =>
            {

                while (true)
                {
                    client_socket = serverListner.AcceptSocket();
                    New_player_connect(client_socket);
                }
            }));

            connection_thread.Start();

        }





















































        public void Wifi_Ip()
        {

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    last_one = ip.ToString();

                }
            }
            
        }


    }
}

















/* public void read_massege()      // Thread to keep listenning To Incomming Masseges 
        {
            
                try
                {
                    foreach (var player in player_list)

                    {
                        Thread accept_masseges = new Thread(() =>
                        {
                            while (true)

                                if (player != null)
                                {
                                    var massege = player.player_reader.ReadLine();
                                    form.Invoke(new MethodInvoker(delegate () { form.textBox1.Text = massege;  }));
                                     
                                    massege_recieved(player.player_reader, massege); // fire on the event 
                                }

                        });

                        accept_masseges.Start();


                    }

                }
                catch (Exception ex) { player_disconected(this); }


            


        }*/

