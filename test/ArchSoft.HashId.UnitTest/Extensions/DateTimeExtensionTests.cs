using System.Globalization;
using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void NormalizeForHashing_ShouldConvertLocalToUtcAndFormatCorrectly()
        {
            // Arrange
            var localTime = new DateTime(2025, 08, 02, 15, 30, 45, DateTimeKind.Local);
            var expected = localTime
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            // Act
            var result = localTime.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldFormatUtcDirectly()
        {
            // Arrange
            var utcTime = new DateTime(2025, 01, 01, 12, 00, 00, DateTimeKind.Utc);
            var expected = utcTime.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            // Act
            var result = utcTime.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NormalizeForHashing_ShouldTreatUnspecifiedAsLocalAndConvertToUtc()
        {
            // Arrange
            var unspecifiedTime = new DateTime(2025, 12, 31, 23, 59, 59, DateTimeKind.Unspecified);
            var expected = DateTime.SpecifyKind(unspecifiedTime, DateTimeKind.Local)
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            // Act
            var result = unspecifiedTime.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}