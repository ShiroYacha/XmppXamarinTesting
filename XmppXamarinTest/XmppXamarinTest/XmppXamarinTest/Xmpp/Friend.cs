using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmppXamarinTest.Xmpp
{
    public class Friend : ViewModelBase
    {
        string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        FriendAvailability _availability = FriendAvailability.Offline;
        public FriendAvailability Availability
        {
            get { return _availability; }
            set
            {
                if (_availability != value)
                {
                    _availability = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
