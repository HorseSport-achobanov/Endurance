namespace Common.Mapping
{
    using AutoMapper;

    public interface IHasCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
