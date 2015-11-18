using Microsoft.Exchange.WebServices.Data;
using RoomAvabilityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RoomAvabilityAPI.EWS
{
     public class EwsRoomAvability
    {

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }




        private ExchangeService _service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);

        private string _username = string.Empty;
        private string _password = string.Empty;

        private int _meetingDuration = 30;


        public EwsRoomAvability(string username, string password)
        {
            _username = username;
            _password = password;

            _service.UseDefaultCredentials = true;
            _service.Credentials = new WebCredentials(_username, _password);
            _service.AutodiscoverUrl(_username, RedirectionUrlValidationCallback);
        }

        public List<RoomAvability> getAvability(string _roomName)
        {

            List<RoomAvability> avabilityList = new List<RoomAvability>();

            List<AttendeeInfo> attendees = new List<AttendeeInfo>();


            attendees.Add(new AttendeeInfo()
            {
                SmtpAddress = _roomName,
                AttendeeType = MeetingAttendeeType.Required
            });


            // Specify availability options.
            AvailabilityOptions myOptions = new AvailabilityOptions();
            myOptions.MeetingDuration = _meetingDuration;
            myOptions.RequestedFreeBusyView = FreeBusyViewType.FreeBusy;


            GetUserAvailabilityResults freeBusyResults = _service.GetUserAvailability(attendees,
                                                                     new TimeWindow(DateTime.Now, DateTime.Now.AddDays(1)),
                                                                         AvailabilityData.FreeBusy,
                                                                         myOptions);
            foreach (AttendeeAvailability availability in freeBusyResults.AttendeesAvailability)
            {
                Console.WriteLine(availability.Result);
                Console.WriteLine();
                foreach (CalendarEvent calendarItem in availability.CalendarEvents)
                {

                    RoomAvability avability = new RoomAvability();

                    avability.StartTime = calendarItem.StartTime;
                    avability.EndTime = calendarItem.EndTime;
                    avability.FreeBusyStatus = calendarItem.FreeBusyStatus.ToString();

                    if (calendarItem.Details != null)
                    {
                        avability.IsMeeting = calendarItem.Details.IsMeeting;
                        avability.IsPrivate = calendarItem.Details.IsPrivate;
                        avability.Location = calendarItem.Details.Location;
                        avability.Subject = calendarItem.Details.Subject;
                    }
                    avabilityList.Add(avability);

                }
            }

            return avabilityList;



        }
    }
}