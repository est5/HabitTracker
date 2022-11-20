namespace HabitTrackerLib
{
    public interface IDbOperations
    {

        bool IsHabitExists();
        void AddHabit(Habit habit);
        void EditHabit(Habit habit);
        void DeleteHabit();

    }
}
