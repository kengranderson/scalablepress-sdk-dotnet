using System.Collections.Generic;

namespace ScalablePress.API.Models
{
    public class BadRequest
    {
        public int statusCode { get; set; }
        public IEnumerable<BadRequestIssue> issues { get; set; }
    }
}
