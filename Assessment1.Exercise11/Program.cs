using Assessment1.Exercise11;

Console.WriteLine("Welcome to the Meeting Planner");

Meeting meeting = new Meeting(new Organizer("FirstNameOrganizer", "LastNameOrganizer"));

List<IAtendee> atendees = new List<IAtendee>()
{
    new Atendee("FirstName1", "LastName1"),
    new Atendee("FirstName2", "LastName2"),
    new Atendee("FirstName3", "LastName3"),
};

meeting.InviteAtendees(atendees);