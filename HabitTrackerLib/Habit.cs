namespace HabitTrackerLib
{
    public class Habit
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }
        public string Measurement { get; set; }

        public Habit(int quantity, string name, string discription)
        {
            Quantity = quantity;
            Name = name;
            Discription = discription;
        }

        public Habit(int quantity, string name, string? discription, string? measurement) : this(quantity, name, discription)
        {
            Measurement = measurement;
        }
    }
}
