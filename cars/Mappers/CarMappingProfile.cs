using AutoMapper;
using Cars_Web.cars.model;
using Cars_Web.cars.Dtos;


namespace Cars_Web.cars.Mappers
{
    public class CarMappingProfile:Profile
    { 

        public CarMappingProfile()
        {
            CreateMap<CarRequest, Car>();
            CreateMap<Car, CarResponse>();
            CreateMap<CarResponse, CarUpdateRequest>();
            CreateMap<CarRequest, CarResponse>();
            CreateMap<GetAllCarsDto, CarRequest>();



        }








    }
}
