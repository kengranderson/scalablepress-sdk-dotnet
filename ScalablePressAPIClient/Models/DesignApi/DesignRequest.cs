namespace ScalablePress.API.Models.DesignApi
{
    public class DesignRequest
    {
        /// <summary>
        /// Optional reference name for design
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Type of product this design is for. screenprint, 
        /// dtg, case, mug, or poster
        /// </summary>
        public DesignTypes type { get; set; }

        /// <summary>
        /// Design sides object
        /// </summary>
        public DesignSides sides { get; set; } = new DesignSides();

        /// <summary>
        /// Design validation object
        /// </summary>
        public DesignValidation validation { get; set; }

        public override string ToString() => name ?? base.ToString();
    }
}
