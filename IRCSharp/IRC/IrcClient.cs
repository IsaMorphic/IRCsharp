using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace IRCSharp.IRC
{
    public delegate void MessageDelegate(IrcMessage message);

    public class IrcClient
    {
        public TcpClient socket = new TcpClient();
        public NetworkStream stream;
        public StreamReader streamReader;
        public StreamWriter streamWriter;
        public string Nickname = "chosenfewbot";
        public string Server = "chat.freenode.net";
        public string Channel = "#bot-testing";
        public int port = 6667;

        public event MessageDelegate GotPrivateMessage;
        public event MessageDelegate GotGeneralMessage;
        public event MessageDelegate GotUserList;
        public event MessageDelegate SelfJoinedChannel;
        public event MessageDelegate OtherJoinedChannel;
        public event MessageDelegate SelfPartedChannel;
        public event MessageDelegate OtherPartedChannel;

        public IrcClient(string nick, string server, string channel)
        {
            Nickname = nick;
            Server = server;
            Channel = channel;
        }

        public bool SendString(string s, bool crlf = true)
        {
            try
            {
                string data = (crlf) ? s + "\r\n" : s;
                streamWriter.Write(data);

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

            streamReader = new StreamReader(stream, Encoding.ASCII);
            streamWriter = new StreamWriter(stream, Encoding.ASCII);
            streamWriter.AutoFlush = true;

            SendString("NICK " + Nickname);
            SendString("USER " + Nickname + " 8 * :John doe");

            Task.Run(new Action(Listen));

            SendString("JOIN " + Channel);
        }

        public void Listen()
        {
            while (true)
            {
                string data = streamReader.ReadLine() + "\r\n";
                MessageReceived(data);
                Console.Write(data);

                if (data.StartsWith("PING"))
                {
                    var resp = data.Replace("PING", "");
                    SendString("PONG" + resp, false);
                    Console.WriteLine("PONG" + resp);
                }
            }
        }

        public void MessageReceived(string messageString)
        {
            IrcMessage message = new IrcMessage(messageString);
            if (message.command == "JOIN")
            {
                if (message.sender == Nickname)
                {
                    SelfJoinedChannel(message);
                }
                else
                {
                    OtherJoinedChannel(message);
                }
            }
            else if (message.command == "PART")
            {
                if (message.sender == Nickname)
                {
                    SelfPartedChannel(message);
                }
                else
                {
                    OtherPartedChannel(message);
                }
            }
            else if (message.command == "PRIVMSG")
            {
                GotPrivateMessage(message);
            }
            else if (message.command == "353")
            {
                GotUserList(message);
            }
            else
            {
                GotGeneralMessage(message);
            }
        }
    }
}
