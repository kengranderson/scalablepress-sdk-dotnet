namespace ScalablePress.API.Models.DesignApi
{
    public class DesignApprovals
    {
        /// <summary>
        /// Order approval status.
        /// </summary>
        public Approval order { get; set; }

        /// <summary>
        /// Artwork approval status.
        /// </summary>
        public Approval artwork { get; set; }
    }
}
