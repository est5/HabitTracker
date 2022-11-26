namespace HabitTrackerLib
{
    public interface IDbOperations
    {

        bool IsHabitExists(string name);
        void AddHabit(Habit habit, User user);
        void EditHabit(string name);
        void DeleteHabit(string name);

    }
}
