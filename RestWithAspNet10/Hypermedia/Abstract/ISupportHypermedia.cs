namespace RestWithAspNet10.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        // Gets or sets the hypermedia links
        List<HypermediaLink> Links { get; set; }
    }
}