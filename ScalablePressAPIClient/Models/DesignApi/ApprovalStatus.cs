using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class ApprovalStatus
    {
        public string status { get; set; }
        public List<object> notes { get; set; }
    }
}
