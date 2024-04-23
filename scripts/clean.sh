#!/bin/sh

# Author: Nikita Neverov (BMTLab)
# Version: 2.0.0

# Do not forget
# chmod +x ./clean.sh

# Description: This sh POSIX compatible script is designed to clean specified directories and files in a project.
# It provides a flexible way to remove build artifacts, temporary files, and other not needed directories and files.

#######################################
# Clean directories matching a specific pattern.
# Arguments:
#   pattern: The pattern to match directories to be cleaned.
# Outputs:
#   Writes names of cleaned directories to stdout.
#######################################
clean_directories() {
  pattern="$1"
  printf 'Cleaning directories matching pattern: %s.\n' "$pattern"
  find .. -name "$pattern" -type d -exec rm -r {} +
}

#######################################
# Clean files matching a specific pattern.
# Arguments:
#   pattern: The pattern to match files to be cleaned.
# Outputs:
#   Writes names of cleaned files to stdout.
#######################################
clean_files() {
  pattern="$1"
  printf 'Cleaning files matching pattern: %s.\n' "$pattern"
  find .. -name "$pattern" -type f -exec rm {} +
}

#######################################
# The main function to orchestrate cleaning operations.
# It calls other functions with specific patterns to clean up project artifacts.
# Outputs:
#   Writes progress and results of cleaning operations to stdout.
#######################################
main() {
  printf 'Starting cleaning process...\n'

  # Clean directories with specific patterns
  clean_directories 'build*'
  clean_directories 'bin'
  clean_directories 'obj'
  clean_directories 'out'

  # Clean files with specific patterns
  clean_files 'VERSION.g.txt'

  printf 'Cleaning completed!\n'
}

# Execute the main function with all passed arguments
main "$@"
