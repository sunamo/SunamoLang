Set-Location 'E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoLang'
dotnet clean 'SunamoLang/SunamoLang.csproj' -v quiet 2>&1 | Out-Null
$output = dotnet build 'SunamoLang/SunamoLang.csproj' -f net10.0 -v detailed 2>&1
$warnings = $output | Select-String 'warning CS'
Write-Host "Total warning lines: $($warnings.Count)"
$unique = $warnings | ForEach-Object {
    if ($_.Line -match '([^\\]+\.\w+\(\d+,\d+\)): (warning CS\d+: .+?)(?:\s*\[)') {
        "$($Matches[1]): $($Matches[2])"
    }
} | Sort-Object -Unique
# Exclude CS1591 (missing XML comments) - too many, separate issue
$nonDoc = $unique | Where-Object { $_ -notmatch 'CS1591' }
Write-Host "Non-CS1591 warnings: $($nonDoc.Count)"
foreach ($w in $nonDoc) { Write-Host $w }
Write-Host ""
Write-Host "CS1591 count: $(($unique | Where-Object { $_ -match 'CS1591' }).Count)"
