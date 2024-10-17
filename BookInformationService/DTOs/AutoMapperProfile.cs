using AutoMapper;
using BookInformationService.Models;

namespace BookInformationService.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookInformation, BookInformationDisplayDto>();
            CreateMap<BookInformationUpdateDto, BookInformation>();
        }
    }
}
