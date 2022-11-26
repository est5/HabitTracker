namespace HabitTrackerLib
{
    public class Habit
    {
        public int Quantity { get; set; } = 0;
        public string Name { get; set; } = "default";
        public string? Discription { get; set; }
        public string Measurement { get; set; } = "default";

        public Habit(int quantity, string name, string? discription, string measurement)
        {
            Quantity = quantity;
            Name = name;
            Discription = discription;
            Measurement = measurement;
        }
    }
}
