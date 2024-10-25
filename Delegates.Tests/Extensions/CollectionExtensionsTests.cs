using Delegates.Extensions;
using NUnit.Framework;

namespace Delegates.Tests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void GetMax_ThrowsArgumentNullException_WhenStringCollectionIsNull()
        {
            // Arrange
            List<string> collection = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => collection.GetMax(float.Parse));
        }

        [Test]
        public void GetMax_ReturnsNull_WhenStringCollectionIsEmpty()
        {
            // Arrange
            List<string> collection = [];

            // Act
            string? maxItem = collection.GetMax(float.Parse);

            // Assert
            Assert.That(maxItem, Is.Null);
        }

        [Test]
        public void GetMax_ReturnsMax_WhenStringCollectionIsNotEmpty()
        {
            // Arrange
            List<string> collection = [ "-5", "5", "10", "5", "2", "-10" ];

            // Act
            string? maxItem = collection.GetMax(float.Parse);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(maxItem, Is.Not.Null);
                Assert.That(maxItem?.GetType(), Is.EqualTo(typeof(string)));
                Assert.That(maxItem, Is.EqualTo("10"));
            });
        }
    }
}
