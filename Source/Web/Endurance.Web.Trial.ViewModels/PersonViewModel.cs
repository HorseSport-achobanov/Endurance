namespace Endurance.Web.Trial.ViewModels
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Trial.Models;

    public class PersonViewModel : IMapFrom<Person>, IHasCustomMappings
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Person, PersonViewModel>()
                .ForMember(vm => vm.FullName, opt => opt.MapFrom(m => $"{m.FirstName} {m.LastName}"));
        }
    }
}
