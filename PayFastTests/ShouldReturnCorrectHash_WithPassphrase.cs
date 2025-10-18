namespace PayFastTests
{
    public class ShouldReturnCorrectHash_WithPassphrase
    {
        [Fact]
        public void GenerateSignature_ReturnsCorrectHash_WithPassphrase()
        {
            Dictionary<string, string> data = new Dictionary<string, string>
           {
               { "merchant_id", "10033543" } ,
               { "merchant_key", "34xw0ot2cjz69" } ,
               { "return_url","https://www.youtube.com/watch?v=ZbZSe6N_BXs&list=RDZbZSe6N_BXs&start_radio=1" } ,
               { "cancel_url", "https://www.youtube.com/watch?v=ZbZSe6N_BXs&list=RDZbZSe6N_BXs&start_radio=1" } ,
               { "notify_url", "https://webhook.site/ca168de6-e226-4397-9a2c-8baf79fbb336" } ,
               { "name_first", "Test" } ,
               { "name_last","Test Doe" } ,
               { "email_address","test1234@test.com" } ,
               { "cell_number","0230000000" },
               { "m_payment_id", "123456" } ,
               { "amount","100.00" },
               { "item_name", "Product" },
               { "item_description","Product Item" }
           };
            string passphrase = "Swf7w0rd15753", expectedHash = "afced4f3501fb6a8362e436c90611563";

            string actualHash = PayFastSignatureHelper.PayFastSigner.generatePayFastSignature(data,passphrase);

            Assert.Equal(expectedHash, actualHash);

        }
    }
}