using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XmppXamarinTest.Xmpp;

namespace XmppXamarinTest
{
    public partial class MainPage : ContentPage
    {
        readonly IXmppManager _manager = DependencyService.Get<IXmppManager>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            _manager.AvailabilityChanged += a => Availability = a;
        }

        bool _isBusyRunning;
        public bool IsBusyRunning
        {
            get { return _isBusyRunning; }
            set
            {
                if (_isBusyRunning != value)
                {
                    _isBusyRunning = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotBusyRunning));
                }
            }
        }

        public bool IsNotBusyRunning => !IsBusyRunning;

        #region Status

        FriendAvailability _availability = FriendAvailability.Offline;
        public FriendAvailability Availability
        {
            get { return _availability; }
            set
            {
                if (_availability != value)
                {
                    FriendAvailability previousAvailability = _availability;
                    _availability = value;
                    OnPropertyChanged();

                    if (Availability == FriendAvailability.Online && previousAvailability == FriendAvailability.Offline)
                    {
                        
                    }
                }
            }
        }

        void RunButton_OnClicked(object sender, EventArgs e)
        {
            IsBusyRunning = true;
            Task.Run(() => _manager.Run()).ContinueWith(_ => IsBusyRunning = false);
        }

        void StopButton_OnClicked(object sender, EventArgs e)
        {
            IsBusyRunning = true;
            Task.Run(() => _manager.Stop()).ContinueWith(_ => IsBusyRunning = false);
        }

        #endregion

        #region Buddy



        #endregion
    }
}
