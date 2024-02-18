using System.Threading;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace miniCRM.Models
{
    public class Workers
    {
        public string db = "server=localhost;user=root;database=miniCRM;password=root;";
        public void GetWorkers(ref List<WorkersList> listWorkers)
        {
            
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = @"SELECT
                            workers.ID,
                            workers.FIO,
                            workers.WORK,
                            (SELECT COUNT(*)    FROM tasks WHERE workers.ID = tasks.id_worker ) as TASKS,
                            (SELECT COUNT(*)    FROM tasks WHERE workers.ID = tasks.id_worker and READY = 100 ) as TASKS_READY
                            FROM workers, tasks GROUP BY workers.ID ";

            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string fio = (string)reader["FIO"];
                    string work = (string)reader["WORK"];
                    int tasks = Convert.ToInt32(reader["TASKS"]);
                    int tasks_ready = Convert.ToInt32(reader["TASKS_READY"]);
                    double p = 0;
                    if (tasks == 0) { p = 0; } else {  p = Convert.ToDouble(tasks_ready) / Convert.ToDouble(tasks); }
                    
                    int ready = Convert.ToInt32(p*100);
                    listWorkers.Add(new WorkersList(id, fio , work, tasks, ready));

                }
            }




            conn.Close();

        }
        public void Add(string fio, string work)
        {

            
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            
            conn.Open();
            
            string sql = @"INSERT INTO WORKERS(FIO, WORK) 
                            VALUES('" + fio + "','" + work +  "')";
           
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteReader();



            conn.Close();

        }
        public void Edit(int id, string fio, string work)
        {
           
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            
            conn.Open();
            
            string sql = "UPDATE WORKERS SET FIO ='" + fio + "', WORK ='" + work + "' WHERE ID = " + id + "";
            
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            
            command.ExecuteReader();



            conn.Close();
        }
        public void Delete(int id)
        {

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = "DELETE FROM WORKERS WHERE ID = " + id;
            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteReader();



            conn.Close();
        }
        public void Auth(ref List<User> listUsers, int id, string password)
        {


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(db);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = @"SELECT
                            workers.ID,
                            workers.FIO,
                            users.ID,
                            users.PASSWORD
                            
                            FROM workers, users  where users.ID = '" + id +"' and users.ID = workers.ID and users.PASSWORD = '"+ password + "'";

            // объект для выполнения SQL-запроса
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    string name = (string)reader["FIO"];
                    listUsers.Add(new User(id, name));


                }
            }




            conn.Close();
        }
    }
}

