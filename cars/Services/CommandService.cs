using Cars_Web.cars.Dtos;
using Cars_Web.cars.Repository;
using Cars_Web.cars.Exceptions;
using Microsoft.JSInterop;
using System.CodeDom;

namespace Cars_Web.cars.Services
{
    public class CommandService:ICommandService
    {
        private readonly ICarRepo _repo;

        public CommandService (ICarRepo repo)
        {
            this._repo = repo;


        }





       public async  Task<CarResponse> CreateAsync(CarRequest create)
        {
            CarResponse carexist = await this._repo.FindBrandNameAsync(create.Brand);

            if(carexist == null)
            {
                CarResponse response = await this._repo.CreateAsync(create);
                return response;

            }
            throw new CarArlreadyExistException();



        }


        public async Task<CarResponse> DeleteAsync(int id)
        {
            CarResponse delete = await this._repo.FinByIdAsync(id);

            if (delete != null)
            {
                CarResponse response = await this._repo.DeleteAsync(id);
                return response;

            }
            throw new CarNotFoundException();

        }

        public async Task<CarResponse> UpdateAsync(int id, CarUpdateRequest update)
        {

            CarResponse searched = await this._repo.FinByIdAsync(id);

            if (searched != null)
            {
                if(searched is CarRequest)
                {
                    searched.Brand = update.Brand ?? searched.Brand;
                    searched.Model = update.Model ?? searched.Model;
                    searched.Color = update.Color ?? searched.Color;
                    searched.Year = update.Year ?? searched.Year;

                    CarResponse response = await this._repo.UpdateAsync(id, update);
                    return response;

                }

                throw new CarNotUpdateException();


            }
            throw new CarNotFoundException();












        }











    }
}
