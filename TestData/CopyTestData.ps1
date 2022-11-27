Get-ChildItem "D:\PhoenixDragon\mods" -Recurse -Filter meta.ini | 
Foreach-Object {
    $path = Join-Path -Path 'C:\Users\micro\source\repos\ModlistComparisonTool\TestData\PhoenixDragon\mods' -ChildPath $_.Directory.Name
    $target = $path
    Write-Host $target
    New-Item -Path $target -ItemType Directory
    Copy-Item -Recurse -Force $_.FullName -Destination $target
}
