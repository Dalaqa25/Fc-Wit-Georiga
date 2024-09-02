namespace WitGeorgia.Dtos;

public class CreatePlayerDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public long? PersonalNumber { get; set; }
    public int? Salary { get; set; }
    public long? PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
}