using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet10.Hypermedia.Filters
{
    public class HypermediaFilter (HypermediaFilterOptions hypermediaFilterOptions) : ResultFilterAttribute
    {
        private readonly HypermediaFilterOptions _hypermediaFilterOptions = hypermediaFilterOptions;

        // It is called for each request, to try to enrich the response with hypermedia links
        public override void OnResultExecuting (ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        // Tries to enrich the request´s result using the appropriate enricher.
        private void TryEnrichResult (ResultExecutingContext context)
        {
            // Verifies if the ObjectResult is successful
            if (context.Result is OkObjectResult okObjectResult)
            {
                // Check for an enricher that can handle the current context
                var enricher = _hypermediaFilterOptions
                    .ContentResponseEnricherList
                    .FirstOrDefault(option => option.CanEnrich(context));

                enricher?.Enrich(context).Wait(); // Using Wait() to call the async method in a sync context
            }
        }
    }
}
