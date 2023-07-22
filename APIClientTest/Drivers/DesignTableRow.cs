using ScalablePress.API.Models.DesignApi;
using System;
using System.Text.Json;

namespace APIClientTest
{
    public class DesignTemplate
    {
        public DesignTemplate()
        {
        }

        public DesignTemplate(DesignResponse designResponse)
        {
            DesignId = designResponse.designId;
            Name = designResponse.name;
            CreateDate = designResponse.createdAt;
            PrintType = designResponse.type.ToString();
            Active = true;

            if (designResponse.sides != null)
            {
                var sides = designResponse.sides;

                (FrontArtworkId, FrontArtwork, FrontProof, FrontAspect, FrontResize, FrontColors, FrontDimensionsWidth, FrontDimensionsHeight, FrontPositionHorizontal, FrontPositionOffsetTop, FrontPositionOffsetBottom) = GetSide(sides.front);  
                (BackArtworkId, BackArtwork, BackProof, BackAspect, BackResize, BackColors, BackDimensionsWidth, BackDimensionsHeight, BackPositionHorizontal, BackPositionOffsetTop, BackPositionOffsetBottom) = GetSide(sides.back);
                (LeftArtworkId, LeftArtwork, LeftProof, LeftAspect, LeftResize, LeftColors, LeftDimensionsWidth, LeftDimensionsHeight, LeftPositionHorizontal, LeftPositionOffsetTop, LeftPositionOffsetBottom) = GetSide(sides.left);
                (RightArtworkId, RightArtwork, RightProof, RightAspect, RightResize, RightColors, RightDimensionsWidth, RightDimensionsHeight, RightPositionHorizontal, RightPositionOffsetTop, RightPositionOffsetBottom) = GetSide(sides.right);  
            }

            JsonData = JsonSerializer.Serialize(designResponse);
        }

        #region Properties

        public string DesignId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string PrintType { get; set; }
        public bool Active { get; set; }

        public string FrontArtworkId { get; set; }
        public string FrontArtwork { get; set; }
        public string FrontProof { get; set; }
        public float? FrontAspect { get; set; }
        public bool FrontResize { get; set; }
        public string FrontColors { get; set; }
        public float? FrontDimensionsWidth { get; set; }
        public float? FrontDimensionsHeight { get; set; }
        public string FrontPositionHorizontal { get; set; }
        public float? FrontPositionOffsetTop { get; set; }
        public float? FrontPositionOffsetBottom { get; set; }

        public string BackArtworkId { get; set; }
        public string BackArtwork { get; set; }
        public string BackProof { get; set; }
        public float? BackAspect { get; set; }
        public bool BackResize { get; set; }
        public string BackColors { get; set; }
        public float? BackDimensionsWidth { get; set; }
        public float? BackDimensionsHeight { get; set; }
        public string BackPositionHorizontal { get; set; }
        public float? BackPositionOffsetTop { get; set; }
        public float? BackPositionOffsetBottom { get; set; }

        public string LeftArtworkId { get; set; }
        public string LeftArtwork { get; set; }
        public string LeftProof { get; set; }
        public float? LeftAspect { get; set; }
        public bool LeftResize { get; set; }
        public string LeftColors { get; set; }
        public float? LeftDimensionsWidth { get; set; }
        public float? LeftDimensionsHeight { get; set; }
        public string LeftPositionHorizontal { get; set; }
        public float? LeftPositionOffsetTop { get; set; }
        public float? LeftPositionOffsetBottom { get; set; }

        public string RightArtworkId { get; set; }
        public string RightArtwork { get; set; }
        public string RightProof { get; set; }
        public float? RightAspect { get; set; }
        public bool RightResize { get; set; }
        public string RightColors { get; set; }
        public float? RightDimensionsWidth { get; set; }
        public float? RightDimensionsHeight { get; set; }
        public string RightPositionHorizontal { get; set; }
        public float? RightPositionOffsetTop { get; set; }
        public float? RightPositionOffsetBottom { get; set; }

        public string JsonData { get; set; }

        #endregion

        static (string, string, string, float?, bool, string, float?, float?, string, float?, float?) GetSide(DesignSide side)
        {
            if (side != null)
            {
                return (side.artworkId, side.artwork, side.proof, 
                    side.aspect, side.resize, 
                    side.colors == null ? null : string.Join(',', side.colors), 
                    side.dimensions?.width, side.dimensions?.height, 
                    side.position?.horizontal, side.position?.offset?.top, 
                    side.position?.offset?.bottom);
            }

            return (null, null, null, null, false, null, null, null, null, null, null);
        }
    }
}
