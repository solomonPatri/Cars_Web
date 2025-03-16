using Cars_Web.cars.Dtos;
using Cars_Web.cars.Exceptions;
using Cars_Web.cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Web.cars
{
    [ApiController]
    [Route("api/v1/[Controller]")]


    public class CarsController : ControllerBase
    {
        private readonly ICommandService _command;
        private readonly IQueryService _query;

        public CarsController(ICommandService command, IQueryService query)
        {
            this._command = command;
            this._query = query;


        }

        [HttpGet("all")]

        public async Task<ActionResult<GetAllCarsDto>> GetAllCarAsync()
        {

            try
            {

                GetAllCarsDto cars = await _query.GetAllAsync();

                return Ok(cars);
            } catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }


        [HttpPost("create")]

        public  async Task<ActionResult<CarResponse>> CreateCArAsync(CarRequest create)
        {
            try
            {
                CarResponse response = await this._command.CreateAsync(create);

                return Accepted("", response);


            }catch(CarArlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }






        }



        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<CarResponse>> DeleteCarAsync([FromRoute] int id)
        {
            try
            {
                CarResponse response = await _command.DeleteAsync(id);
                return Accepted("", response);


            } catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);
            }



        }


        [HttpPut("edit/{id}")]

        public async Task<ActionResult<CarResponse>> UpdateCarAsync([FromRoute] int id, [FromBody] CarUpdateRequest update)
        {

            try
            {
                CarResponse response = await this._command.UpdateAsync(id, update);
                return Accepted("", response);
            } catch (CarNotUpdateException up)
            {
                return NotFound(up.Message);
            }
            catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);
            }




        }


        [HttpGet("GetAllBrandsCar")]

        public async Task<ActionResult<GetAllBrand>> GetAllBrandsCarAsync()
        {
            try
            {
                GetAllBrand response = await this._query.GetAllBrandsAsync();
                return Ok(response);

            }

            catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);

            }

        }


        [HttpGet("find/id/{id}")]

        public async Task<ActionResult<CarResponse>> GetByIdAsync([FromRoute]int id)
        {
            try
            {
                CarResponse response = await _query.FinByIdAsync(id);
                return Accepted("", response);

            }
            catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);

            }




        }


        [HttpGet("find/brand/{brand}")]

        public async Task<ActionResult<GetAllCarsDto>> GetByBrandsAsync([FromRoute] string brand)
        {
            try
            {
                GetAllCarsDto response = await this._query.FindByBrandAsync(brand);

                return Accepted("", response);
            }
            catch (CarNotFoundException nf)
            {
                return NotFound(nf.Message);

            }





        }





























    }
}
