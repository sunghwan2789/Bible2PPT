using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bible2PPT.Services;
using Xunit;

namespace Bible2PPT.Tests.Services
{
    public class HiddenPowerPointTest
    {
        private const string PowerPointProcessName = @"POWERPNT";

        private bool IsPowerPointRunning()
            => Process.GetProcessesByName(PowerPointProcessName).Any();

        [Fact]
        public async void TestLifetime()
        {
            // 파워포인트를 잘 켜고 끄는지 확인하는 테스트이므로
            // 파워포인트가 이미 켜졌으면 테스트를 건너뜀
            if (IsPowerPointRunning())
            {
                return;
            }

            using (var powerpoint = new HiddenPowerPoint())
            {
                Assert.True(IsPowerPointRunning());
            }

            // COM 완전 정리를 위해 GC 작동
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // 일부 환경에서 파워포인트가 바로 종료되지는 않으므로
            // 10번까지 3초마다 파워포인트가 끝났는지 확인
            foreach (var _ in Enumerable.Range(0, 10))
            {
                await Task.Delay(3000).ConfigureAwait(false);
                if (!IsPowerPointRunning())
                {
                    break;
                }
            }
            Assert.False(IsPowerPointRunning());
        }
    }
}
