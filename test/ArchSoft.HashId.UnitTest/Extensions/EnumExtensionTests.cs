using ArchSoft.HashId.Extensions;

namespace ArchSoft.HashId.UnitTest.Extensions
{
    public class EnumExtensionTests
    {
        [Theory]
        [InlineData(DayOfWeek.Sunday, "sunday")]
        [InlineData(DayOfWeek.Monday, "monday")]
        [InlineData(DayOfWeek.Tuesday, "tuesday")]
        [InlineData(DayOfWeek.Wednesday, "wednesday")]
        [InlineData(DayOfWeek.Thursday, "thursday")]
        [InlineData(DayOfWeek.Friday, "friday")]
        [InlineData(DayOfWeek.Saturday, "saturday")]
        public void NormalizeForHashing_ShouldNormalizeDayOfWeekEnum(DayOfWeek input, string expected)
        {
            // Act
            var result = input.NormalizeForHashing();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}