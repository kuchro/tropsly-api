using tropsly_api.Model.Dto.Response;

namespace tropsly_api.Model.Dto
{
    public class DataMapper
    {
        public static ConfigDataResponse ToResponse(Brand brand)
            => new ConfigDataResponse { Id = brand.Id, Name = brand.Name };

        public static ConfigDataResponse ToResponse(Category category)
            => new ConfigDataResponse { Id = category.Id, Name = category.Name };


    }
}
