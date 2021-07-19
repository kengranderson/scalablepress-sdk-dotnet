using Microsoft.Extensions.Logging;
using ScalablePress.API.Models.DesignApi;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class DesignAPI : APIBase
    {
        internal DesignAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

        /// <summary>
        /// Provide the details on your design in order to receive a designId, which is required to place an order.
        /// </summary>
        /// <param name="design"></param>
        /// <returns>Returns a design response object.</returns>
        [ApiCall("design", "Post")]
        public async Task<DesignResponse> CreateDesignAsync(DesignRequest design) =>
            await CallMultipartAPIAsync<DesignResponse>(typeof(DesignAPI), nameof(DesignAPI.CreateDesignAsync), design).ConfigureAwait(false);

        /// <summary>
        /// Provide the designId in order to receive the details of a previously submitted design.
        /// </summary>
        /// <param name="designId"></param>
        /// <returns>Returns a design response object.</returns>
        [ApiCall("design/{designId}", "Get")]
        public async Task<DesignResponse> RetrieveDesignAsync(string designId) =>
            await CallJsonAPIAsync<DesignResponse>(typeof(DesignAPI), nameof(DesignAPI.RetrieveDesignAsync), nameof(designId), designId).ConfigureAwait(false);

        /// <summary>
        /// Provide the designId in order to delete a previously submitted design
        /// </summary>
        /// <param name="designId"></param>
        /// <returns>Returns adesign response object with an extra deletedAt number that records the time at which the design was deleted.</returns>
        [ApiCall("design/{designId}")]
        public async Task<DeletedDesignResponse> DeleteDesignAsync(string designId) =>
            await CallJsonAPIAsync<DeletedDesignResponse>(typeof(DesignAPI), nameof(DesignAPI.DeleteDesignAsync), nameof(designId), designId).ConfigureAwait(false);

    }
}
