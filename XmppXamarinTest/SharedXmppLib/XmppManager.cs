using Sharp.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Sharp.Xmpp;
using Sharp.Xmpp.Im;
using XmppXamarinTest;
using XmppXamarinTest.Xmpp;

[assembly: Xamarin.Forms.Dependency(typeof(SharedXmppLib.XmppManager))]
namespace SharedXmppLib
{
    public class XmppManager : IXmppManager, INotifyPropertyChanged
    {
        readonly XmppClient _client;
        Jid _me;
        readonly Jid _room = new Jid("conference.xmpp.jp", "team8room2");

        public event Action<FriendAvailability> AvailabilityChanged;
        public event Action<ObservableCollection<Friend>> FriendsChanged;

        public XmppManager()
        {
            _client = new XmppClient("xmpp.jp", "team8test2", "team8proj");
            _client.Message += Client_Message;
            _client.StatusChanged += ClientOnStatusChanged;
            _client.RosterUpdated += _client_RosterUpdated;
            _client.ActivityChanged += _client_ActivityChanged;
            _client.GroupInviteReceived += _client_GroupInviteReceived;
            _client.GroupPresenceChanged += _client_GroupPresenceChanged;
        }

        public void Run()
        {
            if (!_client.Connected)
            {
                _client.Hostname = "xmpp.jp"; // Fix bug that hostname not resolved from ctor
                _client.Connect();
                _me = _client.Jid;
            }
        }

        void ClientOnStatusChanged(object sender, StatusEventArgs statusEventArgs)
        {
            if (statusEventArgs.Jid.Equals(_me))
            {
                AvailabilityChanged?.Invoke((FriendAvailability) (int) statusEventArgs.Status.Availability);
            }
            else if()
            {
                
            }
        }

        public ObservableCollection<Friend> GetFriends()
        {
            var roaster = _client.GetRoster();
            return new ObservableCollection<Friend>(roaster.Select(r =>
            {
                if (r.SubscriptionState == SubscriptionState.None || r.SubscriptionState == SubscriptionState.From)
                {
                    _client.Im.RequestSubscription(r.Jid);
                }
                return new Friend
                {

                    FullName = $"n:{r.Name}, id:{r.Jid.ToString()}",
                    Availability = FriendAvailability.Offline
                };
            }));
        }


        public void Stop()
        {
            if (_client.Connected)
            {
                _client.Close();
            }
        }

        void _client_GroupPresenceChanged(object sender, Sharp.Xmpp.Extensions.GroupPresenceEventArgs e)
        {

        }

        void _client_GroupInviteReceived(object sender, Sharp.Xmpp.Extensions.GroupInviteEventArgs e)
        {
            _client.JoinRoom(e.ChatRoom, "xamarin.android");
        }

        void _client_ActivityChanged(object sender, Sharp.Xmpp.Extensions.ActivityChangedEventArgs e)
        {
        }

        void _client_RosterUpdated(object sender, Sharp.Xmpp.Im.RosterUpdatedEventArgs e)
        {
            
        }

        void Client_Message(object sender, Sharp.Xmpp.Im.MessageEventArgs e)
        {
            var test = e.Jid.GetBareJid();
            if (test.ToString() == _room.ToString())
            {
                _client.SendMessage(test, $"feedback @ {DateTime.Now}", type: MessageType.Groupchat);
            }
            else
            {
                _client.SendMessage(test, $"feedback @ {DateTime.Now}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
