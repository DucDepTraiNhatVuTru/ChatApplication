using ClientSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication.View
{
    public partial class FormFindFriends : Form
    {
        private IClient _client;
        public FormFindFriends()
        {
            InitializeComponent();
        }

        public FormFindFriends(IClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private void _btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_txtSearch.Text))
            {
                MessageBox.Show("Nhập tên hoặc email người bạn cần tìm!");
                return;
            }
            
        }
    }
}
