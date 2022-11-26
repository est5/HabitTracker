namespace HabitTrackerLib.Model;

class UserModel
{
    public string UserName { get; set; }

    public UserModel(string userName)
    {
        UserName = userName;
    }

    public string? HabitName { get; set; }
    public string? Measurement { get; set; }
    public int? Quantity { get; set; }
    public string? Discription { get; set; }

}
