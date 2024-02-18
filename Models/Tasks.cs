using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;

namespace miniCRM.Models
{
    public class Tasks
    {
        public string db = "server=localhost;user=root;database=miniCRM;password=root;";
        public void GetTasks(ref List<TasksList> listTasks, int id_)
        {


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = @"SELECT
                            TASKS.ID,
                            TASKS.ID_WORKER,
                            TASKS.NAME,
                            TASKS.DATE_START,
                            TASKS.DATE_END,
                            TASKS.READY,
                            WORKERS.FIO as WORKER from TASKS, WORKERS Where workers.id = tasks.id_worker AND tasks.id_worker = " + id_;

            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string worker = (string)reader["WORKER"];
                    string name = (string)reader["NAME"];
                    DateTime date_start1 = (DateTime)reader["DATE_START"];
                    string date_start = date_start1.ToString("yyyy-MM-dd");
                    DateTime date_end1 = (DateTime)reader["DATE_END"];
                    string date_end = date_end1.ToString("yyyy-MM-dd");
                    int ready = (int)reader["ready"];

                    listTasks.Add(new TasksList(id, worker, name, date_start, date_end, ready));

                }
            }




            conn.Close();

        }

        public void Report(ref List<ReportList> listReport)
        {

            DateTime now1 = DateTime.Now;
            string now = now1.ToString("yyyy-MM-dd");

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = @"SELECT
                            TASKS.ID,
                            TASKS.ID_WORKER,
                            TASKS.NAME,
                            TASKS.DATE_START,
                            TASKS.DATE_END,
                            TASKS.READY,
                           
                            WORKERS.FIO as WORKER from TASKS, WORKERS WHERE  workers.id = tasks.id_worker and TASKS.READY < 100 AND TASKS.DATE_END < '" + now +"'";

            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string worker = (string)reader["WORKER"];
                    string name = (string)reader["NAME"];
                    DateTime date_start1 = (DateTime)reader["DATE_START"];
                    string date_start = date_start1.ToString("dd.MM.yyyy");
                    DateTime date_end1 = (DateTime)reader["DATE_END"];
                    string date_end = date_end1.ToString("dd.MM.yyyy");
                    int ready = (int)reader["ready"];
                    DateTime now2 = DateTime.Now;
                    TimeSpan ts = now2 - date_end1;
                    int days = Math.Abs(ts.Days);
                    
                    listReport.Add(new ReportList(id, worker, name, date_start, date_end, ready, days));

                }
            }




            conn.Close();

        }
        public void Add(int id, string name, DateTime date1)
        {
            
            DateTime nows = DateTime.Now;
            string now = nows.ToString("yyyy-MM-dd");
            string date = date1.ToString("yyyy-MM-dd");
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = @"INSERT INTO TASKS(ID_WORKER, NAME, DATE_START, DATE_END ) 
                            VALUES('" + id + "','" + name + "','" + now + "', '" + date + "')";
            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteReader();



            conn.Close();

        }

        public void Edit(int id, string name, DateTime start, DateTime end, int ready)
        {
            string start1 = start.ToString("yyyy-MM-dd");
            string end1 = end.ToString("yyyy-MM-dd");
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "UPDATE TASKS SET NAME='" + name + "', DATE_START='" + start1 + "', DATE_END = '" + end1 + "', READY = '" + ready + "' WHERE ID = " + id + "";
            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteReader();



            conn.Close();
        }
        public void Delete(int id)
        {
            
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "DELETE FROM TASKS WHERE ID = " + id ;
            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteReader();



            conn.Close();
        }
        public void Reportred()
        {
            
                DateTime now1 = DateTime.Now;
                string now = now1.ToString("yyyy-MM-dd");

                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
                // устанавливаем соединение с БД
                conn.Open();
                // запрос
                string sql = @"SELECT
                            TASKS.ID,
                            TASKS.ID_WORKER,
                            TASKS.NAME,
                            TASKS.DATE_START,
                            TASKS.DATE_END,
                            TASKS.READY,
                           
                            WORKERS.FIO as WORKER from TASKS, WORKERS WHERE  workers.id = tasks.id_worker and TASKS.READY < 100 AND TASKS.DATE_END < '" + now + "'";

                // объект для выполнения SQL-запроса
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = true,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 2
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;


                    app.Workbooks.Open(@"C:\Users\PC\source\repos\miniCRM\miniCRM\Maket\Excel.xlsx",
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                      Type.Missing, Type.Missing);
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Отчет";
                    
                     int line = 3;
                    while (reader.Read())
                        {
                            int id = (int)reader["ID"];
                            string worker = (string)reader["WORKER"];
                            string name = (string)reader["NAME"];
                            DateTime date_start1 = (DateTime)reader["DATE_START"];
                            string date_start = date_start1.ToString("dd.MM.yyyy");
                            DateTime date_end1 = (DateTime)reader["DATE_END"];
                            string date_end = date_end1.ToString("dd.MM.yyyy");
                            int ready = (int)reader["ready"];
                            DateTime now2 = DateTime.Now;
                            TimeSpan ts = now2 - date_end1;
                            int days = Math.Abs(ts.Days);
                            
                            
                       
                            sheet.Range["A" +line].Value = worker;
                            sheet.Range["B" + line].Value = name;
                            sheet.Range["C" + line].Value = date_start;
                            sheet.Range["D" + line].Value = date_end;
                            sheet.Range["E" + line].Value = ready;
                            sheet.Range["F" + line].Value = days;
                            //sheet.get_Range("A2").Value2 = "Пример №3";
                    
                            

                            line++;
                        }
                        sheet.PrintOut();
                        app.Application.ActiveWorkbook.SaveAs(@"C:\Users\PC\source\repos\miniCRM\miniCRM\Maket\Report.xlsx", Type.Missing,
                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                        app.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    }




                    conn.Close();

            
        }
    }
}
