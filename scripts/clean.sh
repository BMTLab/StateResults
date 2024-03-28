#!/bin/bash

# Author: Nikita Neverov (BMTLab)
# Version: 1.0.1

# Do not forget
# sudo chmod +x ./clean.sh

# Description: This script is designed to clean specified directories and files in a project.
# It provides a flexible way to remove build artifacts, temporary files, and other not needed directories and files.

#######################################
# Clean directories matching a specific pattern.
# Arguments:
#   pattern: The pattern to match directories to be cleaned.
# Outputs:
#   Writes names of cleaned directories to stdout.
#######################################
function clean_directories() {
  local -r pattern="$1"
  printf 'Cleaning directories matching pattern: %s.\n' "$pattern"
  find .. -name "$pattern" -type d -print0 | xargs -r0 rm -r
}

#######################################
# Clean files matching a specific pattern.
# Arguments:
#   pattern: The pattern to match files to be cleaned.
# Outputs:
#   Writes names of cleaned files to stdout.
#######################################
function clean_files() {
  local -r pattern="$1"
  printf 'Cleaning files matching pattern: %s.\n' "$pattern"
  find .. -name "$pattern" -type f -print0 | xargs -r0 rm
}

#######################################
# The main function to orchestrate cleaning operations.
# It calls other functions with specific patterns to clean up project artifacts.
# Outputs:
#   Writes progress and results of cleaning operations to stdout.
#######################################
function main() {
  printf 'Starting cleaning process...'

  # List of patterns for directories to clean
  local -ar dir_patterns_arr=('build*' 'bin' 'obj' 'out')

  # Clean directories
  for pattern in "${dir_patterns_arr[@]}"; do
    clean_directories "$pattern"
  done

  # Clean files
  clean_files 'VERSION.g.txt'

  printf 'Cleaning completed!'
}

# Execute the main function with all passed arguments
main "$@"
