using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Expections;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.AuthenticationService;

namespace Transport.Notes.Tests.Services
{
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void SetUp()
        {
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockAccountService = new Mock<IAccountService>();
            _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUsername_ReturnsAccountForCorrectUsername()
        {
            string expectedUsername = "testusername";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            Account account = await _authenticationService.Login(expectedUsername, password);

            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
        [Test]
        public void Login_WithIncorrectPasswordForExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testusername";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, password));
            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithNonExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            string expectedUsername = "testusername";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

            string actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            string password = "testpassword";
            string confirmPassword = "confirmpassword";
            RegisterResult expected = RegisterResult.PasswordDoNotMatch;

            RegisterResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            string email = "test@gmail.pl";
            _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());
            RegisterResult expected = RegisterResult.EmailAlreadyExists;

            RegisterResult actual = await _authenticationService.Register(It.IsAny<string>(), email, It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            string username = "testuser";
            _mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());
            RegisterResult expected = RegisterResult.UsernameAlreadyExists;

            RegisterResult actual = await _authenticationService.Register(username, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {
            RegisterResult expected = RegisterResult.Succes;

            RegisterResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }
    }
}
