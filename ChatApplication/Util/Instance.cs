using ChatApplication.View;
using ChatDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Util
{
    public class Instance
    {
        public static Account CurrentUser = new Account();
        public static List<Account> ListFriends = new List<Account>();
        public static List<Group> ListGroups = new List<Group>();
        public static List<Account> ListUserAskAddFriend = new List<Account>();
        public static bool InCommingCall = false;
        public static Dictionary<string, FormInComingCall> CommingCalls = new Dictionary<string, FormInComingCall>();
        public static bool _isVideoOn = false;
    }
}
