param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
$dbMigratorFolder = Join-Path $slnFolder "src/CacheLockDemo.DbMigrator"
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/cachelockdemo-db-migrator:$version .




Write-Host "********* BUILDING Web Application *********" -ForegroundColor Green
$webFolder = Join-Path $slnFolder "src/CacheLockDemo.Web"
Set-Location $webFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/cachelockdemo-web:$version .






### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder