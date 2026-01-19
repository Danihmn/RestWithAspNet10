namespace RestWithAspNet10.Data.Converters.Contract
{
    public interface IConverterContract<Origin, Destination>
    {
        Destination Parse(Origin origin);
        List<Destination> ParseList(List<Origin> origin);
    }
}