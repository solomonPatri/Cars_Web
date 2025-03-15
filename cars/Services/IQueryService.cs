using Cars_Web.cars.Dtos;

namespace Cars_Web.cars.Services
{
    public interface IQueryService
    {

        Task<GetAllCarsDto> GetAllAsync();

        Task<GetAllCarsDto> FindByBrandAsync(string brand);

        Task<CarResponse> FinByIdAsync(int id);

        Task<GetAllBrand> GetAllBrandsAsync();











    }
}
