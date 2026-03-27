# ArchSoft.HashId

[![NuGet](https://img.shields.io/nuget/v/ArchSoft.HashId.svg)](https://www.nuget.org/packages/ArchSoft.HashId/)
[![License](https://img.shields.io/github/license/archsoft-br/hashid.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0%2B-blue.svg)](https://dotnet.microsoft.com/)

A .NET library for generating **deterministic unique identifiers** based on SHA256 hash. Ideal for creating primary keys, record checksums, and data comparison.

[📄 Documentação em Português (Brazilian Portuguese)](README.pt-BR.md)

## 🚀 Installation

```bash
dotnet add package ArchSoft.HashId
```

## ✨ Features

- 🔒 **SHA256 Hash** - Secure cryptographic algorithm
- 🎯 **Deterministic** - Same inputs always generate the same hash
- 🧹 **Smart Normalization** - Removes accidental variations (accents, extra spaces, casing)
- 🌍 **Culture Invariant** - Consistent formatting regardless of system culture
- ⚡ **High Performance** - Optimized for .NET 8+
- 🛡️ **Safe** - Protection against ReDoS and overflows

## 📖 Use Cases

- **Derived Primary Keys** - Generate unique IDs from composite data
- **Record Checksums** - Detect changes in records
- **Deduplication** - Identify duplicate records
- **Data Synchronization** - Compare records between systems
- **Cache Keys** - Deterministic cache keys

## 💻 Basic Usage

### Simple Example

```csharp
using ArchSoft.HashId;

// Generate hash from a string
string hash = HashId.GenerateNormalized("John Doe");
// Result: "3F2A8B..." (SHA256 hash in hexadecimal)
```

### Multiple Fields

```csharp
// Generate hash from multiple fields (automatically concatenated)
var hash = HashId.GenerateNormalized(
    "John Doe",
    DateTime.Parse("1990-05-15"),
    12345.67m
);
```

### With and Without Normalization

```csharp
// With normalization (recommended for user data)
// Removes accents, extra spaces, converts to lowercase
string hash1 = HashId.GenerateNormalized("  John  Doe  ");
string hash2 = HashId.GenerateNormalized("john doe");
// hash1 == hash2 ✅

// Without normalization (for controlled data)
string hash3 = HashId.GenerateUnnormalized("John Doe");
string hash4 = HashId.GenerateUnnormalized("john doe");
// hash3 != hash4
```

## 🔧 Supported Types

Automatic normalization works with:

| Type | Normalization |
|------|-------------|
| `string` | Removes accents, extra spaces, trim, lowercase |
| `decimal` | Invariant format: `0.################` |
| `double` | Invariant format: `0.################` |
| `float` | Invariant format: `0.################` |
| `DateTime` | Converts to UTC: `yyyy-MM-ddTHH:mm:ss` |
| `DateTimeOffset` | Uses the UtcDateTime representation: `yyyy-MM-ddTHH:mm:ss` |
| `bool` | `true` or `false` (lowercase) |
| `Enum` | Enum value name in lowercase |

## 📝 Advanced Examples

### Primary Key for Customer

```csharp
public class Customer
{
    public string Id { get; set; } = HashId.GenerateNormalized(
        Name,
        BirthDate,
        SocialSecurityNumber
    );
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string SocialSecurityNumber { get; set; }
}
```

### Object Checksum

```csharp
public bool RecordChanged(Order order, string previousHash)
{
    var currentHash = HashId.GenerateNormalized(
        order.CustomerId,
        order.OrderDate,
        order.TotalAmount,
        order.Status
    );
    return currentHash != previousHash;
}
```

### Usage in LINQ

```csharp
// Deduplicate records
var uniqueRecords = records
    .GroupBy(r => HashId.GenerateNormalized(r.Name, r.Email))
    .Select(g => g.First())
    .ToList();
```

## 🔍 Custom Normalization

```csharp
using ArchSoft.HashId.Extensions;

// Individual string normalization
string normalized = "  John  ".NormalizeForHashing();
// Result: "john"

// Decimal number normalization
string number = 1234.50m.NormalizeForHashing();
// Result: "1234.5"
```

## ⚠️ Important Notes

- The generated hash is **64 characters** long (hexadecimal representation of SHA256)
- This library generates **deterministic hashes**, not sequential IDs
- For cryptographic purposes, consider adding a salt

## 📋 Requirements

- .NET 8.0 or higher

## 🤝 Contributing

Contributions are welcome! Please open an issue or pull request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🏢 About

Developed by [ArchSoft](https://github.com/archsoft-br) - Software solutions.
