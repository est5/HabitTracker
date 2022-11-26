using HabitTrackerLib.Model;
using Microsoft.Data.Sqlite;

namespace HabitTrackerLib.DB;

public class DBSqlite : IDbOperations
{
    private const string CON = "Data Source=habit.db";

    public DBSqlite()
    {
        InitDB();
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

    public void AddHabit(Habit habit, User user)
    {
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var createHabit = connection.CreateCommand();
            createHabit.CommandText = @"
            UPDATE user
            SET habit_name = @name, measurement = @measurement, quantity = @quantity, discription = @discription
            WHERE user_name = @user_name
            ";
            SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text);
            nameParam.Value = habit.Name;
            createHabit.Parameters.Add(nameParam);

            SqliteParameter measurement = new SqliteParameter("@measurement", SqliteType.Text);
            measurement.Value = habit.Measurement;
            createHabit.Parameters.Add(measurement);


            SqliteParameter quantity = new SqliteParameter("@quantity", SqliteType.Integer);
            quantity.Value = habit.Quantity;
            createHabit.Parameters.Add(quantity);


            SqliteParameter discription = new SqliteParameter("@discription", SqliteType.Text);
            discription.Value = habit.Discription;
            createHabit.Parameters.Add(discription);

            SqliteParameter usrName = new SqliteParameter("@user_name", SqliteType.Text);
            usrName.Value = user.Name;
            createHabit.Parameters.Add(usrName);

            createHabit.Prepare();
            createHabit.ExecuteNonQuery();
        }
    }

    public void DeleteHabit(string userName)
    {
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var delete = connection.CreateCommand();
            delete.CommandText = @"
            UPDATE user
            SET habit_name = NULL, measurement = NULL, quantity = NULL, discription = NULL
            WHERE user_name = @name
            ";

            SqliteParameter usrName = new SqliteParameter("@name", SqliteType.Text);
            usrName.Value = userName;
            delete.Parameters.Add(usrName);

            delete.Prepare();
            delete.ExecuteNonQuery();
        }
    }

    public void UpdateHabit(Habit habit, User user) => AddHabit(habit, user);

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

    public UserModel GetUserInfo(string name)
    {
        var model = new UserModel(name);
        using (var connection = new SqliteConnection(CON))
        {
            connection.Open();
            var getUser = connection.CreateCommand();
            getUser.CommandText = @"
            SELECT user_name, habit_name, measurement, quantity, discription FROM user
            WHERE user_name = @name
            ";
            SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text);
            nameParam.Value = name;
            getUser.Parameters.Add(nameParam);
            getUser.Prepare();

            var reader = getUser.ExecuteReader();
            while (reader.Read())
            {
                model.HabitName = Convert.ToString(reader[1]);
                model.Measurement = Convert.ToString(reader[2]);
                model.Quantity = Convert.ToInt32(reader[3]);
                model.Discription = Convert.ToString(reader[4]);
            }
            reader.Close();
        }
        return model;
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
            discription text
            )";

            createTableUser.ExecuteNonQuery();


        }



    }

}
