namespace BrcFoodApp.WebApi.Entities;

public class Contact
{
    public int Id { get; set; }
    public string MapLocation { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string OpenHours { get; set; }
}
