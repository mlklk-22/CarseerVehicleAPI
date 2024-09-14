using CarseerAPI.Models;
using CarseerAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarseerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _vehicle;

        public VehiclesController(IVehiclesService vehicle)
        {
            _vehicle = vehicle;
        }

        [HttpGet]
        [Route("GetAllMakes")]
        public ResponseResult<List<VehicleMakes>> GetAllMakes() 
        {
            return _vehicle.GetAllMakes();
        }
        
        [HttpGet]
        [Route("GetVehicleTypesByMakeId/{makeID}")]
        public ResponseResult<List<VehicleTypes>> GetVehicleTypesByMakeId(int makeID) 
        {
            return _vehicle.GetVehicleTypesByMakeId(makeID);
        }
        
        [HttpGet]
        [Route("GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelyear}")]
        public ResponseResult<List<VehicleModels>> GetModelsForMakeIdYear(int makeId, int modelyear) 
        {
            return _vehicle.GetModelsForMakeIdYear(makeId, modelyear);
        }
    }
}
