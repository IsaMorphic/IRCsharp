using IRCSharp.IRC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRCSharp
{
    public partial class IRCApp : Form
    {
        public object Clone(object o)

        {

            using (MemoryStream stream = new MemoryStream())

            {

                if (o.GetType().IsSerializable)

                {

                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(stream, o);

                    stream.Position = 0;

                    return formatter.Deserialize(stream);

                }

                return null;

            }

        }

        // Global properties
        private IrcClient client;
        // Client status TabLayout object
        private TabLayout StatusTabControl;

        // Dictionary of tabs and their targets.  
        private Dictionary<string, TabLayout> Tabs = new Dictionary<string, TabLayout>();

        public IRCApp()
        {
            InitializeComponent();
        }

        private void IRCApp_Load(object sender, EventArgs e)
        {
            // Show connection dialog
            ConnectForm connectDialog = new ConnectForm();
            connectDialog.ShowDialog();

            // Fetch the client object...
            client = connectDialog.client;

            // Register client events...
            client.SelfJoinedChannel += Client_SelfJoinedChannel;
            client.GotGeneralMessage += Client_GotGeneralMessage;

            // And get connected.
            client.Connect();

            // Initialize the status tab...
            StatusTabControl = new TabLayout(client, null);
            StatusTabControl.TopLevel = false;
            StatusTab.Controls.Add(StatusTabControl);

            // And make it visible.
            StatusTabControl.Dock = DockStyle.Fill;
            StatusTabControl.Show();
        }

        private void Client_GotGeneralMessage(IrcMessage message)
        {
            // Event for when we recieve a status message from the server.
            BeginInvoke((Action)(() =>
            {
                StatusTabControl.DisplayText(message.trail);
            }));
        }

        private void Client_SelfJoinedChannel(IrcMessage message)
        {
            // When the client joins a new channel...
            BeginInvoke((Action)(() =>
            {
                // Grab the channel name
                string channel = message.args[0];
                // And pass it to a new tab...
                TabLayout newControl = new TabLayout(client, channel);
                // Then add this new tab to our dictionary.
                Tabs[channel] = newControl;

                // Then we add the TabLayout to the tab control...
                newControl.TopLevel = false;
                var newtab = new TabPage(channel);
                tabControl1.TabPages.Add(newtab);
                // And make it visible.
                newtab.Controls.Add(newControl);
                newControl.Dock = DockStyle.Fill;
                newControl.Show();

            }));

        }

    }
}
