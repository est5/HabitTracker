namespace HabitTrackerLib
{
    public interface IDbOperations
    {

        bool IsHabitExists(string name);
        void AddHabit(Habit habit, User user);
        void UpdateHabit(Habit habit, User user);
        void DeleteHabit(string name);

    }
}
