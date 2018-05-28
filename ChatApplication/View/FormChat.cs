using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ChatApplication.View
{
    public partial class FormChat : Form
    {
        Author author = new Author(null, "Đức");
        public FormChat()
        {
            InitializeComponent();
            _rcChatlog.ChatElement.SendButtonElement.Click += SendButtonElement_Click;
            
            //_rcChatlog.ChatElement.SendButtonElement.
            //_rcChatlog.AutoAddUserMessages = false;
            _rcChatlog.Author = author;
        }
        

        private void SendButtonElement_Click(object sender, EventArgs e)
        {
            /*Author author = new Author(null, "Tèo");
            string text = _rcChatlog.ChatElement.InputTextBox.Text;
            MessageBox.Show(text);
            ChatTextMessage chat = new ChatTextMessage("hello", _rcChatlog.Author, DateTime.Now);
           
            _rcChatlog.AddMessage(chat);*/
            
        }
    }
}
