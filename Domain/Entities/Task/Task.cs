namespace TaskList.Domain.Entities.Task
{
    public class Task
    {
        public Task() { }

        public Task(Guid iD)
        {
            ID = iD;
        }

        public Task(string? taskdescription, DateTime dateadded, DateTime dateending, DateTime datedone, bool isdone)
        {
            TaskDescription = taskdescription;
            DateAdded = dateadded;
            DateEnding = dateending;
            DateDone = datedone;
            IsDone = isdone;
        }

        public Guid ID { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateEnding { get; set; }

        public DateTime DateDone { get; set; }

        public bool IsDone { get; set; }
    }
}
