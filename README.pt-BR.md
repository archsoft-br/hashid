# ArchSoft.HashId

[![NuGet](https://img.shields.io/nuget/v/ArchSoft.HashId.svg)](https://www.nuget.org/packages/ArchSoft.HashId/)
[![License](https://img.shields.io/github/license/archsoft-br/hashid.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0%2B-blue.svg)](https://dotnet.microsoft.com/)

Uma biblioteca .NET para geração de **identificadores únicos determinísticos** baseados em hash SHA256. Ideal para criação de chaves primárias, checksums de registros e comparação de dados.

[📄 English Documentation](README.md)

## 🚀 Instalação

```bash
dotnet add package ArchSoft.HashId
```

## ✨ Características

- 🔒 **Hash SHA256** - Algoritmo criptográfico seguro
- 🎯 **Determinístico** - Mesmas entradas sempre geram o mesmo hash
- 🧹 **Normalização Inteligente** - Remove variações acidentais (acentos, espaços extras, maiúsculas/minúsculas)
- 🌍 **Cultura Invariante** - Formatação consistente independente da cultura do sistema
- ⚡ **Alto Desempenho** - Otimizado para .NET 8+
- 🛡️ **Seguro** - Proteção contra ReDoS e overflows

## 📖 Casos de Uso

- **Chaves primárias derivadas** - Gere IDs únicos a partir de dados compostos
- **Checksums de registros** - Detecte alterações em registros
- **Deduplicação** - Identifique registros duplicados
- **Sincronização de dados** - Compare registros entre sistemas
- **Chaves de cache** - Chaves de cache determinísticas

## 💻 Uso Básico

### Exemplo Simples

```csharp
using ArchSoft.HashId;

// Gerar hash de uma string
string hash = HashId.GenerateNormalized("João da Silva");
// Resultado: "3F2A8B..." (hash SHA256 em hexadecimal)
```

### Múltiplos Campos

```csharp
// Gerar hash de múltiplos campos (concatenados automaticamente)
var hash = HashId.GenerateNormalized(
    "João da Silva",
    DateTime.Parse("1990-05-15"),
    12345.67m
);
```

### Com e Sem Normalização

```csharp
// Com normalização (recomendado para dados de usuário)
// Remove acentos, espaços extras, converte para minúsculas
string hash1 = HashId.GenerateNormalized("  João  da Silva  ");
string hash2 = HashId.GenerateNormalized("joao da silva");
// hash1 == hash2 ✅

// Sem normalização (para dados já controlados)
string hash3 = HashId.GenerateUnnormalized("João da Silva");
string hash4 = HashId.GenerateUnnormalized("joão da silva");
// hash3 != hash4
```

## 🔧 Tipos Suportados

A normalização automática funciona com:

| Tipo | Normalização |
|------|-------------|
| `string` | Remove acentos, espaços extras, trim, minúsculas |
| `decimal` | Formato invariante: `0.################` |
| `double` | Formato invariante: `0.################` |
| `float` | Formato invariante: `0.################` |
| `DateTime` | Converte para UTC: `yyyy-MM-ddTHH:mm:ss` |
| `DateTimeOffset` | Utiliza a representação UTC: `yyyy-MM-ddTHH:mm:ss` |
| `bool` | `true` ou `false` (minúsculas) |
| `Enum` | Nome do valor em minúsculas |

## 📝 Exemplos Avançados

### Chave Primária para Cliente

```csharp
public class Cliente
{
    public string Id { get; set; } = HashId.GenerateNormalized(
        Nome,
        DataNascimento,
        CPF
    );
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}
```

### Checksum de Objeto

```csharp
public bool RegistroAlterado(Pedido pedido, string hashAnterior)
{
    var hashAtual = HashId.GenerateNormalized(
        pedido.ClienteId,
        pedido.DataPedido,
        pedido.ValorTotal,
        pedido.Status
    );
    return hashAtual != hashAnterior;
}
```

### Uso em LINQ

```csharp
// Deduplicar registros
var unicos = registros
    .GroupBy(r => HashId.GenerateNormalized(r.Nome, r.Email))
    .Select(g => g.First())
    .ToList();
```

## 🔍 Normalização Personalizada

```csharp
using ArchSoft.HashId.Extensions;

// Normalização de string individual
string normalizado = "  João  ".NormalizeForHashing();
// Resultado: "joao"

// Normalização de número decimal
string numero = 1234.50m.NormalizeForHashing();
// Resultado: "1234.5"
```

## ⚠️ Notas Importantes

- O hash gerado tem **64 caracteres** (representação hexadecimal do SHA256)
- Esta biblioteca gera **hashes determinísticos**, não IDs sequenciais
- Para fins criptográficos, considere adicionar um salt

## 📋 Requisitos

- .NET 8.0 ou superior

## 🤝 Contribuição

Contribuições são bem-vindas! Por favor, abra uma issue ou pull request.

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## 🏢 Sobre

Desenvolvido por [ArchSoft](https://github.com/archsoft-br) - Soluções em software.
