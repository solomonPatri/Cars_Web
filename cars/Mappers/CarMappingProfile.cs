using AutoMapper;
using Cars_Web.cars.model;
using Cars_Web.cars.Dtos;


namespace Cars_Web.cars.Mappers
{
    public class CarMappingProfile:Profile
    { 

        public CarMappingProfile()
        {
            CreateMap<CarResponse, Car>();
            CreateMap<Car, CarRequest>();
            CreateMap<CarResponse, CarUpdateRequest>();
            CreateMap<CarResponse, GetAllCarsDto>();
            




        }








    }
}
