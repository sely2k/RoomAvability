using System;
using Windows.ApplicationModel.Email;
using Windows.System;


namespace RoomAvability.ViewModels
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Tools.Dialogs;
    using Tools.Navigation;
    using Models;
    using System.Collections;
    using System.Linq;
    using Windows.UI.Xaml;
    using helper;
    using SPIDisplayLib;
    using Caliburn.Micro;

    public class MainPageViewModel : ViewModelBase
    {




        SSD1306 ssd1306 = new SSD1306();

        DispatcherTimer timer = new DispatcherTimer();
        RoomAvabilityAPI client = new RoomAvabilityAPI();


        protected override void OnDeactivate(bool close)
        {


            base.OnDeactivate(close);
            ssd1306.DisposeAll();
        }


        protected override async void OnActivate()
        {


            base.OnActivate();
            await ssd1306.InitAll();
            ssd1306.ClearDisplayBuf();
            ssd1306.DisplayUpdate();    /* Write our changes out to the display */

            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(00, 5, 0);
            bool enabled = timer.IsEnabled;
            timer.Start();

            ForceRefresh();
        }

        //IRoomAvabilityOperations RoomAvalibityList;



        private List<RoomAvabilityModel> _itms;
        public List<RoomAvabilityModel> Itms
        {
            get
            {
                return _itms;

            }
            set
            {
                _itms = value;
                NotifyOfPropertyChange(() => Itms);
            }
        }

        private bool _isLoaded;
        public bool IsLoaded
        {
            get
            {
                return _isLoaded;

            }
            set
            {
                _isLoaded = value;
                NotifyOfPropertyChange(() => IsLoaded);
            }
        }

        public MainPageViewModel(IPageNavigationService pageNavigationService, IUserNotificationService userNotificationService) : base(pageNavigationService)
        {


            this.UserNotificationService = userNotificationService;
            //this.PageNavigationService = pageNavigationService;


        }

        private async void InitAll()
        {
            await ssd1306.InitAll();

        }


        void timer_Tick(object sender, object e)
        {
            ForceRefresh();
        }


        public async void ForceRefresh()
        {
            IsLoaded = true;

            var lst = new List<RoomAvabilityModel>(await client.RoomAvability.GetAsync());
            Itms = RoomAvabilityHelper.getListOfAvability(lst);

            var FreeBusyStatusString = string.Format("{0} for next 30'",RoomAvabilityHelper.GetFreeBusy(lst));
            ssd1306.WriteLineDisplayBuf(FreeBusyStatusString, 0, 0);

            if (Itms != null && Itms.Count>0)
            {
                var NextMeeting = Itms.FirstOrDefault();
               
                var NextMeetingString = 
                    string.Format
                    (
                        "next: {0} for {1}", 
                        NextMeeting.StartTime.Value.ToString("hh:mm tt"),
                        NextMeeting.MeetingDuration
                    );
                ssd1306.WriteLineDisplayBuf(NextMeetingString, 0, 1);
            }


            ssd1306.DisplayUpdate();    /* Write our changes out to the display */
            IsLoaded = false;
        }

        public void ForceRefreshButton()
        {
            ForceRefresh();
        }

       




    }
}