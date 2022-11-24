using Microsoft.Data.Sqlite;

namespace HabitTrackerLib.DB;

public class DBSqlite : IDbOperations
{
    private const string CON = "Data Source=habit.db";

    public DBSqlite()
    {
        InitDB();
    }

    public void AddHabit(Habit habit)
    {
        throw new NotImplementedException();
    }

    public void DeleteHabit()
    {
        throw new NotImplementedException();
    }

    public void EditHabit(Habit habit)
    {
        throw new NotImplementedException();
    }

    public bool IsHabitExists(string name)
    {
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var checkHabit = connection.CreateCommand();
            checkHabit.CommandText = @"
        SELECT habit_name FROM user
        WHERE user_name = @name AND habit_name IS NOT NULL
        ";
            SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text);
            nameParam.Value = name;
            checkHabit.Parameters.Add(nameParam);
            checkHabit.Prepare();
            using (SqliteDataReader reader = checkHabit.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public bool IsUserExists(string name)
    {
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var checkUser = connection.CreateCommand();
            checkUser.CommandText = @"
        SELECT * FROM user
        WHERE user_name = @name
        ";
            SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text);
            nameParam.Value = name;
            checkUser.Parameters.Add(nameParam);
            checkUser.Prepare();
            using (SqliteDataReader reader = checkUser.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }
    }

    public void AddUser(User user)
    {
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var createUser = connection.CreateCommand();
            createUser.CommandText = @"
        INSERT INTO user (user_name) VALUES(@name)
        ";
            SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text);
            nameParam.Value = user.Name;
            createUser.Parameters.Add(nameParam);
            createUser.Prepare();
            createUser.ExecuteNonQuery();
        }
    }

    private void InitDB()
    {

        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();

            var createTableUser = connection.CreateCommand();
            createTableUser.CommandText = @"
CREATE TABLE IF NOT EXISTS user(
user_id integer PRIMARY KEY,
user_name text ,
habit_name text ,
measurement text ,
quantity integer ,
description text
)";

            createTableUser.ExecuteNonQuery();


        }



    }
}
