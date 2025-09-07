# Run tests and collect coverage

dotnet test FpFilters.Tests --collect:"XPlat Code Coverage"

# Find the latest coverage file
$coverageFile = Get-ChildItem -Path FpFilters.Tests/TestResults -Recurse -Filter coverage.cobertura.xml | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Generate HTML report
if ($coverageFile) {
    reportgenerator -reports:$coverageFile.FullName -targetdir:src/csharp/FpFilters.Tests/TestResults/CoverageReport -reporttypes:Html
    Write-Host "Coverage report generated at src/csharp/FpFilters.Tests/TestResults/CoverageReport/index.html"
} else {
    Write-Host "Coverage file not found."
}
