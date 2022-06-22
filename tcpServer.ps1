$endpoint = new-object System.Net.IPEndPoint([system.net.ipaddress]::any, 1337)
$listener = new-object System.Net.Sockets.TcpListener $endpoint
$listener.start()

write-host "Start"

while ($true) {

$conn=$listener.AcceptTcpClient()
$stream = $conn.GetStream()

[system.io.streamreader]$streamreader = New-Object System.IO.StreamReader($stream,[system.text.encoding]::ASCII)

$line = $streamreader.readline()
Write-host "[$(Get-Date)]: $($line)"
$streamreader.close()
$conn.Close();
}