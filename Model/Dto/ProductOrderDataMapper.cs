using tropsly_api.Model.ConfigData;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Model.OrderData;

namespace tropsly_api.Model.Dto
{
    public class ProductOrderDataMapper
    {
        public static CustomerAddress ToCustomerAddress(CustomerAddressData addressData)
            =>  new CustomerAddress { StreetName = addressData.StreetName, 
                City = addressData.City, 
                Region = addressData.Region,
                ZipCode = addressData.ZipCode,
                FlatNumber= addressData.FlatNumber,
                HouseNumber = addressData.HouseNumber};

        public static CustomerAddressData ToCustomerAddressDto(CustomerAddress addressData)
           => new CustomerAddressData
           {
               StreetName = addressData.StreetName,
               City = addressData.City,
               Region = addressData.Region,
               ZipCode = addressData.ZipCode,
               FlatNumber = addressData.FlatNumber,
               HouseNumber = addressData.HouseNumber
           };

        public static CustomerPersonalData ToCustomerInfo(CustomerDataInfo customerDataInfo, CustomerAddress customerAddress , int orderId)
            => new CustomerPersonalData
            {
                FirstName = customerDataInfo.FirstName,
                LastName = customerDataInfo.LastName,
                EmailAddress = customerDataInfo.EmailAddress,
                PhoneNumber = customerDataInfo.PhoneNumber,
                ProductOrderId = orderId,
                CustomerAddress = customerAddress
            };

        public static CustomerDataInfo ToCustomerDtoInfo(CustomerPersonalData customerDataInfo)
           => new CustomerDataInfo
           {
               FirstName = customerDataInfo.FirstName,
               LastName = customerDataInfo.LastName,
               EmailAddress = customerDataInfo.EmailAddress,
               PhoneNumber = customerDataInfo.PhoneNumber,
               CustomerAddressData = ToCustomerAddressDto(customerDataInfo.CustomerAddress)
           };

        public static OrderedProduct ToOrderedProduct(OrderedProductRequest orderedProductRequest)
            => new OrderedProduct
            {
                Name = orderedProductRequest.Name,
                Price = orderedProductRequest.Price,
                SerialNumber = orderedProductRequest.SerialNumber,
                Quantity = orderedProductRequest.Quantity,
                Size = orderedProductRequest.Size,
            };

        public static ProductInfo ToProductInfo(OrderedProduct orderedProduct)
            => new ProductInfo
            {
                Name = orderedProduct.Name,
                Price = orderedProduct.Price,
                Size = orderedProduct.Size,
                Quantity = orderedProduct.Quantity,
                SerialNumber = orderedProduct.SerialNumber
            };

    }
}
