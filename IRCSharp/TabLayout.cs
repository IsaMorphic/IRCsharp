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

            // Register client events...
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
            // If the user pressed enter, 
            if (e.KeyCode == Keys.Enter)
            {
                // Build a message object
                IrcMessage message = new IrcMessage(
                    "PRIVMSG", new string[] { tabTarget }, chatBox.Text); // PRIVMSG <nickname> <channel/user> :<message text>
                client.SendMessage(message); // Send the message to the server, 
                ChatDisplay.AppendText(client.Nickname + ": " + chatBox.Text + "\r\n"); // Display it on the client side, 
                chatBox.Text = String.Empty; // Then clear the chatbox.  
            }
        }

        private void Client_OtherPartedChannel(IrcMessage message)
        {
            // When another user parts from a channel
            BeginInvoke((Action)(() =>
            {
                // and if the message is for the tab's dedicated channel
                if (message.args[0] == tabTarget)
                {
                    // Display a message
                    ChatDisplay.AppendText(message.sender + " parted from " + tabTarget + "\r\n");
                    // and remove the user from the list
                    userListBox.Items.Remove(message.sender);
                }
            }));
        }

        private void Client_OtherJoinedChannel(IrcMessage message)
        {
            // When another user joins the channel
            BeginInvoke((Action)(() =>
            {
                // and the message is for the tab's dedicated channel
                if (message.args[0] == tabTarget)
                {
                    // Display a message
                    ChatDisplay.AppendText(message.sender + " has joined " + tabTarget + "\r\n");
                    // and add the user to the user list.  
                    userListBox.Items.Add(message.sender);
                }
            }));
        }

        private void Client_GotPrivateMessage(IrcMessage message)
        {
            // When the user receives a PRIVMSG command...
            BeginInvoke((Action)(() =>
            {
                // and if it is intended to be for this tab's target...
                if (message.args[0] == tabTarget)
                {
                    // Display the message along with the sender.  
                    ChatDisplay.AppendText(message.sender + ": " + message.trail + "\r\n");
                }
            }));
        }

        private void Client_GotUserList(IrcMessage message)
        {
            // When the client recieves a user list...
            BeginInvoke((Action)(() =>
            {
                // and the message is targeted towards this tab's target...
                if (message.args.Last() == tabTarget) {
                    // Clear the user list
                    userListBox.Items.Clear();
                    // And build a new list.
                    userListBox.Items.AddRange(message.trail.Split(' '));
                }
            }));
        }
    }
}
