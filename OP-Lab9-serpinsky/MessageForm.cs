using System;
using System.Windows.Forms;

namespace OP_Lab9_serpinsky
{
    public partial class MessageForm : Form
    {
        public MessageForm(string message)
        {
            InitializeComponent();
            textBoxMessage.Text = message;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
