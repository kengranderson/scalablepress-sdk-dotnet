namespace ScalablePress.API.Models.DesignApi
{
    public class PositionOffset
    {
        /// <summary>
        /// top offset in inches, specify this OR the bottom offset of the print
        /// </summary>
        public float? top { get; set; }

        /// <summary>
        /// bottom offset in inches, specify this OR the top offset of the print
        /// </summary>
        public float? bottom { get; set; }

        public static PositionOffset FromTop(float top) =>
            new PositionOffset
            {
                top = top
            };

        public static PositionOffset FromBottom(float bottom) =>
            new PositionOffset
            {
                bottom = bottom
            };

        public override string ToString() => $"top: {top}, bottom: {bottom}";
    }
}
