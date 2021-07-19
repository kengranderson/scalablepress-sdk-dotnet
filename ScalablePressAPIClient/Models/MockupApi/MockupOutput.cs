namespace ScalablePress.API.Models.MockupApi
{
    public class MockupOutput
    {
        /// <summary>
        /// Width of the output image in pixels
        /// </summary>
        public float width { get; set; }

        /// <summary>
        /// Height of the output image in pixels
        /// </summary>
        public float height { get; set; }

        /// <summary>
        /// Minimum padding between the mockup and the image border in pixels
        /// </summary>
        public float padding { get; set; }

        /// <summary>
        /// Format of the output image, supported formats are: png, jpg
        /// </summary>
        public MockupOutputFormats format { get; set; }	
    }
}
