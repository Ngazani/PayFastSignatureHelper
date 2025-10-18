
namespace PayFastTests
{
    public class ShouldThrowExceptionIfDictionaryIsEmpty
    {
        [Fact]
        public void GenerateSignature_ThrowsException_OnEmptyData()
        {
            Dictionary<string, string>? data = null;
            Assert.Throws<ArgumentException>(() => PayFastSignatureHelper.PayFastSigner.generatePayFastSignature(data, null));
        }
    }
}
