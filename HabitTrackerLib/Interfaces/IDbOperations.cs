namespace HabitTrackerLib
{
    public interface IDbOperations
    {

        bool IsHabitExists(string name);
        void AddHabit(Habit habit);
        void EditHabit(Habit habit);
        void DeleteHabit();

    }
}
