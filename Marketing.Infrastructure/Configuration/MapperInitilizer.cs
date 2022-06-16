using AutoMapper;
using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketing.Infrastructure.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<DistributorDTO, Distributor>();
            CreateMap<Distributor, DistributorDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<SalesDTO, Sales>();
            CreateMap<Sales, SalesDTO>();

        }
    }
}
