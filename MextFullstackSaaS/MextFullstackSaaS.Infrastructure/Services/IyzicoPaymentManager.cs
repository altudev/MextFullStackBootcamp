using Iyzipay.Model;
using Iyzipay.Request;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Payments;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.Extensions.Options;
using Options = Iyzipay.Options;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class IyzicoPaymentManager:IPaymentService
    {
        private readonly Options _options;

        public IyzicoPaymentManager(IOptions<IyzicoSettings> settings)
        {
            _options = new Options
            {
                ApiKey = settings.Value.ApiKey,
                SecretKey = settings.Value.SecretKey,
                BaseUrl = settings.Value.BaseUrl
            };
        }

        private const int OneCreditPrice = 10;
        private const string CallbackUrl = "https://localhost:7281/api/Payments/payment-result/";

        public async Task<object> CreateCheckoutFormAsync(PaymentsCreateCheckoutFormRequest userRequest,CancellationToken cancellationToken)
        {
            var price = userRequest.Credits * OneCreditPrice;
            var paidPrice = price;
            var basketId = Guid.NewGuid();

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = price.ToString(),
                PaidPrice = paidPrice.ToString(),
                Currency = Currency.TRY.ToString(),
                BasketId = basketId.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = CallbackUrl
            };

            List<int> enabledInstallments = new List<int>();

            enabledInstallments.Add(3);

            enabledInstallments.Add(6);

            enabledInstallments.Add(9);

            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "Alper",
                Surname = "Tunga",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };

            // UserAddress
            request.Buyer = buyer;

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            BasketItem firstBasketItem = new BasketItem
            {
                Id = "BI101",
                Name = "IconBuilderAI 10 credits",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "100",
                Category1 = "Credits"
            };
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, _options);

            return checkoutFormInitialize;
        }
    }
}
