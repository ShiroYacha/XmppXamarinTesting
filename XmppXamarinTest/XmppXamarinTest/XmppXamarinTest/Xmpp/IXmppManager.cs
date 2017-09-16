using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace XmppXamarinTest.Xmpp
{
    public interface IXmppManager : INotifyPropertyChanged
    {
        event Action<FriendAvailability> AvailabilityChanged;
        event Action<ObservableCollection<Friend>> FriendsChanged;
        void Run();
        void Stop();
        ObservableCollection<Friend> GetFriends();
    }
}
