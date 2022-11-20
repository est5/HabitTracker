namespace HabitTrackerLib.DB;

public class DBInMemory : IDbOperations
{
    public User User { get; private set; }
    public DBInMemory(User user)
    {
        User = user;
    }

    public void AddHabit(Habit habit)
    {
        User.UserHabit = habit;
    }

    public bool IsHabitExists()
    {
        return User.UserHabit is not null;
    }

    public void DeleteHabit()
    {
        User.UserHabit = null;
    }

    public void EditHabit(Habit habit)
    {
        User.UserHabit = habit;
    }
}
