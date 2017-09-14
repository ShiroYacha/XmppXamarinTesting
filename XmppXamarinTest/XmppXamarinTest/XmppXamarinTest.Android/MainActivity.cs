using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Sharp.Xmpp;
using Sharp.Xmpp.Client;
using Sharp.Xmpp.Im;

namespace XmppXamarinTest.Droid
{
    [Activity(Label = "XmppXamarinTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static XmppClient _client = new XmppClient("xmpp.jp", "team8test2", "team8proj");
        Jid _room = new Jid("conference.xmpp.jp", "team8room2");

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            //SharedXmppLib.Test.Run();

            //return;

            _client.Hostname = "xmpp.jp";
            _client.Message += Client_Message;
            _client.RosterUpdated += _client_RosterUpdated;
            _client.ActivityChanged += _client_ActivityChanged;
            _client.GroupInviteReceived += _client_GroupInviteReceived;
            _client.GroupPresenceChanged += _client_GroupPresenceChanged;
            _client.Connect();
            var roster = _client.GetRoster();
            _client.JoinRoom(_room, "xamarin.android.tentative");
        }

        private void _client_GroupPresenceChanged(object sender, Sharp.Xmpp.Extensions.GroupPresenceEventArgs e)
        {
        }

        private void _client_GroupInviteReceived(object sender, Sharp.Xmpp.Extensions.GroupInviteEventArgs e)
        {
            _client.JoinRoom(e.ChatRoom, "xamarin.android");
        }

        private void _client_ActivityChanged(object sender, Sharp.Xmpp.Extensions.ActivityChangedEventArgs e)
        {
        }

        private void _client_RosterUpdated(object sender, Sharp.Xmpp.Im.RosterUpdatedEventArgs e)
        {
        }

        private void Client_Message(object sender, Sharp.Xmpp.Im.MessageEventArgs e)
        {
            var test = e.Jid.GetBareJid();
            if (test.ToString() == _room.ToString())
            {
                _client.SendMessage(test, $"feedback @ {DateTime.Now}", type:MessageType.Groupchat);
            }
            else
            {
                _client.SendMessage(test, $"feedback @ {DateTime.Now}");
            }
        }
    }
}

