namespace miniCRM.Models
{
    public class WorkersList
    { 
            public int Id { get; set; }
            public string Fio { get; }
            public string Work { get; }

            public int Tasks { get; }
            public float Ready { get; }

        public WorkersList(int id, string fio, string work, int tasks, float ready)
            {
                Id = id;
                Fio = fio;
                Work = work;
                Tasks = tasks;
                Ready = ready;
            }

    }
}

