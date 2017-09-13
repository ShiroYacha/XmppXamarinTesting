using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Sharp.Xmpp.Client;

namespace XmppXamarinTest.Droid
{
    [Activity(Label = "XmppXamarinTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            using (var client = new XmppClient("xmpp.jp", "team8test", "team8ladivine"))
            {
                client.Hostname = "xmpp.jp";
                client.Connect();
                Console.WriteLine("Connected as " + client.Jid);
                Console.WriteLine(" Type 'send <JID> <Message>' to send a chat message, or 'quit' to exit.");
                Console.WriteLine(" Example: send user@domain.com Hello!");
                Console.WriteLine();
            }
        }
    }
}

