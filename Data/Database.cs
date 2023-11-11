using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorAppMySQL.Data
{
    public class Database
    {
        private readonly string MySQLConnectionString;

        public Database()
        {
            MySQLConnectionString = "Server= 127.0.0.1; Database=employeeDB; Uid=root; pwd= ;";
        }

        public DataTable MySQLConnection_Datatable()
        {
            DataTable dtDaten = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand SelectCommand = new MySqlCommand("Select * from employee LIMIT 15 ",conn);

                using (MySqlDataReader rdr = SelectCommand.ExecuteReader())
                {
                    dtDaten.Load(rdr);
                }
                conn.Close();
            }
            return dtDaten;
        }

        public DataTable GetProductData()
        {
            DataTable dtData = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM product", conn);

                using (MySqlDataReader rdr = selectCommand.ExecuteReader())
                {
                    dtData.Load(rdr);
                }
                conn.Close();
            }

            return dtData;
        }

          public DataTable GetSupplierData()
        {
            DataTable dtsupplier = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM supplier", conn);

                using (MySqlDataReader rdr = selectCommand.ExecuteReader())
                {
                    dtsupplier.Load(rdr);
                }
                conn.Close();
            }

            return dtsupplier;
        }

        public DataTable GetDepartmentData()
{
   DataTable dtdepartment = new DataTable();

using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
{
    conn.Open();

    MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM department d JOIN employee e ON e.emp_no = d.emp_no ORDER BY d.dp_id", conn);

    using (MySqlDataReader rdr = selectCommand.ExecuteReader())
    {
        dtdepartment.Load(rdr);
    }

    conn.Close();
}

return dtdepartment;

    }
}
}
