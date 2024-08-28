namespace WitGeorgia.Model;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public int PersonalNumber { get; set; }
    public int Salary { get; set; }
    public int PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
}