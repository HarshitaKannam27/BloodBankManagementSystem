using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Moq;

namespace BloodBank.UnitTests.ServiceTests
{
    [TestFixture]
public class BloodBagServiceTests
{
    private Mock<IBloodBagRepository> bloodBagRepositoryMock;
    private BloodBagService bloodBagService;

    [SetUp]
    public void Setup()
    {
        bloodBagRepositoryMock = new Mock<IBloodBagRepository>();
        bloodBagService = new BloodBagService(bloodBagRepositoryMock.Object);
    }

    [Test]
    public void GetAllBloodBags_ReturnsAllBloodBags()
    {
        // Arrange
        List<BloodBag> expectedBloodBags = new List<BloodBag>
        {
            new BloodBag { BagId = 1, BloodGroup = "A+", Quantity = 10 },
            new BloodBag { BagId = 2, BloodGroup = "B+", Quantity = 5 }
        };
        bloodBagRepositoryMock.Setup(repo => repo.GetAllBloodBags()).Returns(expectedBloodBags);

        // Act
        ICollection<BloodBag> result = bloodBagService.GetAllBloodBags();

        // Assert
        Assert.AreEqual(expectedBloodBags.Count, result.Count);
        Assert.AreEqual(expectedBloodBags, result);
    }

    [Test]
    public void GetBloodBagById_ValidId_ReturnsBloodBag()
    {
        // Arrange
        int bloodBagId = 1;
        BloodBag expectedBloodBag = new BloodBag { BagId = bloodBagId, BloodGroup = "A+", Quantity = 10 };
        bloodBagRepositoryMock.Setup(repo => repo.GetBloodBagById(bloodBagId)).Returns(expectedBloodBag);

        // Act
        BloodBag result = bloodBagService.GetBloodBagById(bloodBagId);

        // Assert
        Assert.AreEqual(expectedBloodBag, result);
    }

    [Test]
    public void GetBloodBagByBloodGroup_ValidBloodGroup_ReturnsBloodBagDtos()
    {
        // Arrange
        string bloodGroup = "A+";
        ICollection<BloodBag> bloodBags = new List<BloodBag>
        {
            new BloodBag { BagId = 1, BloodGroup = bloodGroup, Quantity = 10 },
            new BloodBag { BagId = 2, BloodGroup = bloodGroup, Quantity = 5 }
        };
        bloodBagRepositoryMock.Setup(repo => repo.GetBloodBagByBloodGroup(bloodGroup)).Returns(bloodBags);

        // Act
        ICollection<BloodBagDto> result = bloodBagService.GetBloodBagByBloodGroup(bloodGroup);

        // Assert
        Assert.AreEqual(bloodBags.Count, result.Count);
        foreach (var bloodBagDto in result)
        {
            Assert.AreEqual(bloodGroup, bloodBagDto.BloodGroup);
        }
    }

    [Test]
    public void AddBloodBag_ValidBloodBag_ReturnsTrue()
    {
        // Arrange
        BloodBagDto createBag = new BloodBagDto { BloodGroup = "A+", Quantity = 10 };
        bloodBagRepositoryMock.Setup(repo => repo.AddBloodBag(It.IsAny<BloodBag>())).Returns(true);

        // Act
        bool result = bloodBagService.AddBloodBag(createBag);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void DeleteBloodBag_ValidBloodBag_CallsDeleteBloodBagOnRepository()
    {
        // Arrange
        BloodBag bloodBag = new BloodBag {  BagId = 1, BloodGroup = "A+", Quantity = 10 };

        // Act
        bloodBagService.DeleteBloodBag(bloodBag);

        // Assert
        bloodBagRepositoryMock.Verify(repo => repo.DeleteBloodBag(bloodBag), Times.Once);
    }

    [Test]
    public void UpdateBloodBag_ValidBloodBag_CallsUpdateBloodBagOnRepository()
    {
        // Arrange
        BloodBag bloodBag = new BloodBag { BagId = 1, BloodGroup = "A+", Quantity = 10 };

        // Act
        bloodBagService.UpdateBloodBag(bloodBag);

        // Assert
        bloodBagRepositoryMock.Verify(repo => repo.UpdateBloodBag(bloodBag), Times.Once);
    }
}

}
