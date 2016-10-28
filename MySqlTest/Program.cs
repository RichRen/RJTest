using System.Data;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = MySqlHelper.ExecuteTable("SELECT * FROM app_lineups_race;");

            MySqlParameter[] parameters = {
                    new MySqlParameter("?race_name", MySqlDbType.String)
                    };
            parameters[0].Value = "啦啦啦啦啦";

            int i = MySqlHelper.ExecuteNonQuery(@"INSERT INTO `app_lineups_race`(`race_name`) VALUES(?race_name)", parameters);

        }
    }
}
