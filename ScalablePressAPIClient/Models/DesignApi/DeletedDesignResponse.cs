using System;

namespace ScalablePress.API.Models.DesignApi
{
    public class DeletedDesignResponse : DesignResponse
    {
        public DateTime deletedAt { get; set; }
    }
}
