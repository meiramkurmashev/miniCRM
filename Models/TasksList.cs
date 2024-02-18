namespace miniCRM.Models
{
    public class TasksList
    {
        public int Id { get; set; }
        public string Worker { get; }
        public string Name { get; }
        public string Date_Start { get; }
        public string Date_End { get; }

        public int Ready { get; }


        public TasksList(int id, string worker, string name, string date_start, string date_end, int ready)
        {
            Id = id;
            Worker = worker;
            Name = name;
            Date_Start = date_start;
            Date_End = date_end;
            Ready = ready;

        }

    }
}
