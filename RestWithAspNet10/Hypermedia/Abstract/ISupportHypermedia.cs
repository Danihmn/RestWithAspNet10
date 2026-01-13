namespace RestWithAspNet10.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}
