namespace TimeLoggerLib
{
    public class Habit
    {
        public Habit(int quantity, string name, string discription)
        {
            Quantity = quantity;
            Name = name;
            Discription = discription;
        }

        public int Quantity { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }


    }
}
