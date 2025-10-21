using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise11
{
    public class Atendee : IAtendee
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        IEvent? CurrentEvent { get; set; }

        public Atendee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool RequestAnswer(IEvent @event)
        {
            Console.WriteLine($"{FirstName} {LastName}, you have been invited to a event on {@event.Date} at {@event.Time}, do you accept the invitation?");
            Console.Write("yes/no: ");
            string? answer = Console.ReadLine();
            while (string.IsNullOrEmpty(answer) || !new List<string> { "yes", "no" }.Contains(answer.ToLower()))
            {
                Console.WriteLine("Invalid answer! Please enter 'yes' or 'no'");
                Console.Write("yes/no: ");
                answer = Console.ReadLine();
            }

            return answer == "yes" ? true : false;
        }

        public void Update(IEvent @event)
        {
            CurrentEvent = @event;
            if (CurrentEvent == null)
            {
                return;
            }

            if (CurrentEvent.HasEveryoneAccepted)
            {
                Console.WriteLine($"{FirstName} {LastName}, you have an event scheduled on: {CurrentEvent.Date} at {CurrentEvent.Time}");
            }
        }
    }
}
