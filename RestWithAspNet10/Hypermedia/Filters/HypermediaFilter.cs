using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet10.Hypermedia.Filters
{
    public class HypermediaFilter (HypermediaFilterOptions hypermediaFilterOptions) : ResultFilterAttribute
    {
        private readonly HypermediaFilterOptions _hypermediaFilterOptions = hypermediaFilterOptions;

        public override void OnResultExecuting (ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        /// <summary>
        /// Tries to enrich the request´s result using the appropriate enricher.
        /// </summary>
        /// <param name="context"></param>
        private void TryEnrichResult (ResultExecutingContext context)
        {
            // Verifies if the ObjectResult is successful
            if (context.Result is OkObjectResult okObjectResult)
            {
                // Check for an enricher that can handle the current context
                var enricher = _hypermediaFilterOptions
                    .ContentResponseEnricherList
                    .FirstOrDefault(option => option.CanEnrich(context));

                // If an "CanEnrich == true" is found, use it to enrich the response
                enricher?.Enrich(context).Wait(); // Using Wait() to call the async method in a sync context
            }
        }
    }
}
