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
    public partial class ConnectForm : Form
    {
        public IrcClient client;
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        { 
            string hostname = HostnameInput.Text;
            string nickname = NicknameInput.Text;
            string channel = AutojoinInput.Text;
            client = new IrcClient(nickname, hostname, channel);
            Close();
        }
    }
}
