namespace ScalablePress.API.Models.MockupApi
{
    public class Template
    {
        /// <summary>
        /// Name of the mockup template. See available products for possible templates
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Name of the background. See available backgrounds
        /// </summary>
        public AvailableBackgrounds background { get; set; }	
    }
}
