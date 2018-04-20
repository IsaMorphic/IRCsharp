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
        private IrcClient client;
        private TabLayout StatusTabControl;
        private Dictionary<string, TabLayout> Tabs = new Dictionary<string, TabLayout>();
        public IRCApp()
        {
            InitializeComponent();
        }

        private void IRCApp_Load(object sender, EventArgs e)
        {
            ConnectForm connectDialog = new ConnectForm();
            connectDialog.ShowDialog();
            client = connectDialog.client;
            client.SelfJoinedChannel += Client_SelfJoinedChannel;
            client.GotGeneralMessage += Client_GotGeneralMessage;
            client.Connect();
            StatusTabControl = new TabLayout(client, null);
            StatusTabControl.TopLevel = false;
            StatusTab.Controls.Add(StatusTabControl);
            StatusTabControl.Dock = DockStyle.Fill;
            StatusTabControl.Show();
        }

        private void Client_GotGeneralMessage(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                StatusTabControl.DisplayText(message.trail);
            }));
        }

        private void Client_SelfJoinedChannel(IrcMessage message)
        {
            BeginInvoke((Action)(() =>
            {
                string channel = message.args[0];
                TabLayout newControl = new TabLayout(client, channel);
                Tabs[channel] = newControl;
                newControl.TopLevel = false;
                var newtab = new TabPage(channel);
                tabControl1.TabPages.Add(newtab);
                newtab.Controls.Add(newControl);
                newControl.Dock = DockStyle.Fill;
                newControl.Show();

            }));

        }

    }
}
