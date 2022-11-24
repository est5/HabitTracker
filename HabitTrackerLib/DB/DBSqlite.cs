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

    public bool IsHabitExists()
    {
        throw new NotImplementedException();
    }

    private void InitDB()
    {

        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();

            var createTableHabit = connection.CreateCommand();
            createTableHabit.CommandText = @"
CREATE TABLE IF NOT EXISTS habits(
habit_id integer PRIAMRY KEY,
name text NOT NULL,
measurement text NOT NULL,
quantity integer NOT NULL,
description text
)";
            createTableHabit.ExecuteNonQuery();

            var createTableUser = connection.CreateCommand();
            createTableUser.CommandText = @"
CREATE TABLE IF NOT EXISTS user(
user_id integer PRIMARY KEY,
user_name text NOT NULL,
habit_id integer integer NOT NULL,
FOREIGN KEY (habit_id) REFERENCES habits (habit_id)
)";

            createTableUser.ExecuteNonQuery();


        }



    }
}
