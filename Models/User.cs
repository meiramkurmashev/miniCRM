using Microsoft.Office.Interop.Excel;

namespace miniCRM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        
        public User(int id, string fio)
        {
            Id = id;
            Fio = fio;
            

        }
    }
}
