# SunamoLang

## Short description

Knihovna podpory jazyků pro .NET aplikace: lokalizační nástroje, zpracování souborů XLF (XLIFF), pomocné funkce pro češtinu a správa kultur. Obsahuje Runner a testy.


Platform-independent language support library for .NET applications. Provides localization utilities, XLF (XLIFF) file processing, Czech language helpers, and culture management.

## Overview

SunamoLang is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development.

## Main Components

### Key Classes

- **CountryLang** - Language-to-country code mapping
- **LocaleHelperLang** - Locale conversion operations
- **AppLang** - Application language settings model
- **AppLangHelper** - Language settings and culture management
- **AppLangConverter** - AppLang to/from string conversion
- **CzechHelper** - Czech language text processing
- **TranslateDictionary** - Translation key-value storage with auto-reload
- **XlfResourcesH** - XLF resource loading and processing
- **ResourcesDuo** - Strongly-typed resource manager

## Installation

```bash
dotnet add package SunamoLang
```

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions** (v10.0.2)

## Package Information

- **Package Name**: SunamoLang
- **Target Frameworks**: net10.0, net9.0, net8.0
- **License**: MIT

## Related Packages

This package is part of the Sunamo package ecosystem. For more information about related packages, visit the main repository.

## License

MIT

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 0/24 (0.0 %) |
| Public methods referenced by tests | 0/36 (0.0 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoLang","container":"pinp","testProjects":1,"publicTypes":24,"typesReferencedByTests":0,"publicMethods":36,"methodsReferencedByTests":0,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
