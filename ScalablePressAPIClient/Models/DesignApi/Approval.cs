using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class Approval
    {
        /// <summary>
        /// Approval status.
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Approval status notes.
        /// </summary>
        public IEnumerable<string> notes { get; set; }
    }
}
