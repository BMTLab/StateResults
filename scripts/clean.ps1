<#
.SYNOPSIS
This script cleans specified directories and files in a project.
#>

# Print start message
Write-Host "Cleaning projects"

# Function to clean specified directories
function Clean-Directories
{
    param (
        [Parameter(Mandatory = $true)]
        [string]$Pattern
    )
    Get-ChildItem -Path .. -Recurse -Directory -Filter $Pattern | Remove-Item -Recurse -Force
}

# Function to clean specified files
function Clean-Files
{
    param (
        [Parameter(Mandatory = $true)]
        [string]$Pattern
    )
    Get-ChildItem -Path .. -Recurse -File -Filter $Pattern | Remove-Item -Force
}

# Clean directories: build, bin, obj, and out
Clean-Directories -Pattern "build*"
Clean-Directories -Pattern "bin"
Clean-Directories -Pattern "obj"
Clean-Directories -Pattern "out"

# Clean VERSION.g.txt files
Clean-Files -Pattern "VERSION.g.txt"

# Print completion message
Write-Host "Cleaning completed"
