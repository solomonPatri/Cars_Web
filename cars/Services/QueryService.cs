using Cars_Web.cars.Dtos;
using Cars_Web.cars.Repository;
using Cars_Web.cars.Exceptions;

namespace Cars_Web.cars.Services
{
    public class QueryService:IQueryService
    {
        private readonly ICarRepo _repo;

        public QueryService(ICarRepo repo)
        {
            this._repo = repo;

        }


       public async Task<GetAllCarsDto> GetAllAsync()
        {
            GetAllCarsDto response = await this._repo.GetAllAsync();

            if(response != null)
            {
                return response;

            }
            throw new CarNotFoundException();


        }

        public async Task<GetAllCarsDto> FindByBrandAsync(string brand)
        {
            if (brand != null)
            {
                GetAllCarsDto response = await this._repo.FindByBrandAsync(brand);
                return response;


            }
            throw new CarNotFoundException();





        }

        public async Task<CarResponse> FinByIdAsync(int id)
        {
            if (id != 0)
            {
                CarResponse response = await this._repo.FinByIdAsync(id);
                return response;
                     

            }
            throw new CarNotFoundException();






        }

        public async Task<GetAllBrand> GetAllBrandsAsync()
        {
            GetAllBrand response = await this._repo.GetAllBrandsAsync();

            if(response != null)
            {
                return response;

            }
            throw new CarNotFoundException();







        }



































    }
}
