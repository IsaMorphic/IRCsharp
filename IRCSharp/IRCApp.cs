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
    public partial class IRCApp : Form
    {
        public IRCApp()
        {
            InitializeComponent();
        }

        private void IRCApp_Load(object sender, EventArgs e)
        {
            var irc = new IrcClient("IRCsharp-client", 
                "chat.freenode.com", "#IRCsharp-testing");
            irc.Connect();
        }
    }
}
