Task default -Depends Requires.MSBuild, Build, Test

function Test-CommandExists($command){
    ((Get-Command $command -ea SilentlyContinue) | Test-Path) -contains $true
}

Task Requires.MSBuild {

    $script:msbuildExe =  resolve-path "C:\Program Files (x86)\Microsoft Visual Studio\2019\*\MSBuild\*\Bin\MSBuild.exe"

    if ($msbuildExe -eq $null)
    {
        throw "Failed to find MSBuild"
    }

    Write-Host "Found MSBuild here: $msbuildExe"
}

Task Build { 
Write-Host "Building!"
Exec { & $msbuildExe .\ClearMeasure.RSherrill.sln /t:Build /p:Configuration=Release}
}

Task Test -PreCondition { return Test-CommandExists("nunit-console.exe") } {
    Exec { nunit-console.exe ".\ClearMeasure.RSherrill.Test\ClearMeasure.RSherrill.Test.csproj" }
}