try{ 
  .\Ajf.NsPlanner3.Setup.exe
  if ($LASTEXITCODE -ne 0) { Exit 1 }

  #Get-ChildItem -Path "." -File -Recurse -exclude *.msi | Remove-Item
} 
catch [Exception] 
{ 
    "Failed to create MSI file: $_.Exception.Message" 
    $_.Exception.StackTrace 
    Exit 1 
}
