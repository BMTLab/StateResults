<#
.SYNOPSIS
This script is designed to clean specified directories and files in a project.
It provides a flexible way to remove build artifacts, temporary files, and other not needed directories and files.

.DESCRIPTION
This script offers a way to systematically remove unwanted files and directories from a project, improving cleanliness and maintainability.

.AUTHOR
Nikita Neverov (BMTLab)

.VERSION
1.0.1
#>

# Function to clean directories matching a specific pattern.
function Clean-Directories
{
    param (
        [Parameter(Mandatory = $true)]
        [string]$Pattern
    )

    Write-Host "Cleaning directories matching pattern: $Pattern"
    Get-ChildItem -Path .. -Recurse -Directory -Filter $Pattern | Remove-Item -Recurse -Force
}

# Function to clean files matching a specific pattern.
function Clean-Files
{
    param (
        [Parameter(Mandatory = $true)]
        [string]$Pattern
    )

    Write-Host "Cleaning files matching pattern: $Pattern"
    Get-ChildItem -Path .. -Recurse -File -Filter $Pattern | Remove-Item -Force
}

# Main function to orchestrate cleaning operations.
function Main
{
    Write-Host "Starting cleaning process..."

    # List of patterns for directories to clean
    $dirPatterns = @('build*', 'bin', 'obj', 'out')

    # Clean directories
    foreach ($pattern in $dirPatterns)
    {
        Clean-Directories -Pattern $pattern
    }

    # Clean files
    Clean-Files -Pattern "VERSION.g.txt"

    Write-Host "Cleaning completed!"
}

# Execute the main function
Main
