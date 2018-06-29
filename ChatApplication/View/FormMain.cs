using ChatApplication.Custom;
using ChatDataModel;
using ClientSocket;
using GoogleDriveApiv3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.Primitives;
using System.IO;
using ChatApplication.Util;
using Ozeki.VoIP;
using PhoneCall;
using PhoneCall.Ozeki;

namespace ChatApplication.View
{
    public partial class FormMain : Form
    {
        private IClient _client;
        private ChatDataModel.Account _account;
        public IDictionary<string, FormChat> FormChatOpening = new Dictionary<string, FormChat>();
        public IDictionary<string, FormChatGroups> FormChatGroupsOpening = new Dictionary<string, FormChatGroups>();
        IAudioCall _call;
        private RadWaitingBar _waitingBar = null;
        bool videoOn = false;
        public FormMain()
        {
            InitializeComponent();
        }

        private void _radlvFriendList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                Thread thread = new Thread(delegate ()
                {
                    var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(((ChatDataModel.Account)e.Item.DataBoundItem).AvatarDriveID));
                    _radlvFriendList.Invoke(new MethodInvoker(delegate ()
                    {
                        e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 46);
                    }));
                });
                thread.Start();
            }
            catch
            {
                MessageBox.Show("không có kết nổi , xin kiểm tra lại internet!");
                _radlvFriendList_ItemDataBound(sender, e);
            }
        }

        void VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
           // e.VisualItem = new CustomItemListFriends();
        }

        public FormMain(IClient client, ChatDataModel.Account account)
        {
            InitializeComponent();
            //AddWaitingBar();
            _client = client;
            _account = account;
            Init();
            _client.OnNewRecieve += _client_OnNewRecieve;

            RegisPhoneLine();


        }

        private void RegisPhoneLine()
        {
            Thread thread = new Thread(delegate ()
            {
                _call = new OzekiAudioCall();
                _call.RegisterAccount(_account);
                _call.ConnectMedia();
                _call.SoftPhoneInComingCall += _call_SoftPhoneInComingCall;
                _call.CallStateChange += _call_CallStateChange;
                _call.FormVideoCallClose += _call_FormVideoCallClose;
            });
            thread.Start();
        }

        private void _call_FormVideoCallClose()
        {
            lock (this)
            {
                Instance._isVideoOn = false;
            }
        }

        private void _call_CallStateChange(MyCallState state)
        {
            if (state == MyCallState.Canceled)
            {
                lock (this)
                {
                    FormInComingCall f;
                    if (Instance.CommingCalls.TryGetValue(_call.GetCallId(), out f))
                    {
                        f.Close();
                    }
                    Instance.CommingCalls.Remove(_call.GetCallId());
                }
            }
            if (state == MyCallState.Answered && Instance._isVideoOn == false )
            {
                lock (this)
                {
                    Instance._isVideoOn = true;
                }
                Thread thread = new Thread(delegate ()
                {
                    _call.StartCamera();
                    _call.ConnectMedia();
                    _call.ShowFormCall();
                });
                thread.Start();
                /*
                lock (this)
                {
                    videoOn = Instance._isVideoOn;
                }
                if (!videoOn)
                {
                    lock (this)
                    {
                        Instance._isVideoOn = true;
                    }
                    Thread thread = new Thread(delegate ()
                    {
                        _call.StartCamera();
                        _call.ConnectMedia();
                        _call.ShowFormCall();
                    });
                    thread.Start();
                }
                */

            }
        }

        public void AddWaitingBar()
        {
            Thread thread = new Thread(delegate ()
            {
                RadWaitingBar waitingBar = new RadWaitingBar();
                waitingBar.Size = new Size(30, 30);
                waitingBar.Location = new Point(this.Width / 2, this.Height / 2);
                waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
                waitingBar.WaitingSpeed = 10;
                _radlvFriendList.Controls.Add(waitingBar);
                waitingBar.StartWaiting();
                _waitingBar = waitingBar;
            });
            thread.Start();
        }

        public void RemoveWatingBar()
        {
            _radlvFriendList.Invoke(new MethodInvoker(delegate ()
            {
                _radlvFriendList.Controls.Remove(_radlvFriendList);
            }));
        }

        private void _call_SoftPhoneInComingCall(string callerName)
        {
            Instance.InCommingCall = true;
            FormInComingCall formInComingCall = new FormInComingCall(_call, callerName);
            lock (this)
            {
                Instance.CommingCalls.Add(_call.GetCallId(), formInComingCall);
            }
            Thread thread = new Thread(delegate ()
            {
                formInComingCall.ShowDialog();
            });
            thread.Start();
        }

        private void _client_OnNewRecieve(byte opcode, ChatProtocol.Protocol.IProtocol ptc)
        {
            Thread thread = new Thread(delegate ()
            {
                var handle = ChatApplication.Handle.HandleFactory.CreateHandle(opcode);
                handle.Handling(ptc, this);
            });
            thread.Start();
        }

        private void Init()
        {
            _ptbChinhSua.BackColor = Color.FromArgb(0, 255, 255, 255);
            _ptbChinhSua.SizeMode = PictureBoxSizeMode.StretchImage;
            _lbUserName.Text = _account.Name;
            Thread thread = new Thread(delegate ()
            {
                var file = GoogleDriveFilesRepository.DownloadFile(_account.AvatarDriveID);
                _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                _ptbAvatar.Image = Image.FromStream(file);
            });
            thread.Start();

            _radlvFriendList.AllowEdit = false;
            _radlvFriendList.AllowRemove = false;
            _radlvFriendList.VisualItemCreating += VisualItemCreating;
            _radlvFriendList.ItemDataBound += _radlvFriendList_ItemDataBound;
            _radlvFriendList.ItemSize = new Size(_radlvFriendList.ItemSize.Width, 50);
            _radlvFriendList.ItemMouseClick += _radlvFriendList_ItemMouseClick;
            _radlvFriendList.ItemMouseDown += _radlvFriendList_ItemMouseDown;

            _btnCreateGroupChat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _btnCreateGroupChat.Click += _btnCreateGroupChat_Click;

            _btnAddFriend.Click += _btnAddFriend_Click;

            _radLVFriendRequest.ItemMouseClick += _radLVFriendRequest_ItemMouseClick;

            InitGroupsChat();

            InitListFriendRequest();

            if (!_client.IsSending)
            {
                SendRequestGetListGroup();
            }

            if (!_client.IsSending)
                _client.RequestGetListFriendRequest(_account.Email);
            if (!_client.IsSending)
                _client.RequsetGetListFriend(_account.Email);


            _client.RequestGetListFriendIRequest(_account.Email);
        }

        private void _radlvFriendList_ItemMouseDown(object sender, ListViewItemMouseEventArgs e)
        {
            if (e.OriginalEventArgs.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem cancelFriend = new ToolStripMenuItem();
                cancelFriend.Text = "Hủy kết bạn";
                cancelFriend.Click += delegate
                {
                     var dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa " + ((ChatDataModel.Account)e.Item.DataBoundItem).Name + " khỏi danh sách bạn bè?", "Cảnh báo!", MessageBoxButtons.OKCancel);
                     if (dialogResult == DialogResult.OK) { _client.RequetsDeleteFriend(_account.Email, ((ChatDataModel.Account)e.Item.DataBoundItem).Email);
                         _radlvFriendList.Items.Remove(e.Item);
                     }
                };
                menu.Items.Add(cancelFriend);
                menu.Show(_radlvFriendList, e.OriginalEventArgs.Location);
            }
            if(e.OriginalEventArgs.Button == MouseButtons.Left)
            {
                OpenFormChat(e.Item.Value.ToString());
            }
        }

        private void _radLVFriendRequest_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            var dialogResult = MessageBox.Show(((ChatDataModel.Account)e.Item.DataBoundItem).Name + " đã gửi một lời mời kết bạn!", "Lời mời kết bạn", MessageBoxButtons.YesNoCancel);
            // isAccept = 1 là đồng ý
            // isAccept = 0 là hủy
            int isAccept = -1;
            if (dialogResult == DialogResult.Yes)
            {
                isAccept = 1;
            }
            else if(dialogResult == DialogResult.No)
            {
                isAccept = 0;
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            _client.RequestAcceptAddFriend(isAccept, ((ChatDataModel.Account)e.Item.DataBoundItem).Email, _account.Email);
            _radLVFriendRequest.Items.Remove(e.Item);
            UpdateFriendRequestCount(_radLVFriendRequest.Items.Count);
        }

        private void InitListFriendRequest()
        {
            _radLVFriendRequest.AllowEdit = false;
            _radLVFriendRequest.AllowRemove = false;
            _radLVFriendRequest.ItemSize = new Size(_radLVFriendRequest.Size.Width - 3, 45);
            _radLVFriendRequest.ItemDataBound += _radLVFriendRequest_ItemDataBound;
        }

        private void _radLVFriendRequest_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                var image = Image.FromStream(GoogleDriveFilesRepository.DownloadFile(((ChatDataModel.Account)e.Item.DataBoundItem).AvatarDriveID));
                _radlvFriendList.Invoke(new MethodInvoker(delegate ()
                {
                    e.Item.Image = ImageConverter.ImageResize.ResizeImageCircle(image, 42);
                }));
            });
            thread.Start();
        }

        private void _btnAddFriend_Click(object sender, EventArgs e)
        {
            FormFindFriends form = new FormFindFriends(_client);
            form.ShowDialog();
        }

        private void _btnCreateGroupChat_Click(object sender, EventArgs e)
        {
            FormCreateGroup formCreateGroup = new FormCreateGroup(_client);
            formCreateGroup.ShowDialog();
        }

        private void InitGroupsChat()
        {
            _radLVGroupChat.AllowEdit = false;
            _radLVGroupChat.AllowRemove = false;
            _radLVGroupChat.ItemSpacing = 5;
            _radLVGroupChat.ShowGridLines = true;
            _radLVGroupChat.ItemSize = new Size(_radLVGroupChat.ItemSize.Width, 50);
            _radLVGroupChat.ItemMouseClick += _radLVGroupChat_ItemMouseClick;
        }


        //click vào item trong groupChat
        private void _radLVGroupChat_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {

            MessageBox.Show(e.Item.Value.ToString());
            OpenFormChatGroup(e.Item.Value.ToString());
        }

        private void _radlvFriendList_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            
        }

        public void OpenFormChat(string email)
        {
            var form = GetFormChatOpening(email);
            if (form != null)
            {
                form.Invoke(new MethodInvoker(delegate ()
                {
                    form.Activate();
                }));
                return;
            }
            var formChat = new FormChat(_client, GetAccountFromFriendList(email),_call);
            formChat.OnClose += Form_OnClose;
            Thread thread = new Thread(delegate ()
            {
                lock (this)
                {
                    FormChatOpening.Add(email, formChat);
                }
                formChat.ShowDialog();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public void OpenFormChatGroup(string groupId)
        {
            FormChatGroups formChatGroup;
            if(FormChatGroupsOpening.TryGetValue(groupId, out formChatGroup))
            {
                formChatGroup.Invoke(new MethodInvoker(delegate ()
                {
                    formChatGroup.Activate();
                }));

                return;
            }

            formChatGroup = new FormChatGroups(_client, GetGroupFromListGroup(groupId));
            formChatGroup.Close += FormChatGroup_Close;
            Thread thread = new Thread(delegate ()
            {
                lock (this)
                {
                    FormChatGroupsOpening.Add(groupId, formChatGroup);
                }
                formChatGroup.ShowDialog();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void FormChatGroup_Close(string email)
        {
            FormChatGroupsOpening.Remove(email);
        }

        private void Form_OnClose(string groupId)
        {
            FormChatOpening.Remove(groupId);
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FindForm().Close();
        }
        
        private void _ptbChinhSua_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose Image";
            dialog.Filter= "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.InitialDirectory + @"\" + dialog.FileName;
                var fileID = GoogleDriveFilesRepository.UploadFile(path.Substring(1));
                _client.RequestUpdateAvatar(_account.Email, fileID);
            }
        }

        public void UpdateAvatar(string driveFileId)
        {
            Thread thread = new Thread(delegate ()
            {
                    var file = GoogleDriveFilesRepository.DownloadFile(driveFileId);
                    _ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                    _ptbAvatar.Image = Image.FromStream(file);
            });
            thread.Start();
        }

        public PictureBox GetPictureBoxAvatar()
        {
            return _ptbAvatar;
        }

        public void LoadFriendList(List<ChatDataModel.Account> accounts)
        {
            BindingList<ChatDataModel.Account> listUser = new BindingList<ChatDataModel.Account>();
            foreach (var item in accounts)
            {
                listUser.Add(item);
            }
            _radlvFriendList.DataSource = listUser;
            _radlvFriendList.DisplayMember = "Name";
            _radlvFriendList.ValueMember = "Email";
            
        }

        public void LoadGroupList(List<Group> groups)
        {
            BindingList<Group> listGroup = new BindingList<Group>();
            foreach(var item in groups)
            {
                listGroup.Add(item);
            }
            _radLVGroupChat.DataSource = listGroup;
            _radLVGroupChat.DisplayMember = "Name";
            _radLVGroupChat.ValueMember = "Id";
        }

        private FormChat GetFormChatOpening(string key)
        {
            foreach(var item in FormChatOpening)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        private ChatDataModel.Account GetAccountFromFriendList(string email)
        {
            foreach(var item in Instance.ListFriends)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        private Group GetGroupFromListGroup(string groupId)
        {
            foreach(var item in Instance.ListGroups)
            {
                if (item.Id == groupId)
                {
                    return item;
                }
            }
            return null;
        }

        public void SendRequestGetListGroup()
        {
            lock (this)
            {
                _client.RequestGetGroup(_account.Email);
            }
        }

        public void SendRequestGetUserInGroup(string groupId)
        {
            _client.RequestGetUserInGroup(_account.Email, groupId);
            /*FormChatGroups form;
            FormChatGroupsOpening.TryGetValue(groupId, out form);
            form.Refresh();*/
        }

        public void RemoveGroup(string groupId)
        {
            foreach(var item in Instance.ListGroups)
            {
                if (item.Id == groupId)
                {
                    Instance.ListGroups.Remove(item);
                    break;
                }
            }
            LoadGroupList(Instance.ListGroups);
        }

        public void LoadListUserFriendRequest(List<ChatDataModel.Account> accounts)
        {
            BindingList<ChatDataModel.Account> list = new BindingList<ChatDataModel.Account>();
            foreach(var item in accounts)
            {
                list.Add(item);
            }
            _radLVFriendRequest.DataSource = list;
            _radLVFriendRequest.DisplayMember = "Name";
            _radLVFriendRequest.ValueMember = "Id";
        }

        public void UpdateFriendRequestCount(int number)
        {
            if (number > 0)
                _tabPageFriendRequest.Text = "(" + number + ") Lời mời kết bạn";
            else _tabPageFriendRequest.Text = "Lời mời kết bạn";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Logout(_account.Email);
           foreach(var item in this.OwnedForms)
            {
                item.Close();
            }
        }
    }
}
