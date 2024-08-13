using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarPlace.Filters
{
    public class IgnorePropertiesFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Remove properties from the request example that are not needed
            var propertiesToIgnore = new List<string> { "twoFactorCode", "twoFactorRecoveryCode" };

            if (operation.RequestBody?.Content.Values is IList<OpenApiMediaType> contentMediaTypes)
            {
                foreach (var mediaType in contentMediaTypes)
                {
                    if (mediaType.Schema?.Properties != null)
                    {
                        foreach (var property in propertiesToIgnore)
                        {
                            mediaType.Schema.Properties.Remove(property);
                        }
                    }
                }
            }
        }
    }
}
