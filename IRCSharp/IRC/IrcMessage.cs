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
            if (message.trail == null)
            {
                result = String.Format(
                    ":{0} {1} {2}",
                    message.prefix,
                    message.command,
                    String.Join(" ", message.args)
                    );
            }
            else
            {
                result = String.Format(
                    ":{0} {1} {2} :{3}",
                    message.prefix,
                    message.command,
                    String.Join(" ", message.args),
                    message.trail
                    );
            }
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

        public IrcMessage(string message)
        {
            try
            {
                rawData = message.TrimEnd(new char[] { '\r', '\n' });

                string[] messageSplit =
                    rawData.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string[] messageStrings = messageSplit[0]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                prefix = messageStrings[0].TrimStart(':');
                command = messageStrings[1];
                args = messageStrings.Skip(2).ToArray();

                sender = prefix.Split('!')[0];
                targets = args.Where(arg => arg != args.Last()).ToArray();

                trail = messageSplit[1];
                parsed = true;
            }
            catch (Exception) { }
        }
    }
}
