using CarseerAPI.Models;

namespace CarseerAPI.Service
{
    public interface IVehiclesService
    {
        ResponseResult<List<VehicleMakes>> GetAllMakes();
        ResponseResult<List<VehicleTypes>> GetVehicleTypesByMakeId(int makeID);
        ResponseResult<List<VehicleModels>> GetModelsForMakeIdYear(int makeId, int modelyear);
    }
}
