using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data
{
    public class PayAjoProfile : Profile
    {

        public PayAjoProfile()
        {
            //CreateMap<Order, OrderViewModel>()
            //    .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id)).ReverseMap();

            //CreateMap<Category, CategoryModel>().ReverseMap();
            // CreateMap<IEnumerable<Video>, IEnumerable<VideoModel>>().ReverseMap();
        }
    }
}
