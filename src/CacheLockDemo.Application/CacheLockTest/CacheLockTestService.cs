using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace CacheLockDemo.CacheLockTest
{
    public class CacheLockTestService : ApplicationService, ICacheLockTestService
    {
        private readonly IDistributedCache<string, string> _cache;

        public CacheLockTestService(IDistributedCache<string, string> cache)
        {
            _cache = cache;
        }

        public async Task<string> GetOrAddWithLockAsync(string key)
        {
            return await _cache.GetOrAddAsync(
                key,
                async () =>
                {
                    await Task.Delay(5000); // Simulate slow operation
                    return DateTime.UtcNow.ToString();
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                }
            );
        }
    }
}
