# SunamoLang

Platform-independent language support library for .NET applications. Provides localization utilities, XLF (XLIFF) file processing, Czech language helpers, and culture management.

## Features

- **Language & Culture Management** - Convert between language codes, country codes, and CultureInfo objects
- **XLF/XLIFF Support** - Load and process XLF localization files with translation dictionaries
- **Czech Language Helpers** - Gender-aware greetings, surname analysis, encoding conversion
- **Translation System** - Key-based translation with automatic resource reloading
- **AppLang Settings** - Manage application language preferences with ComboBox integration

## Key Classes

| Class | Description |
|---|---|
| `AppLangHelper` | Application language settings and culture management |
| `LocaleHelperLang` | Language-to-country and country-to-language conversion |
| `CzechHelper` | Czech text processing (gender forms, encoding conversion) |
| `TranslateDictionary` | Translation key-value storage with auto-reload |
| `XlfResourcesH` | XLF resource loading and processing |
| `CountryLang` | Language-to-country code mapping |

## Installation

```bash
dotnet add package SunamoLang
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer Site](https://sunamo.cz)

## License

MIT
