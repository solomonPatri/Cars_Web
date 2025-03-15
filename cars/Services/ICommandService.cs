using Cars_Web.cars.Dtos;

namespace Cars_Web.cars.Services
{
    public interface ICommandService
    {

        Task<CarResponse> CreateAsync(CarRequest create);


        Task<CarResponse> DeleteAsync(int id);

        Task<CarResponse> UpdateAsync(int id, CarUpdateRequest update);





    }
}
