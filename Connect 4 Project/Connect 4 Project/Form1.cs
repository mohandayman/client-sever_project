using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4_Project
{
    public delegate void MyEventHandler(object source);
    public delegate void massegeHandler(object source, string massege);



    public partial class Form1 : Form
    {
        client Game_client;

        public Form1()
        {
            InitializeComponent();
            Game_client = new client(this);
            Game_client.New_player_connect += new MyEventHandler(Game_client.on_player_connected);
            Game_client.New_server_massege += new massegeHandler(Game_client.On_massege_recieved);
           

        }

       

        private void send_button_Click(object sender, EventArgs e)
        {
            try
            {
               Game_client.Send_Massege(this.massegeBox.Text);

            }

            catch (Exception exp)
            {
                
            }


           
        }

       

        public void open_tab()
        {
            Application.Run(new Form1());
        }

        private void New_tab_Click(object sender, EventArgs e)
        {
            Thread newTab_thread = new Thread(open_tab);
            newTab_thread.Start();
        }

        
        private void join_room_1_Click(object sender, EventArgs e)
        {
            Game_client.Send_Massege("Join Room 1");
        }
        

        private void join_room_2_Click_1(object sender, EventArgs e)
        {
            Game_client.Send_Massege("Join Room 2");

        }

        private void join_room_3_Click_1(object sender, EventArgs e)
        {
            Game_client.Send_Massege("Join Room 3");

        }

        private void join_room_4_Click_1(object sender, EventArgs e)
        {
            Game_client.Send_Massege("Join Room 4");

        }
    }

    public class client
    {

        public event MyEventHandler New_player_connect;
        public event massegeHandler New_server_massege;
        public Form1 form;
        TcpClient tcp_client_player;
        IPAddress severIP;
        int portNumber;
        Socket client_socket;
        NetworkStream client_network_stream;
        public StreamWriter client_stream_writer;
        public StreamReader client_stream_reader;
        static public int Connected_players;
        public string server_massege { set; get; }


        public void listen_to_server()
        {
            while (true)
            {
                server_massege = client_stream_reader.ReadLine();
                New_server_massege(this,server_massege);
               
            }
        }
        static client()
        {
            Connected_players = 0;

        }
        public client(Form1 form)
        {
            this.form = form;
            Connected_players++;
            create_Client("connected" + Connected_players.ToString());
            new Thread(listen_to_server).Start(); // listening to incomming masseges 
        }
        public void create_Client(string msg)
        {
            
                tcp_client_player = new TcpClient();
                tcp_client_player.Connect("192.168.1.10", 10024);
                client_socket = tcp_client_player.Client;
                client_network_stream = new NetworkStream(client_socket);
                client_stream_writer = new StreamWriter(client_network_stream);
                client_stream_reader = new StreamReader(client_network_stream);
                //New_player_connect(client_socket);
                client_stream_writer.AutoFlush = true;
            
            
        }
        public void on_player_connected(object obj)
        {
           
        }
        public void Send_Massege(string msg)
        {

            client_stream_writer.WriteLine(msg);
        }


       public void On_massege_recieved(object client , string server_massege)
        {
            form.Invoke(new MethodInvoker(delegate () {
                form.massegeBox.Text = server_massege;}));
        }

    }
}
