using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Model.ConfigData;

namespace tropsly_api.Model.Dto
{
    public class DataMapper
    {
        public static ConfigDataResponse ToResponse(Brand brand)
            => new ConfigDataResponse { Id = brand.BrandId, Name = brand.Name };

        public static ConfigDataResponse ToResponse(Category category)
            => new ConfigDataResponse { Id = category.CategoryId, Name = category.Name };

        public static CommentResponse ToResponse(CommentSection comment)
            => new CommentResponse { CommentId=comment.CommentId, Comment=comment.Comment,DateTime=comment.CreatedDate,ProductId=comment.ProductId};

        public static DeliveryOptionsResponse ToResponse(DeliveryOption delivery)
          => new DeliveryOptionsResponse {DeliveryId=delivery.DeliveryId, DeliveryName= delivery.DeliveryName, DeliveryPrice=delivery.DeliveryPrice, ExtraOptions=delivery.ExtraOptions};
        public static RatingData ToModel(RateProductRequest rateProductRequest) =>
            new RatingData { ProductId = rateProductRequest.ProductId, RatingScore = rateProductRequest.RatingScore};
    }
}
