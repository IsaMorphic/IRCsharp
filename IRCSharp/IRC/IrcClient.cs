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
        // Properties
        public TcpClient socket = new TcpClient();
        public NetworkStream stream;
        public StreamReader streamReader;
        public StreamWriter streamWriter;

        // TODO: Better defaults
        public string Nickname = "chosenfewbot";
        public string Server = "chat.freenode.net";
        public string Channel = "#bot-testing";
        public int port = 6667;

        // Events
        public event MessageDelegate GotPrivateMessage;
        public event MessageDelegate GotGeneralMessage;
        public event MessageDelegate GotUserList;
        public event MessageDelegate SelfJoinedChannel;
        public event MessageDelegate OtherJoinedChannel;
        public event MessageDelegate SelfPartedChannel;
        public event MessageDelegate OtherPartedChannel;

        // Constructor
        public IrcClient(string nick, string server, string channel)
        {
            Nickname = nick;
            Server = server;
            Channel = channel;
        }

        // Send a raw message string.
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

        // Convert a message object to a raw string and send it.
        public bool SendMessage(IrcMessage message)
        {
            return SendString(IrcMessage.MakeString(message));
        }

        // Initial connection and handshake.
        public void Connect()
        {
            // Connect to the remote endpoint.
            socket.Connect(Server, port);
            stream = socket.GetStream();

            
            streamReader = new StreamReader(stream, Encoding.ASCII); // Initialize a text reader
            streamWriter = new StreamWriter(stream, Encoding.ASCII); // and a text writer
            // And make sure it flushes when its supposed to.
            streamWriter.AutoFlush = true;

            // Here comes the handshake!

            SendString("NICK " + Nickname); // Register nickname
            SendString("USER " + Nickname + " 8 * :John doe"); // Then register the user with the server.

            Task.Run(new Action(Listen)); // Start listening loop

            SendString("JOIN " + Channel); // and join the channel that was specified in the connection dialog.
        }

        public void Listen()
        {
            while (true)
            {
                // Read a message from the server
                string data = streamReader.ReadLine() + "\r\n";

                // Then pass it to the message processing method.
                MessageReceived(data);
                Console.Write(data); // As well as write the raw message to the console.

                if (data.StartsWith("PING"))
                {
                    var resp = data.Replace("PING", "");
                    SendString("PONG" + resp, false);
                    Console.WriteLine("PONG" + resp);
                }
            }
        }

        // This method analyizes raw message data and triggers the appropriate events.
        public void MessageReceived(string messageString)
        {
            // Parse raw message data
            IrcMessage message = new IrcMessage(messageString);
            
            // Check the message against certain commands.
            if (message.command == "JOIN") // JOIN
            {
                // Check if we're the one joining
                if (message.sender == Nickname)
                {
                    SelfJoinedChannel(message);
                }
                else
                {
                    OtherJoinedChannel(message);
                }
            }
            else if (message.command == "PART") // PART
            {
                // Check if we're the one leaving
                if (message.sender == Nickname)
                {
                    SelfPartedChannel(message);
                }
                else
                {
                    OtherPartedChannel(message);
                }
            }
            else if (message.command == "PRIVMSG") // Private message
            {
                GotPrivateMessage(message);
            }
            else if (message.command == "353") // Name list reply
            {
                GotUserList(message);
            }
            else // Just a random message, most likely from a server.
            {
                GotGeneralMessage(message);
            }
        }
    }
}
