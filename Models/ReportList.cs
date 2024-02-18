namespace miniCRM.Models
{
    public class ReportList
    {
        public int Id { get; set; }
        public string Worker { get; }
        public string Name { get; }
        public string Date_Start { get; }
        public string Date_End { get; }

        public int Ready { get; }
        public int Days { get; }

        public ReportList(int id, string worker, string name, string date_start, string date_end, int ready, int days)
        {
            Id = id;
            Worker = worker;
            Name = name;
            Date_Start = date_start;
            Date_End = date_end;
            Ready = ready;
            Days = days;
        }

    }
}
