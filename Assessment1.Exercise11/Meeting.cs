using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise11
{
    public class Meeting : IEvent
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool HasEveryoneAccepted { get; set; }
        public List<IAtendee> Attendees { get; set; } = new();
        public List<IAtendee> Invitees { get; set; } = new();

        public IAtendee Organizer { get; set; }

        private int _acceptedInvitations;

        public Meeting(IAtendee organizer)
        {
            Setup();
            Attendees = new List<IAtendee>();
            HasEveryoneAccepted = false;
            _acceptedInvitations = 0;
            Organizer = organizer;
        }

        public void AddAtendee(IAtendee person) => Attendees.Add(person);
        public void RemoveAtendee(IAtendee person) => Attendees.Remove(person);

        public void InviteAtendees(List<IAtendee> invitees)
        {
            Invitees = invitees;
            foreach (var invitee in invitees)
            {
                if(invitee.RequestAnswer(this))
                {
                    _acceptedInvitations++;
                    AddAtendee(invitee);
                }
            }

            HasEveryoneAccepted = invitees.Count == _acceptedInvitations ? true : false;

            NotifyAtendees();
        }

        public void StartWithAtendeesOnly()
        {
            HasEveryoneAccepted = true;
            NotifyAtendees();
        }

        public void NotifyAtendees()
        {
            foreach(var atendee in Attendees)
            {
                atendee.Update(this);
            }

            Organizer.Update(this);
        }

        public void Setup()
        {
            Console.WriteLine("Please enter the meeting date in the DD.MM.YYYY format");
            DateOnly meetingDate;
            Console.Write("Meeting date: ");
            while (!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out meetingDate))
            {
                Console.WriteLine("Plese enter a valid date in the DD.MM.YYYY format!");
                Console.Write("Meeting date: ");
            }

            Date = meetingDate;

            Console.WriteLine("Please enter the meeting time in the hh:mm format");
            TimeOnly meetingTime;
            Console.Write("Meeting time: ");
            while (!TimeOnly.TryParseExact(Console.ReadLine(), "hh:mm", out meetingTime))
            {
                Console.WriteLine("Plese enter a meeting time in hh:mm format!");
                Console.Write("Meeting time: ");
            }

            Time = meetingTime;
        }
    }
}
