using ChatDAO;
using ChatDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AccountDAOSQL account = new AccountDAOSQL();
           Account acc = account.GetAccount("ngocdung@gmail.com");
            pictureBox1.Image = acc.Avatar;
        }
    }
}
