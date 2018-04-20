using IRCSharp.IRC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRCSharp
{
    public partial class TabLayout : Form
    {
        IrcClient client;
        string tabTarget;
        public TabLayout(IrcClient client, string target)
        {
            this.client = client;
            tabTarget = target;
            client.GotPrivateMessage += Client_GotPrivateMessage;
            client.OtherJoinedChannel += Client_OtherJoinedChannel;
            client.OtherPartedChannel += Client_OtherPartedChannel;
            client.GotUserList += Client_GotUserList;
            InitializeComponent();
        }

        public void DisplayText(string text)
        {
            ChatDisplay.AppendText(text + "\r\n");
        }

        private void chatBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                client.SendString("PRIVMSG " + tabTarget + " :" + chatBox.Text);
                ChatDisplay.AppendText(client.Nickname + ": " + chatBox.Text + "\r\n");
                chatBox.Text = String.Empty;
            }
        }

        private void Client_OtherPartedChannel(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                if (message.args[0] == tabTarget)
                {
                    ChatDisplay.AppendText(message.sender + " parted from " + tabTarget + "\r\n");
                    userListBox.Items.Remove(message.sender);
                }
            }));
        }

        private void Client_OtherJoinedChannel(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                if (message.args[0] == tabTarget)
                {
                    ChatDisplay.AppendText(message.sender + " has joined " + tabTarget + "\r\n");
                    userListBox.Items.Add(message.sender);
                }
            }));
        }

        private void Client_GotPrivateMessage(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                if (message.args[0] == tabTarget)
                {
                    ChatDisplay.AppendText(message.sender + ": " + message.trail + "\r\n");
                }
            }));
        }

        private void Client_GotUserList(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                if (message.args.Last() == tabTarget) {
                    userListBox.Items.Clear();
                    userListBox.Items.AddRange(message.trail.Split(' '));
                }
            }));
        }
    }
}
