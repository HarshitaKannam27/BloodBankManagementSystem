using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Moq;

namespace BloodBank.UnitTests.ServiceTests
{
    [TestFixture]
    public class DonorServiceUnitTests
    {
            private Mock<IDonorRepository> donorRepositoryMock;
            private DonorService donorService;

            [SetUp]
            public void Setup()
            {
                donorRepositoryMock = new Mock<IDonorRepository>();
                donorService = new DonorService(donorRepositoryMock.Object);
            }

            [Test]
            public void GetAllDonors_ReturnsAllDonors()
            {
                // Arrange
                List<Donor> expectedDonors = new List<Donor>
        {
            new Donor { DonorId = 1, DonorName = "Donor1" },
            new Donor { DonorId = 2, DonorName = "Donor2" }
        };
                donorRepositoryMock.Setup(repo => repo.GetAllDonors()).Returns(expectedDonors);

                // Act
                ICollection<Donor> result = donorService.GetAllDonors();

                // Assert
                Assert.AreEqual(expectedDonors.Count, result.Count);
                Assert.AreEqual(expectedDonors, result);
            }

            [Test]
            public void GetDonorById_ValidId_ReturnsDonor()
            {
                // Arrange
                int donorId = 1;
                Donor expectedDonor = new Donor { DonorId = donorId, DonorName = "Donor1" };
                donorRepositoryMock.Setup(repo => repo.GetDonorById(donorId)).Returns(expectedDonor);

                // Act
                Donor result = donorService.GetDonorById(donorId);

                // Assert
                Assert.AreEqual(expectedDonor, result);
            }

            [Test]
            public void AddDonor_ValidDonor_ReturnsTrue()
            {
                // Arrange
                DonorDto createDonor = new DonorDto { DonorName = "Donor1", Age = 25, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" };
                donorRepositoryMock.Setup(repo => repo.AddDonor(It.IsAny<Donor>())).Returns(true);

                // Act
                bool result = donorService.AddDonor(createDonor);

                // Assert
                Assert.IsTrue(result);
            }

            [Test]
            public void DeleteDonor_ValidDonor_CallsDeleteDonorOnRepository()
            {
                // Arrange
                Donor donor = new Donor { DonorId = 1, DonorName = "Donor1" };

                // Act
                donorService.DeleteDonor(donor);

                // Assert
                donorRepositoryMock.Verify(repo => repo.DeleteDonor(donor), Times.Once);
            }

            [Test]
            public void UpdateDonor_ValidDonor_CallsUpdateDonorOnRepository()
            {
                // Arrange
                Donor newDonor = new Donor { DonorId = 1, DonorName = "Donor1" };

                // Act
                donorService.UpdateDonor(newDonor);

                // Assert
                donorRepositoryMock.Verify(repo => repo.UpdateDonor(newDonor), Times.Once);
            }
     }

}

