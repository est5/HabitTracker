namespace HabitTrackerLib
{
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

        public void DeleteHabit(Habit habit)
        {
            throw new NotImplementedException();
        }

        public void EditHabit(Habit habit)
        {
            throw new NotImplementedException();
        }
    }
}
