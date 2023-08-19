using Xunit;

namespace ContentToolLibrary.Tests
{
    public class ValidationServiceTests
    {
        [Fact]
        public void ShouldValidateDateFormat()
        {
            // Arrange
            var validate = new ValidationService();

            var validDate1 = "2023-03-01";
            var validDate2 = "2023-11-29";
            var validDate3 = "2023-02-28";

            var invalidDate1 = "2023-20-02";
            var invalidDate2 = "02-01-2023";
            var invalidDate3 = "2023-02-31";
            var invalidDate4 = "2023-1-1";

            // Assert
            Assert.True(validate.IsValidDate(validDate1));
            Assert.True(validate.IsValidDate(validDate2));
            Assert.True(validate.IsValidDate(validDate3));
            
            Assert.False(validate.IsValidDate(invalidDate1));
            Assert.False(validate.IsValidDate(invalidDate2));
            Assert.False(validate.IsValidDate(invalidDate3));
            Assert.False(validate.IsValidDate(invalidDate4));
        }

        [Fact]
        public void ShouldValidateDuration()
        {
            // Arrange
            var validate = new ValidationService();

            var validDuration1 = "00.08";
            var validDuration2 = "00.15";
            var validDuration3 = "00.30";

            var invalidDuration1 = "12";
            var invalidDuration2 = ".10";
            var invalidDuration3 = "0.8";
            var invalidDuration4 = "00.5";

            // Assert
            Assert.True(validate.IsValidSlideDuration(validDuration1));
            Assert.True(validate.IsValidSlideDuration(validDuration2));
            Assert.True(validate.IsValidSlideDuration(validDuration3));

            Assert.False(validate.IsValidSlideDuration(invalidDuration1));
            Assert.False(validate.IsValidSlideDuration(invalidDuration2));
            Assert.False(validate.IsValidSlideDuration(invalidDuration3));
            Assert.False(validate.IsValidSlideDuration(invalidDuration4));
        }
    }
}