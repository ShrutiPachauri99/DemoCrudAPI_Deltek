namespace ContactsMasterInfra.ViewModel
{
    public class ContactViewModel
    {
        public int? ContactId { get; set; }
        public string ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public DateTime? ContactBirthDate { get; set; }
    }
}
