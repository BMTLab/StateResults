#!/bin/bash
# This script cleans specified directories and files in a project.

# Print start message.
echo "Cleaning projects"

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

# Clean directories: build, bin, obj, and out.
clean_directories "build*"
clean_directories "bin"
clean_directories "obj"
clean_directories "out"

# Clean VERSION.g.txt files.
clean_files "VERSION.g.txt"

# Print completion message.
echo "Cleaning completed"
