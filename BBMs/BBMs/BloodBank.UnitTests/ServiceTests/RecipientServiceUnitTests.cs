using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Moq;

namespace BloodBank.UnitTests.ServiceTests
{
    [TestFixture]
    public class RecipientServiceTests
    {
        private Mock<IRecipientRepository> recipientRepositoryMock;
        private RecipientService recipientService;

        [SetUp]
        public void Setup()
        {
            recipientRepositoryMock = new Mock<IRecipientRepository>();
            recipientService = new RecipientService(recipientRepositoryMock.Object);
        }

        [Test]
        public void GetRecipientById_ValidId_ReturnsRecipient()
        {
            // Arrange
            int recipientId = 1;
            Recipient expectedRecipient = new Recipient { RecipientId = recipientId, RecipientName = "Recipient A", Age = 30, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" };
            recipientRepositoryMock.Setup(repo => repo.GetRecipientById(recipientId)).Returns(expectedRecipient);

            // Act
            Recipient result = recipientService.GetRecipientById(recipientId);

            // Assert
            Assert.AreEqual(expectedRecipient, result);
        }

        [Test]
        public void GetAllRecipients_ReturnsAllRecipients()
        {
            // Arrange
            List<Recipient> expectedRecipients = new List<Recipient>
        {
            new Recipient { RecipientId = 1, RecipientName = "Recipient A", Age = 30, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" },
            new Recipient { RecipientId = 2, RecipientName = "Recipient B", Age = 40, BloodGroup = "B+", ContactNumber = "9876543210", Gender = "Female" }
        };
            recipientRepositoryMock.Setup(repo => repo.GetAllRecipients()).Returns(expectedRecipients);

            // Act
            ICollection<Recipient> result = recipientService.GetAllRecipients();

            // Assert
            Assert.AreEqual(expectedRecipients.Count, result.Count);
            Assert.AreEqual(expectedRecipients, result);
        }

        [Test]
        public void AddRecipient_ValidRecipient_ReturnsTrue()
        {
            // Arrange
            RecipientDto createRecipient = new RecipientDto { RecipientName = "Recipient A", Age = 30, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" };
            recipientRepositoryMock.Setup(repo => repo.AddRecipient(It.IsAny<Recipient>())).Returns(true);

            // Act
            bool result = recipientService.AddRecipient(createRecipient);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteRecipient_ValidRecipient_CallsDeleteRecipientOnRepository()
        {
            // Arrange
            Recipient recipient = new Recipient { RecipientId = 1, RecipientName = "Recipient A", Age = 30, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" };

            // Act
            recipientService.DeleteRecipient(recipient);

            // Assert
            recipientRepositoryMock.Verify(repo => repo.DeleteRecipient(recipient), Times.Once);
        }

        [Test]
        public void UpdateRecipient_ValidRecipient_CallsUpdateRecipientOnRepository()
        {
            // Arrange
            Recipient recipient = new Recipient { RecipientId = 1, RecipientName = "Recipient A", Age = 30, BloodGroup = "A+", ContactNumber = "1234567890", Gender = "Male" };

            // Act
            recipientService.UpdateRecipient(recipient);

            // Assert
            recipientRepositoryMock.Verify(repo => repo.UpdateRecipient(recipient), Times.Once);
        }
    }

}
