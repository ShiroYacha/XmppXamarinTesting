using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmppXamarinTest.Xmpp
{
    public enum FriendAvailability
    {
        /// <summary>
        /// The user or resource is offline and unavailable.
        /// </summary>
        Offline,

        /// <summary>
        /// The user or resource is online and available.
        /// </summary>
        Online,

        /// <summary>
        /// The user or resource is temporarily away.
        /// </summary>
        Away,

        /// <summary>
        /// The user or resource is actively interested in chatting.
        /// </summary>
        Chat,

        /// <summary>
        /// The user or resource is busy.
        /// </summary>
        Dnd,

        /// <summary>
        /// The user or resource is away for an extended period.
        /// </summary>
        Xa
    }
}
