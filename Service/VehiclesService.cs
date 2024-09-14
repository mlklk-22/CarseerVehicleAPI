using CarseerAPI.Models;
using System.Text.Json;

namespace CarseerAPI.Service
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IConfiguration _configuration;

        public VehiclesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ResponseResult<List<VehicleMakes>> GetAllMakes()
        {
            string url = _configuration["ApiSettings:allVehiclesMakes"];
            ResponseResult<List<VehicleMakes>> vehicleMakes = new ResponseResult<List<VehicleMakes>>();
            try
            {
                vehicleMakes = GetApiResponse<ResponseResult<List<VehicleMakes>>>(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

            return vehicleMakes;
        }

        public ResponseResult<List<VehicleTypes>> GetVehicleTypesByMakeId(int makeID)
        {
            string url = _configuration["ApiSettings:vehicleTypesByMakeId"].Replace("{makeID}", makeID.ToString());
            ResponseResult<List<VehicleTypes>> vehicleMakes = new ResponseResult<List<VehicleTypes>>();
            try
            {
                vehicleMakes = GetApiResponse<ResponseResult<List<VehicleTypes>>>(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

            return vehicleMakes;
        }

        public ResponseResult<List<VehicleModels>> GetModelsForMakeIdYear(int makeId, int modelyear)
        {
            string url = _configuration["ApiSettings:modelsForMakeIdYear"].
                Replace("{makeID}", makeId.ToString()).
                Replace("{modelYear}", modelyear.ToString());

            ResponseResult<List<VehicleModels>> vehicleMakes = new ResponseResult<List<VehicleModels>>();
            try
            {
                vehicleMakes = GetApiResponse<ResponseResult<List<VehicleModels>>>(url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

            return vehicleMakes;
        }

        public T GetApiResponse<T>(string url)
        {
            T apiResponse;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;

                apiResponse = JsonSerializer.Deserialize<T>(responseBody);


            }
            return apiResponse;

        }
    }
}
