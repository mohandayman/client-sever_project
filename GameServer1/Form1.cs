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
    public delegate void sendMassegeHandler(object source, string massege);
    public delegate void roomhandler(player playerObject, room roomObject , int roomIndex);
  



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

     

        
    }












    // Start Server Class
    // 

   public class room {

       public player player1, player2;
       public List<player> watchers;
      
        static public List<room> avilableRooms ;



        static room() {
            avilableRooms = new List<room>();
        }

        public room()
        {
                     
           watchers  = new List<player>();
            


        }

      
    }
       




    public class player
    {
      


        public NetworkStream player_stream { get; }
        public StreamReader player_reader { get; }
        public StreamWriter player_writer { get; }

        public room joinedroom;

         public bool isJoinRoom { set; get; }

        public Socket player_socket { get; }
        static public int count { get; set; }
        static player()
        {
            count = 0;
        }
        public player(NetworkStream player_stream, StreamReader player_reader, StreamWriter player_writer, Socket player_socket)
        {
            this.player_writer = player_writer;
            this.player_stream = player_stream;
            this.player_reader = player_reader;
            this.player_socket = player_socket;
            joinedroom = null;
            isJoinRoom = false;
            count++;
           
        }

       
    }
    class server
    {
        // events --
        public event MyEventHandler New_player_connect;
        public event MyEventHandler player_disconected;
        public event sendMassegeHandler massege_recieved;
        static public event roomhandler playerJoinedRoom;


        //  server members --

        Form1 form;
        public string last_one;
        public player current_sender;
    
        Socket client_socket;
        public TcpListener serverListner;
        public IPAddress ipAd;
        public List<player> player_list;   // list all client players 
        public NetworkStream server_network_stream, client_network_stream;
        public StreamReader Server_stream_reader, client_stream_reader;
        public StreamWriter client_stream_writer;




        

        public server(Form1 form)
        {  // server Constractor 

            this.form = form;

            Wifi_Ip();
            int port = 10024;
            serverListner = new TcpListener(IPAddress.Parse(last_one), port);// the serve listner 
            serverListner.Start();
            player_list = new List<player>();
            AcceptNewConnection();      ///     Handle the Connection with new one
            create_four_rooms();
            Thread keep_listenning = new Thread(() => { while (true) { read_massege(); } });
            keep_listenning.Start();
            playerJoinedRoom += new roomhandler(OnPlayerJoinRoom);





        }



        public void OnPlayerJoinRoom(player JoinedPlayer, room JoinedRoom, int roomIndex)
        {


            if (JoinedPlayer.isJoinRoom == false)
            {
                /* foreach (room eachRoom in avilableRooms)
                 {
                     if (JoinedRoom == eachRoom)
                     {*/
                if (JoinedRoom.player2 == null || JoinedRoom.player1 == null)
                {
                    if (JoinedRoom.player2 == null && JoinedRoom.player1 == null)
                    {
                        JoinedRoom.player1 = JoinedPlayer;

                        JoinedPlayer.player_writer.WriteLine($"player has joined room number {room.avilableRooms.IndexOf(JoinedRoom) + 1}");

                    }
                    else if (JoinedRoom.player2 == null && JoinedRoom.player1 != null)
                    {

                        JoinedRoom.player2 = JoinedPlayer;

                        JoinedPlayer.player_writer.WriteLine($"player has joined room number {room.avilableRooms.IndexOf(JoinedRoom) + 1}");
                    }

                }
                else if (JoinedRoom.player2 != null && JoinedRoom.player1 != null)
                {
                    JoinedRoom.watchers.Add(JoinedPlayer);
                    JoinedPlayer.player_writer.WriteLine($"watcher has joined room number {room.avilableRooms.IndexOf(JoinedRoom) + 1}");

                }
                /*}


            }*/
                JoinedPlayer.joinedroom = JoinedRoom;
                JoinedPlayer.isJoinRoom = true;

               


            }


        }


        public void create_four_rooms()
        {
        
        for (int i = 0;i<4;i++) {
                room eachRoom = new room();
               
                room.avilableRooms.Add(eachRoom);
            
            }
        
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

            Task.Factory.StartNew(() =>

            Parallel.ForEach(player_list, async (player) => {

                await Task.Run(() => {


                    if (player != null)
                    {
                        try
                        {
                            var massege = player.player_reader.ReadLine();
                            
                            form.Invoke(new MethodInvoker(delegate () { form.textBox1.Text = massege; }));

                            massege_recieved(player.player_reader, massege); // fire on the event 


                        }
                        catch (Exception ex) { player_disconected(player); }

                    }

                });








            }));

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
            if (current_sender.isJoinRoom == false) { if_player_want_join_room(massege); }
            else { if_player_joining_room(massege); }
           
        }


        public void if_player_joining_room(String massege)
        {
            if(current_sender.isJoinRoom== true )
            {
                if (current_sender == current_sender.joinedroom.player1)
                {

                    if (current_sender.joinedroom.player2 != null)     // if player 1 is sender (playing)
                    {
                        current_sender.joinedroom.player2.player_writer.WriteLine(massege);

                        if (current_sender.joinedroom.watchers.Count > 0)
                        {
                            foreach (player watcher in current_sender.joinedroom.watchers)
                            {

                                watcher.player_writer.WriteLine(massege);

                            }

                        }
                    }
                }
                else if (current_sender == current_sender.joinedroom.player2)
                {
                    if (current_sender.joinedroom.player1 != null) // if player 2 is sender (playing)
                    {
                        current_sender.joinedroom.player1.player_writer.WriteLine(massege);
                        if (current_sender.joinedroom.watchers.Count > 0)
                        {
                            foreach (player watcher in current_sender.joinedroom.watchers)
                            {

                                watcher.player_writer.WriteLine(massege);

                            }

                        }
                    }
                }
                
            }

        }

        public void if_player_want_join_room(String massege  )
        {
            string UpdatedMassege = "";
            int roomNumber = -1;

            if (massege.Contains("Join Room"))
            {
                for (int i = 0; i < massege.Length; i++)
                {
                    if (Char.IsDigit(massege[i]))
                        UpdatedMassege += massege[i];
                }

                if (UpdatedMassege.Length > 0)
                {
                    roomNumber = int.Parse(UpdatedMassege);
                    playerJoinedRoom(current_sender, room.avilableRooms[roomNumber - 1],roomNumber - 1);
                    
                
                }
            }
        }

        public void catch_disconected(object disconnected_player)       ///  when player disconnected ---
        {

            foreach (player player1 in player_list.ToList())
            {
                if (player1 != null)
                {
                    if (player1.player_socket.Connected == false)
                    {
                        //     player_list.Remove((player) disconnected_player);
                        form.Invoke(new MethodInvoker(delegate () { form.   listBox1.Items.Remove(player1); }));

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

