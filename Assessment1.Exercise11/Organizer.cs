using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise11
{
    public class Organizer : IAtendee
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        IEvent? CurrentEvent { get; set; }

        public Organizer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool RequestAnswer(IEvent @event) => true;

        public void Update(IEvent @event)
        {
            CurrentEvent = @event;
            if(CurrentEvent == null)
            {
                return;
            }

            if (CurrentEvent.HasEveryoneAccepted)
            {
                Console.WriteLine($"{FirstName} {LastName}, all invitees have accepted the invitations for the event scheduled on: {CurrentEvent.Date} at {CurrentEvent.Time}");
                return;
            }

            bool startAnyways = StartAnyways();
            if (startAnyways)
            {
                 @event.StartWithAtendeesOnly();
            }
        }

        private bool StartAnyways()
        {
            Console.WriteLine($"Some invitees have declined the invitation. Do you want to start the meeting without them?");
            string? answer;
            Console.Write("yes/no: ");
            answer = Console.ReadLine();
            while(string.IsNullOrEmpty(answer) || !new List<string> { "yes", "no" }.Contains(answer.ToLower()))
            {
                Console.WriteLine("Invalid answer! Please type either 'yes' or 'no'");
                Console.Write("yes/no: ");
                answer = Console.ReadLine();
            }

            return answer == "yes" ? true : false;
        }
    }
}
