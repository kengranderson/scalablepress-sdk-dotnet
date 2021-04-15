using ScalablePress.API.Models.DesignApi;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class DesignAPI : APIBase
    {
        internal DesignAPI(AuthenticationHeaderValue authHeader) : base(authHeader)
        {
        }

        [ApiCall("design", "Post")]
        public async Task<DesignResponse> PostDesignAsync(Design design) =>
            await CallMultipartAPIAsync<DesignResponse>(typeof(DesignAPI), nameof(DesignAPI.PostDesignAsync), design).ConfigureAwait(false);

        [ApiCall("design/{designId}")]
        public async Task<DesignResponse> GetDesignAsync(string designId) =>
            await CallJsonAPIAsync<DesignResponse>(typeof(DesignAPI), nameof(DesignAPI.GetDesignAsync), nameof(designId), designId).ConfigureAwait(false);

        [ApiCall("design/{designId}", "Delete")]
        public async Task<DeletedDesignResponse> DeleteDesignAsync(string designId) =>
            await CallJsonAPIAsync<DeletedDesignResponse>(typeof(DesignAPI), nameof(DesignAPI.DeleteDesignAsync), nameof(designId), designId).ConfigureAwait(false);

    }
}
