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
            Assert.AreEqual(false, result, "Method should have returned false for '123456lU' string.");
        }

        [TestMethod]
        public void Verify_NullAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify(null);
            Assert.AreEqual(false, result, "Method should have returned false for null.");
        }

        [TestMethod]
        public void Verify_9SymbolsStringWithoutSymbolsInUpperCaseAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("12345678");
            Assert.AreEqual(false, result, "Method should have returned false for '123456789' string..");
        }

        [TestMethod]
        public void Verify_9SymbolsStringWithoutSymbolsInLowerCaseAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("01234567U");
            Assert.AreEqual(false, result, "Method should have returned false for '01234567U' string..");
        }

        [TestMethod]
        public void Verify_9SymbolsStringWithoutNumbersAsInputParam_ReturnsFalse()
        {
            var passwordVerifier = new PasswordVerifier();
            var result = passwordVerifier.Verify("abcdrtdfU");
            Assert.AreEqual(false, result, "Method should have returned false for 'abcdrtdfU' string..");
        }

        [TestMethod]
        public void Verify_ValidPasswordStringButWithoutUppercaseSymbolAsInputParam_ThrowsException()
        {
            var passwordVerifier = new PasswordVerifier();
            var gotValidationException = false;
            var exceptionMessage = string.Empty;
            try
            {
                passwordVerifier.Verify("a2password", new[] {RuleKey.Length, RuleKey.NotNull, RuleKey.ContainsUpperCase});
            }
            catch (PasswordVerificationException e)
            {
                exceptionMessage = e.Message;
                gotValidationException = true;
            }
            catch
            {
                Assert.Fail("Exception of invalid type was generated");
            }
            Assert.AreEqual(true, gotValidationException, "Method should have thrown an exception for 'abcdrtdfU' string..");
            Assert.AreEqual($"Validation rule(s) were violated: {RuleKey.ContainsUpperCase}", exceptionMessage);
        }
    }
}
