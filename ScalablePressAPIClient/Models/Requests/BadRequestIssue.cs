using System.Collections.Generic;

namespace ScalablePress.API.Models
{
    public class BadRequestIssue
    {
        public string code { get; set; }
        public string path { get; set; }
        public string message { get; set; }
        public BadRequestIssueSpec spec { get; set; }

        //public override string ToString() => message;
    }
}
