using Microsoft.AspNetCore.Mvc;
using tropsly_api.Model.ConfigData;
using tropsly_api.Model.Dto;
using tropsly_api.Model.Dto.Request;
using tropsly_api.Model.Dto.Response;
using tropsly_api.Model.OrderData;
using tropsly_api.Repository;
using tropsly_api.Repository.Category;
using tropsly_api.Repository.ProductOrderRepo;

namespace tropsly_api.Controllers
{
    [ApiController]
    [Route("v1/api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;



        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfoResponse>> GetOrderById(int id)
        {
            var order = await _orderRepository.Get(id);


            var orderInfo = new OrderInfoResponse
            {
                Delivery = order.DeliveryOption.DeliveryName,
                TotalPrice = order.TotalPrice.ToString("F"),
                CustomerDataInfo = ProductOrderDataMapper.ToCustomerDtoInfo(order.CustomerPersonalData),
                ProductInfo = order.OrderedProducts.Select(x => ProductOrderDataMapper.ToProductInfo(x))

            };
            return Ok(orderInfo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var products = await _orderRepository.Get();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var customerUserAddress = ProductOrderDataMapper.ToCustomerAddress(createOrderRequest.CustomerDataInfo.CustomerAddressData);
            var customerInfoData = ProductOrderDataMapper.ToCustomerInfo(createOrderRequest.CustomerDataInfo, customerUserAddress, 0);
            var orderedProduct = createOrderRequest.Products.Select(x => ProductOrderDataMapper.ToOrderedProduct(x)).ToList();
            customerInfoData.CustomerAddress = customerUserAddress;
            var productOrder = new Order()
            {
                TotalPrice = createOrderRequest.TotalPrice,
                Status = createOrderRequest.Status,
                CustomerPersonalData = customerInfoData,
                DeliveryOptionId = createOrderRequest.DeliveryId,
                OrderedProducts = orderedProduct,

            };
            var orderId = await _orderRepository.Add(productOrder);

            return Ok();
           
        }


    }
}
