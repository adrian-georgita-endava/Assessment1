using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise11
{
    public interface IEvent
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool HasEveryoneAccepted { get; set; }
        public List<IAtendee> Attendees { get; set; }
        public List<IAtendee> Invitees { get; set; }
        public IAtendee Organizer { get; set; }
        public void AddAtendee(IAtendee atendee);
        public void RemoveAtendee(IAtendee atendee);
        public void InviteAtendees(List<IAtendee> atendees);
        public void StartWithAtendeesOnly();
        public void NotifyAtendees();
    }
}
