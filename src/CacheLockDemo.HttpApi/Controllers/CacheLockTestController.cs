using CacheLockDemo.CacheLockTest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLockDemo.Controllers
{
    public class CacheLockTestController : CacheLockDemoController
    {
        private readonly ICacheLockTestService _testService;

        public CacheLockTestController(ICacheLockTestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("api/cache-lock-test/concurrent/{key}")]
        public async Task<IActionResult> TestConcurrent(string key)
        {
            var currentTime = DateTime.Now;
            await Task.Delay(5000); // Simulate work
            return Ok(currentTime.ToString("MM/dd/yyyy HH:mm:ss.fff"));
        }

        [HttpGet]
        [Route("api/cache-lock-test/{key}")]
        public async Task<string> TestCacheLock(string key)
        {
            return await _testService.GetOrAddWithLockAsync(key);
        }

        [HttpGet]
        [Route("api/cache-lock-test-concurrent/{key}")]
        public async Task<IActionResult> TestConcurrentAccess(string key)
        {
            var tasks = new List<Task<string>>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(_testService.GetOrAddWithLockAsync(key));
            }

            try
            {
                var results = await Task.WhenAll(tasks);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
