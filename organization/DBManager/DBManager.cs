using BOL;
using MySql.Data.MySqlClient;

namespace DAL

{
    public class DBManager
    {
        public static string conString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> emplist = new List<Employee>();

            MySqlConnection con = new MySqlConnection();

            con.ConnectionString = conString;

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand();

                string query = "select * from employees";
                cmd.Connection = con;

                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["empname"].ToString();
                    string designation = reader["designation"].ToString();
                    string department = reader["department"].ToString();
                    string city = reader["city"].ToString() ;
                    double salary = double.Parse(reader["salary"].ToString());

                    Employee emp = new Employee {
                        Id = id,
                        Name = name,
                        Designation = designation,
                        Department = department,
                        City = city,
                        Salary = salary
                };

                    emplist.Add(emp);
                     
                }


            }
            catch(Exception e) {
            
                Console.WriteLine(e.Message);
            }
            finally { con.Close(); }

            return emplist;
        }


        public static void AddEmployee(Employee emp)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;

            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                string query = "insert into employees values('" + emp.Id + "','" + emp.Name + "','" + emp.Designation + "','" + emp.Department + "','" + emp.City + "','" + emp.Salary + "')";

                command.CommandText = query;
                command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


    }
}