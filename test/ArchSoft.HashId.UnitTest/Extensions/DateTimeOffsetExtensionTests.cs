using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class DateTimeOffsetExtensionTests
    {
        [Fact]
        public void NormalizeForHashing_ShouldUseUtcDateTime()
        {
            var dto = new DateTimeOffset(2025, 08, 02, 10, 00, 00, TimeSpan.FromHours(-3));
            var expected = "2025-08-02T13:00:00";

            var result = dto.NormalizeForHashing();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_DifferentOffsets_SameUtc_ShouldProduceSameResult()
        {
            var dtoBrasilia = new DateTimeOffset(2025, 08, 02, 10, 00, 00, TimeSpan.FromHours(-3));
            var dtoTokyo = new DateTimeOffset(2025, 08, 02, 22, 00, 00, TimeSpan.FromHours(9));

            var resultBrasilia = dtoBrasilia.NormalizeForHashing();
            var resultTokyo = dtoTokyo.NormalizeForHashing();

            Assert.Equal(resultBrasilia, resultTokyo);
        }

        [Fact]
        public void NormalizeForHashing_UtcOffset_ShouldFormatCorrectly()
        {
            var dto = new DateTimeOffset(2025, 01, 01, 12, 00, 00, TimeSpan.Zero);
            var expected = "2025-01-01T12:00:00";

            var result = dto.NormalizeForHashing();

            Assert.Equal(expected, result);
        }
    }
}
