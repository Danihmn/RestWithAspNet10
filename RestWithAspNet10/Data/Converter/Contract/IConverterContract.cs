namespace RestWithAspNet10.Data.Converter.Contract
{
    public interface IConverterContract<Origin, Destination>
    {
        Destination Parse (Origin origin);

        List<Destination> ParseList (List<Origin> originList);
    }
}
