using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IRCSharp
{
    class IrcClient
    {
        public IrcClient(string nick, string server, string channel) {
            Nickname = nick;
            Server = server;
            Channel = channel;
        }
        public TcpClient socket = new TcpClient();
        public NetworkStream stream;
        public string Nickname = "chosenfewbot";
        public string Server = "chat.freenode.net";
        public string Channel = "#bot-testing";
        public int port = 6667;
        public bool SendString(string s, bool crlf = true)
        {
            try
            {
                string data = (crlf) ? s + "\r\n" : s;
                byte[] sendData;
                sendData = Encoding.ASCII.GetBytes(data);

                stream.Write(sendData, 0, sendData.Length);
                stream.Flush();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Connect()
        {
            socket.Connect(Server, port);
            stream = socket.GetStream();
            SendString("NICK " + Nickname);
            SendString("USER " + Nickname + " 8 * :John doe");
            while (!stream.DataAvailable) { }
            while (stream.DataAvailable)
            {
                byte[] byteData = new byte[256];
                stream.Read(byteData, 0, byteData.Length);

                string data = Encoding.ASCII.GetString(byteData);
                Console.Write(data);

                if (data.StartsWith("PING"))
                {
                    var resp = data.Replace("PING", "");
                    SendString("PONG" + resp, false);
                    Console.WriteLine("PONG" + resp);
                }

                int i = 0;
                while (!stream.DataAvailable && i < 15) { Thread.Sleep(1000); i++; }
            }
            SendString("JOIN " + Channel);
            SendString("PRIVMSG " + Channel + " :wasup");
        }
    }
}
