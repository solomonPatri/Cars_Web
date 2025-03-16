using Cars_Web.cars.model;
using Cars_Web.cars.Dtos;
using Cars_Web.data;


namespace Cars_Web.cars.Repository
{
    public interface ICarRepo
    {
        Task<GetAllCarsDto> GetAllAsync();

        Task<CarResponse> CreateAsync(CarRequest create);


        Task<CarResponse> DeleteAsync(int id);

        Task<CarResponse> UpdateAsync(int id, CarUpdateRequest update);

        Task<GetAllCarsDto> FindByBrandAsync(string brand);

        Task<CarResponse> FinByIdAsync(int id);

        Task<GetAllBrand> GetAllBrandsAsync();


        Task<CarResponse?> FindBrandNameAsync(CarRequest car);
        Task<CarResponse> FindByBrandCarASync(string brand);




    }
}
