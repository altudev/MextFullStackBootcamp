using Microsoft.Extensions.Caching.Memory;

namespace MextFullstackSaaS.Application.Common.Helpers
{
    public static class MemoryCacheHelper
    {
        public static string GetOrdersGetAllKey(Guid userId) => $"OrdersGetAll_{userId}";
        public static string GetOrderGetByIdKey(Guid id) =>$"OrderGetById_{id}";

        public static MemoryCacheEntryOptions GetMemoryCacheEntryOptions()
        {
            return new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(12))
                .SetPriority(CacheItemPriority.Normal);
        }
    }
}
