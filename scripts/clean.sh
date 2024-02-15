#!/bin/bash
# This script cleans specified directories and files in a project.

# Do not forget
# chmod +x transform_location.sh

echo 'Cleaning projects..'

# Function to clean specified directories.
clean_directories() {
  local pattern="$1"
  find .. -name "$pattern" -type d -print0 | xargs -r0 rm -r
}

# Function to clean specified files.
clean_files() {
  local pattern="$1"
  find .. -name "$pattern" -type f -print0 | xargs -r0 rm
}

clean_directories 'build*'
clean_directories 'bin'
clean_directories 'obj'
clean_directories 'out'
clean_files 'VERSION.g.txt'

echo 'Success. Cleaning completed'
