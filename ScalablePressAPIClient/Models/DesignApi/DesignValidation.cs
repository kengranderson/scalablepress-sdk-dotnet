namespace ScalablePress.API.Models.DesignApi
{
    public class DesignValidation
    {
        /// <summary>
        /// Result of validation - will return null for now
        /// </summary>
        public object result { get; set; }

        /// <summary>
        /// Status of the validation object
        /// </summary>
        public string status { get; set; }
    }
}
