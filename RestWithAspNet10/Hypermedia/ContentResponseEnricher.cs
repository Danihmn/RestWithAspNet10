using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithAspNet10.Hypermedia.Abstract;

namespace RestWithAspNet10.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHypermedia
    {
        /// <summary>
        /// Checks if the contextType is compatible with T or List of T
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        public virtual bool CanEnrich (Type contextType)
        {
            return contextType == typeof(T) || contextType == typeof(List<T>);
        }

        protected abstract Task EnrichModel (T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich (ResultExecutingContext response)
        {
            if (response.Result is ObjectResult objectResult)
            {
                return CanEnrich(objectResult.Value.GetType());
            }

            return false;
        }

        public async Task Enrich (ResultExecutingContext response)
        {
            // Create UrlHelper to generate links
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);

            if (response.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (objectResult.Value is List<T> collection)
                {
                    foreach (var item in collection)
                    {
                        await EnrichModel(item, urlHelper);
                    }
                }
            }

            await Task.CompletedTask;
        }
    }
}
