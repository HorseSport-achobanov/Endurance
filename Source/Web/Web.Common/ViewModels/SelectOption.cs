namespace Web.Common.ViewModels
{
    using AutoMapper;
    using global::Common.Mapping;
    using global::Data.Common.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SelectOption : SelectListItem, IMapFrom<BaseClub>, IHasCustomMappings
    {
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<BaseClub, SelectOption>()
                .ForMember(m => m.Value, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Text, opt => opt.MapFrom(e => e.Name));
        }
    }
}
