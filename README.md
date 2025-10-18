# PayFastSignatureHelper
# PayFastSignatureHelper

**C# helper library for generating PHP-compatible PayFast MD5 signatures.**  
Solves the common pain point for .NET developers integrating PayFast by providing **consistent URL encoding and signature generation** that matches PHP implementations.

---

## Features

- Generate PayFast-compatible MD5 signatures in .NET.
- Handles **URL encoding** exactly like PHP’s `urlencode` for perfect signature matches.
- Fully tested with **unit tests**.
- Ready to package as a **NuGet library** for easy integration.

---

## Installation

### Option 1: NuGet (when published)
```bash
dotnet add package PayFastSignatureHelper
