﻿using System;
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
        //static Image img = Image.FromFile(@"‪C:\Users\DELL\Downloads\avartar.jpg");
        Author author = new Author(null, "Đức");
        public FormChat()
        {
            InitializeComponent();
            _rcChatlog.ChatElement.SendButtonElement.Click += SendButtonElement_Click;
            
            //_rcChatlog.ChatElement.SendButtonElement.
            //_rcChatlog.AutoAddUserMessages = false;
            _rcChatlog.Author = author;
            //Bitmap bm = new Bitmap(Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg"));
            //_rcChatlog.Author.Avatar = bm;
            /*RadImageItem img = new RadImageItem();
            img.Image = Image.FromFile("‪‪D:\\ThucTap\\avartar.jpg");*/
            _rcChatlog.ChatElement.InputTextBox.AddBehavior(new Telerik.WinControls.PropertyChangeBehavior()
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
