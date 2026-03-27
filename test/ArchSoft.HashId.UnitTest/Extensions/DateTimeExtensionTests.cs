using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void NormalizeForHashing_ShouldConvertLocalToUtcAndFormatCorrectly()
        {
            var localTime = new DateTime(2025, 08, 02, 15, 30, 45, DateTimeKind.Local);
            var expected = localTime
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            var result = localTime.NormalizeForHashing();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldFormatUtcDirectly()
        {
            var utcTime = new DateTime(2025, 01, 01, 12, 00, 00, DateTimeKind.Utc);
            var expected = utcTime.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            var result = utcTime.NormalizeForHashing();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldTreatUnspecifiedAsUtc()
        {
            var unspecifiedTime = new DateTime(2025, 12, 31, 23, 59, 59, DateTimeKind.Unspecified);
            var expected = "2025-12-31T23:59:59";

            var result = unspecifiedTime.NormalizeForHashing();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_UnspecifiedAndUtc_ShouldProduceSameResult()
        {
            var unspecified = new DateTime(2025, 06, 15, 10, 30, 00, DateTimeKind.Unspecified);
            var utc = new DateTime(2025, 06, 15, 10, 30, 00, DateTimeKind.Utc);

            var resultUnspecified = unspecified.NormalizeForHashing();
            var resultUtc = utc.NormalizeForHashing();

            Assert.Equal(resultUtc, resultUnspecified);
        }
    }
}
