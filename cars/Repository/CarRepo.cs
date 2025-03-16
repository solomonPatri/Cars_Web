using Cars_Web.cars.model;
using Cars_Web.cars.Repository;
using Cars_Web.data;
using Microsoft.EntityFrameworkCore;
using Cars_Web.cars.Dtos;
using AutoMapper;

namespace Cars_Web.cars.Repository
{
    public class CarRepo:ICarRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CarRepo(AppDbContext context,IMapper mapper)
        {

            this._appDbContext = context;
            this._mapper = mapper;
        }


       public async  Task<GetAllCarsDto> GetAllAsync()
        {
            IList<Car> data = await _appDbContext.Cars.ToListAsync();

            var cars = data.Select(m => _mapper.Map<CarResponse>(m)).ToList();

            GetAllCarsDto response = new GetAllCarsDto();
            response.Carslist = cars;
            return response;



        }

        public async Task<CarResponse> CreateAsync(CarRequest create)
        {
            Car car = _mapper.Map<Car>(create);

            _appDbContext.Cars.Add(car);

            await _appDbContext.SaveChangesAsync();
            CarResponse response = _mapper.Map<CarResponse>(car);

            return response;


        }


        public async Task<CarResponse> DeleteAsync(int id)
        {
            Car car = await _appDbContext.Cars.FindAsync(id);
            CarResponse response = _mapper.Map<CarResponse>(car);

             _appDbContext.Remove(car);
            await _appDbContext.SaveChangesAsync();

            return response;



        }

        public async Task<CarResponse> UpdateAsync(int id, CarUpdateRequest update)
        {
            Car cars = await _appDbContext.Cars.FindAsync(id);

            if (update.Brand != null)
            {
                cars.Brand = update.Brand;
            }
            if (update.Model != null)
            {
                cars.Model = update.Model;

            }
            if (update.Color != null)
            {
                cars.Color = update.Color;

            }
            if (update.Year.HasValue)
            {
                cars.Year = update.Year.Value;
            }

            _appDbContext.Cars.Update(cars);

            await _appDbContext.SaveChangesAsync();

            CarResponse response = _mapper.Map<CarResponse>(cars);

            return response;










        }

        public async Task<GetAllCarsDto> FindByBrandAsync(string brand)
        {

            var exist = await _appDbContext.Cars.Where(m => m.Brand.Equals(brand)).ToListAsync();

            var map = exist.Select(s => _mapper.Map<CarResponse>(s)).ToList();
            GetAllCarsDto response = new GetAllCarsDto();
            response.Carslist = map;

            return response;

        }

        public async Task<CarResponse> FinByIdAsync(int id)
        {
            Car car = await _appDbContext.Cars.FindAsync(id);
            CarResponse response = _mapper.Map<CarResponse>(car);
            return response;






        }

        public async Task<GetAllBrand> GetAllBrandsAsync()
        {
            List<string> brands = await _appDbContext.Cars.Select(m => m.Brand).ToListAsync();

            GetAllBrand response = new GetAllBrand();
            response.Brands = brands;
            return response;






        }

        public async  Task<CarResponse?> FindBrandNameAsync(CarRequest car)
        {
            var entity = await _appDbContext.Cars
                .Where(m => m.Brand == car.Brand
                       && m.Model != car.Model
                       && m.Color != car.Color
                       && m.Year != car.Year)
                .FirstOrDefaultAsync();

            if (entity == null)
            {

                return null;
            }

            return _mapper.Map<CarResponse>(entity);




        }

      public async Task<CarResponse> FindByBrandCarASync(string brand)
        {
            Car s = await _appDbContext.Cars.FirstOrDefaultAsync(m => m.Brand.Equals(brand));

            CarResponse response = _mapper.Map<CarResponse>(s);
            return response; 


        }











    }
}
