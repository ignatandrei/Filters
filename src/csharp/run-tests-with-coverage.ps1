# Run tests and collect coverage
dotnet test FpFilters.Tests --collect:"XPlat Code Coverage"
    
# Find the latest coverage file
$coverageFile = Get-ChildItem -Path FpFilters.Tests/TestResults -Recurse -Filter coverage.cobertura.xml | Sort-Object LastWriteTime -Descending | Select-Object -First 1

if ($coverageFile) {
    # Generate HTML report
    reportgenerator -reports:$coverageFile.FullName -targetdir:FpFilters.Tests/TestResults/CoverageReport -reporttypes:Html
    Write-Host "Coverage report generated at src/csharp/FpFilters.Tests/TestResults/CoverageReport/index.html"

    # Parse coverage percentage from cobertura XML
    [xml]$xml = Get-Content $coverageFile.FullName
    $coverage = [math]::Round(([double]$xml.coverage.Attributes["line-rate"].Value * 100), 2)

    Write-Host "Total line coverage: $coverage%"

    if ($coverage -lt 100) {
        Write-Host "Code coverage is less than 100%. Failing the build."
        exit 1
    } else {
        Write-Host "Code coverage is 100%."
    }
} else {
    Write-Host "Coverage file not found."
    exit 1
}
