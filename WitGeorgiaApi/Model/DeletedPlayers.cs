namespace WitGeorgia.Model;

public class DeletedPlayers
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime Birthday { get; set; }
    public DateTime DeletedDate { get; set; } = DateTime.UtcNow;
}