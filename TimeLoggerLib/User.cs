namespace TimeLoggerLib
{
    public class User
    {
        public Habit? UserHabit { get; set; }
        public string? Name { get; set; }

        public void SetHabit(Habit habit)
        {
            UserHabit = habit;
        }

    }
}
