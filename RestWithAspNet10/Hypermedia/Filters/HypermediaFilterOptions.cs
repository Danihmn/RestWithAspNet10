using RestWithAspNet10.Hypermedia.Abstract;

namespace RestWithAspNet10.Hypermedia.Filters
{
    // Is registered as a Singleton in the HateoasConfiguration class, to be injected in the HypermediaFilter
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = [];
    }
}