using Microsoft.VisualStudio.TestTools.UnitTesting;
using secure_privacy_task2;

namespace secure_privacy_task2_tests_unit
{
    [TestClass]
    public class BinaryStringUnitTests
    {
        [TestMethod]
        public void VerifyBinaryString_Success()
        {
            Assert.IsTrue("101101001101011011000010".ValidateBinaryString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBinaryStringException), "Binary String is null or empt")]
        public void VerifyEmptyBinaryString_Fail()
        {
            "".ValidateBinaryString();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBinaryStringException), "Binary String contains invalid prefix")]
        public void VerifyBinaryStringWithPrefixInvalid_Fail()
        {
            Assert.IsFalse("101101001101011010000011".ValidateBinaryString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBinaryStringException), "Binary String contains invalid characters")]
        public void VerifyBinaryStringWithCharacterInvalid_Fail()
        {
            Assert.IsFalse("1011010O1101011011000010".ValidateBinaryString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBinaryStringException), "Binary String with 0's quantity different of 1's quantity")]
        public void VerifyBinaryStringWith0sQuantityDifferent1sQuantity_Fail()
        {
            "10110100110101101100001".ValidateBinaryString();
        }
    }
}
