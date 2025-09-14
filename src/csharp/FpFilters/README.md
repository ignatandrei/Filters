# FpFilters

Filters for LINQ and functional programming in C#.

## Features
- Type filters (IsString, IsNumber, IsObject, etc.)
- Miscellaneous filters (Is, IsNot, IsNullOrDefault, etc.)
- Date, Boolean, Array, Object, String, Number, Length, and Position filters

## Installation

You can install via NuGet:

```
dotnet add package FpFilters
```

## Usage

```csharp
using FpFilters;

var numbers = new[] { 1, 2, 3, 4 };
var evenNumbers = numbers.Where(FpFilters.NumberFilters.IsEven);
```

## Building and Publishing

To create and publish the NuGet package:

1. Pack the project:
   ```
   dotnet pack -c Release
   ```
2. Push to NuGet (replace `<API_KEY>` with your NuGet API key):
   ```
   dotnet nuget push bin/Release/FpFilters.*.nupkg --api-key <API_KEY> --source https://api.nuget.org/v3/index.json
   ```

## License
MIT

## Project URL
https://github.com/ignatandrei/Filters
