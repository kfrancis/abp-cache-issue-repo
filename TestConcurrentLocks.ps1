# Configuration
$baseUrl = "https://localhost:44367"
$endpoint = "api/cache-lock-test-concurrent"

[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12
[System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true}

Write-Host "Starting stress test to reproduce lock timeout..."

# Launch 20 concurrent requests with the same key
$jobs = 1..20 | ForEach-Object {
    $requestId = $_
    Start-Job -ScriptBlock {
        param($id, $url, $path)
        
        [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12
        [System.Net.ServicePointManager]::ServerCertificateValidationCallback = {$true}
        
        try {
            $webClient = New-Object System.Net.WebClient
            $webClient.Headers.Add("User-Agent", "Mozilla/5.0")
            $fullUrl = "$url/$path/same-key"
            
            $response = $webClient.DownloadString($fullUrl)
            @{
                RequestId = $id
                Success = $true
                Content = $response
            }
        }
        catch {
            @{
                RequestId = $id
                Success = $false
                Error = $_.Exception.Message
            }
        }
    } -ArgumentList $requestId, $baseUrl, $endpoint
}

$results = $jobs | Wait-Job | Receive-Job

Write-Host "`nResults:"
foreach ($result in $results) {
    if ($result.Success) {
        Write-Host "Request $($result.RequestId): Success"
    } else {
        Write-Host "Request $($result.RequestId): Failed - $($result.Error)" -ForegroundColor Red
    }
}

Get-Job | Remove-Job