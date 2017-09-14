using Sharp.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedXmppLib
{
    public class Test
    {
        public static void Run()
        {
            using (var client = new XmppClient("xmpp.jp", "team8test2", "team8proj"))
            {
                client.Hostname = "xmpp.jp";
                client.Connect();
                
            }
        }
    }
}
