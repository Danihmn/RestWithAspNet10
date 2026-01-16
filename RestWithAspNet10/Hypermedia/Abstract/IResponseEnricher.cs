using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAspNet10.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        /// <summary>
        /// Verifies if the response can be enriched
        /// </summary>
        /// <param name="context">Contexto para interceptar a response</param>
        /// <returns></returns>
        bool CanEnrich (ResultExecutingContext context);

        /// <summary>
        /// Enriches the response
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task Enrich (ResultExecutingContext context);
    }
}