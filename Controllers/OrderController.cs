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
        private readonly IOrderedProductRepository _orderedProductsRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly ICustomerPersonalDataRepository _customerPersonalDataRepository;


        public OrderController(IOrderRepository orderRepository, IOrderedProductRepository orderedProductRepository,
            IDeliveryOptionRepository deliveryOptionRepository, ICustomerPersonalDataRepository customerPersonalDataRepository
            )
        {
            this._orderRepository = orderRepository;
            this._orderedProductsRepository = orderedProductRepository;
            this._deliveryOptionRepository = deliveryOptionRepository;
            this._customerPersonalDataRepository = customerPersonalDataRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfoResponse>> GetOrderById(int id)
        {
            var order = await _orderRepository.Get(id);
            var customerData = await _customerPersonalDataRepository.Get();

            var orderedProducts = await _orderedProductsRepository.Get();
            var delivery = await _deliveryOptionRepository.Get(order.DeliveryOptionId);
            var filtredData = orderedProducts
                .Where(x => x.OrderId == id).ToList()
                .Select(x => ProductOrderDataMapper.ToProductInfo(x));

            var orderInfo = new OrderInfoResponse
            {
                Delivery = delivery.DeliveryName,
                TotalPrice = filtredData.Select(x=>x.Price).ToList().Sum().ToString("F"),
                CustomerDataInfo = ProductOrderDataMapper.ToCustomerDtoInfo(customerData.Where(p => p.ProductOrderId == id).FirstOrDefault()),
                ProductInfo = filtredData

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
                CustomerPersonalData = customerInfoData,
                DeliveryOptionId = createOrderRequest.DeliveryId,
                OrderedProducts = orderedProduct,

            };
            var orderId = await _orderRepository.Add(productOrder);

            return Ok();
           
        }


    }
}
