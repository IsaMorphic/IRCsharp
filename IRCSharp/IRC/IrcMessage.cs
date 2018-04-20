using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCSharp.IRC
{
    public class IrcMessage
    {
        public string rawData;

        public string prefix;
        public string command;
        public string[] args;
        public string trail;

        public string sender;
        public string[] targets;

        public bool parsed = false;

        public static string MakeString(IrcMessage message)
        {
            string result;
            bool hasCommand = false;
            
            if (message.prefix == null)
            {
                // If the message doesnt have a prefix, 
                // start the string with the command and dont put a leading colon.
                result = message.command + " ";

                // And set this flag to make sure we dont put the command in twice
                hasCommand = true;
            }
            else
            {
                // Otherwise, start the string with the prefix and a leading colon.
                result = ":" + message.prefix + " ";
            }
            // If the flag is not set, add the command in.
            if (!hasCommand)
                result += " " + message.command + " ";
            // Then append all the arguments onto the string.
            result += String.Join(" ", message.args);

            // If the message object has a trail, append it on the string
            if (message.trail != null)
            {
                result += " :" + message.trail;
            }
            // Then return the result.
            return result;
        }

        public IrcMessage(string _prefix, string _command, string[] _args)
        {
            prefix = _prefix;
            command = _command;
            args = _args;
        }

        public IrcMessage(string _prefix, string _command, string[] _args, string _trail)
        {
            prefix = _prefix;
            command = _command;
            args = _args;
            trail = _trail;
        }

        public IrcMessage(string _command, string[] _args, string _trail)
        {
            command = _command;
            args = _args;
            trail = _trail;
        }

        public IrcMessage(string _command, string[] _args)
        {
            command = _command;
            args = _args;
        }

        public IrcMessage(string message)
        {
            try
            {
                // Keep the raw message data and remove the trailing crlf.
                rawData = message.TrimEnd(new char[] { '\r', '\n' });

                // Then split the message into two parts. The command, and the trail.
                string[] messageSplit =
                    rawData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Then split the command into small chunks.  
                string[] messageStrings = messageSplit[0]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // The first of these chunks is called the prefix.
                // We want to remove the leading colon at the beginning of it.  
                prefix = messageStrings[0].TrimStart(':');

                // Next chunk is the command itself. 
                command = messageStrings[1];

                // Finally we have the arguments, which are all the remaining chunks.  
                args = messageStrings.Skip(2).ToArray();

                // Then we dirive some more useful information from these chunks
                sender = prefix.Split('!')[0];                              // such as who sent the message, 
                targets = args.Where(arg => arg != args.Last()).ToArray(); // and who it was targeted towards.  

                // Then we finally grab the trail if there is one.
                trail = messageSplit[1];

                // If all succeeds, we set a flag that signifies a successful parse.  
                parsed = true;
            }
            catch (Exception) { /* If anything fails at all during this process, stop and return. */ }
        }
    }
}
