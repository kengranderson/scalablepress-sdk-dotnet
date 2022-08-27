namespace ScalablePress.API.Models
{
    public class BadRequestIssueSpec
    {
        public string type { get; set; }
        public string description { get; set; }
        public bool required { get; set; }
        public override string ToString() => description;
    }
}
