using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Moq;

namespace BloodBank.UnitTests.ServiceTests
{
    [TestFixture]
    public class BloodBankCenterServiceTests
    {
        private Mock<IBloodBankCenterRepository> bloodBankCenterRepositoryMock;
        private BloodBankCenterService bloodBankCenterService;

        [SetUp]
        public void Setup()
        {
            bloodBankCenterRepositoryMock = new Mock<IBloodBankCenterRepository>();
            bloodBankCenterService = new BloodBankCenterService(bloodBankCenterRepositoryMock.Object);
        }

        [Test]
        public void GetAllBloodBankCenters_ReturnsAllBloodBankCenters()
        {
            // Arrange
            List<BloodBankCenter> expectedBloodBankCenters = new List<BloodBankCenter>
        {
            new BloodBankCenter { BloodBankId = 1, CenterName = "Center A", Location="LocationA"},
            new BloodBankCenter { BloodBankId = 2, CenterName = "Center B",Location="LocationB" }
        };
            bloodBankCenterRepositoryMock.Setup(repo => repo.GetAllBloodBankCenter()).Returns(expectedBloodBankCenters);

            // Act
            ICollection<BloodBankCenter> result = bloodBankCenterService.GetAllBloodBankCenters();

            // Assert
            Assert.AreEqual(expectedBloodBankCenters.Count, result.Count);
            Assert.AreEqual(expectedBloodBankCenters, result);
        }

        [Test]
        public void GetBloodBankCenterById_ValidId_ReturnsBloodBankCenter()
        {
            // Arrange
            int bloodBankCenterId = 1;
            BloodBankCenter expectedBloodBankCenter = new BloodBankCenter { BloodBankId = bloodBankCenterId, CenterName = "Center A", Location = "Location A" };
            bloodBankCenterRepositoryMock.Setup(repo => repo.GetBloodBankCenterById(bloodBankCenterId)).Returns(expectedBloodBankCenter);

            // Act
            BloodBankCenter result = bloodBankCenterService.GetBloodBankCenterById(bloodBankCenterId);

            // Assert
            Assert.AreEqual(expectedBloodBankCenter, result);
        }

        [Test]
        public void AddBloodBankCenter_ValidBloodBankCenter_ReturnsTrue()
        {
            // Arrange
            BloodBankCenterDto createBank = new BloodBankCenterDto { CenterName = "Center A", Location = "Location A" };
            bloodBankCenterRepositoryMock.Setup(repo => repo.AddBloodBankCenter(It.IsAny<BloodBankCenter>())).Returns(true);

            // Act
            bool result = bloodBankCenterService.AddBloodBankCenter(createBank);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteBloodBankCenter_ValidBloodBankCenter_CallsDeleteBloodBankCenterOnRepository()
        {
            // Arrange
            BloodBankCenter bloodBankCenter = new BloodBankCenter { BloodBankId = 1, CenterName = "Center A", Location="Location A" };

            // Act
            bloodBankCenterService.DeleteBloodBankCenter(bloodBankCenter);

            // Assert
            bloodBankCenterRepositoryMock.Verify(repo => repo.DeleteBloodBankCenter(bloodBankCenter), Times.Once);
        }

        [Test]
        public void UpdateBloodBankCenter_ValidBloodBankCenter_CallsUpdateBloodBankCenterOnRepository()
        {
            // Arrange
            BloodBankCenter bloodBankCenter = new BloodBankCenter { BloodBankId = 1, CenterName = "Center A", Location = "LocationA" };

            // Act
            bloodBankCenterService.UpdateBloodBankCenter(bloodBankCenter);

            // Assert
            bloodBankCenterRepositoryMock.Verify(repo => repo.UpdateBloodBankCenter(bloodBankCenter), Times.Once);
        }
    }

}
