# PayFastSignatureHelper
C# helper library for generating PHP-compatible PayFast MD5 signatures.   
Solves common encoding and hashing issues when integrating PayFast in .NET apps.

Requirements

Target Framework .NET 8.0+
C# 10 or higher

Installation
Install via NuGet Package Manager Console:
"dotnet add package PayFastSignatureHelper"

Or via Visual Studio:
Tools → NuGet Package Manager → Manage NuGet Packages → Search "PayFastSignatureHelper

Usage (Very Important)

This package provides a single namespace: PayFastSignatureHelper, which contains the main class PayFastSigner.
To generate a valid PayFast signature, call generatePayFastSignature() and pass in your data as a dictionary of key-value pairs.
You may also pass in your passphrase if you have one set up in your PayFast account, but this is optional.

Make sure your dictionary strictly follows the official PayFast API parameter structure — any required missing or extra fields that arent included in the documentation, incorrect order,
or formatting differences will result in a signature mismatch when compared to PayFast’s generated signature.


Author
Ngazii
South African Software Engineer
“Because signature mismatches are not the vibe.”

License
Licensed under the MIT License.