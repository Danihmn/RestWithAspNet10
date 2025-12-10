namespace RestWithAspNet10.Configurations
{
    public static class ContentNegotiationConfiguration
    {
        public static IMvcBuilder AddContentNegotiation (this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
            }).AddXmlSerializerFormatters();
        }
    }
}
