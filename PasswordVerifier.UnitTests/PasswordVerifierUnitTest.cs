using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordVerifier.UnitTests
{
    [TestClass]
    public class PasswordVerifierUnitTest
    {
        [TestMethod]
        public void Verify_StringLessThan8CharactersAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("1234567");
            Assert.AreEqual(false, result, "Method should have returned false for '1234567' string.");
        }

        [TestMethod]
        public void Verify_StringLongerThan8CharactersAsInputParam_ReturnsTrue()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("1234567lU");
            Assert.AreEqual(true, result, "Method should have returned true for '1234567lU' string.");
        }

        [TestMethod]
        public void Verify_StringWithLengthEqualsTo8CharactersAsInputParam_ReturnsTrue()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("123456lU");
            Assert.AreEqual(true, result, "Method should have returned true for '123456lU' string.");
        }

        [TestMethod]
        public void Verify_NullAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify(null);
            Assert.AreEqual(false, result, "Method should have returned false for null.");
        }

        [TestMethod]
        public void Verify_8SymbolsStringWithoutSymbolsInUpperCaseAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("12345678");
            Assert.AreEqual(false, result, "Method should have returned false for '12345678' string..");
        }

        [TestMethod]
        public void Verify_8SymbolsStringWithoutSymbolsInLowerCaseAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("1234567U");
            Assert.AreEqual(false, result, "Method should have returned false for '1234567U' string..");
        }

        [TestMethod]
        public void Verify_8SymbolsStringWithoutNumbersAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("abcdrtdU");
            Assert.AreEqual(false, result, "Method should have returned false for 'abcdrtdU' string..");
        }
    }
}
