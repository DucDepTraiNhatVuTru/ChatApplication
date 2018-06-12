using ChatApplication.Util;
using ChatDataModel;
using ClientSocket;
using GoogleDriveApiv3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ChatApplication.View
{
    public partial class FormChatGroups : Form
    {
        private IClient _client;
        private string _groupId = "";
        private Author _authorMe;
        private Account _me;
        private List<Author> _authorFriends = new List<Author>();

        public FormChatGroups()
        {
            InitializeComponent();
        }

        public FormChatGroups(IClient client, string groupID)
        {
            InitializeComponent();
            _client = client;
            _groupId = groupID;
            lock (this)
            {
                _me = Instance.CurrentUser;
            }
            _authorMe = new Author(null, _me.Name);
            LoadMyAvatar(_me.AvatarDriveID);
        }

        private void LoadMyAvatar(string fileId)
        {
            Stream result = null;
            Thread thread = new Thread(delegate ()
            {
                result = GoogleDriveFilesRepository.DownloadFile(fileId);
                _authorMe.Avatar = Image.FromStream(result);
            });
            thread.Start();
        }
    }
}
