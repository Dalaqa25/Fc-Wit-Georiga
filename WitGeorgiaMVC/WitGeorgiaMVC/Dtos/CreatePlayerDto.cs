namespace WitGeorgiaMVC.Dtos
{
    public class CreatePlayerDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string PersonalNumber { get; set; }
        public int? Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
