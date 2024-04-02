#!/bin/bash

# Author: Nikita Neverov (BMTLab)
# Version: 1.1.0

# Description: This script updates the version of a specified NuGet package in Directory.Packages.props or .csproj file.
# Used in CI/CD to automatically upgrade package dependency to a new unified version of the packages.

# Usage:
# chmod +x rewrite-pkg-version.sh
# ./rewrite-pkg-version.sh [-f <file>] [-p <package>] -v <version>

set -uo pipefail
IFS=$'\n\t'

# Default file and package name
readonly DEFAULT_PROPS_FILE='Directory.Packages.props'
readonly DEFAULT_PACKAGE_NAME='BMTLab.OneOf.Reduced'

# Error codes
readonly ERR_INVALID_OPTION=2
readonly ERR_MISSING_ARGUMENT=3
readonly ERR_VERSION_REQUIRED=4
readonly ERR_FILE_NOT_FOUND=5
readonly ERR_UPDATE_FAILED=6

#######################################
# Display usage information.
# Outputs:
#   Help information.
#######################################
function usage() {
  cat << EOF
Usage: $(basename "$0") [-f] <file> [-p] <package> -v <version>

Options:
  -f <file>    : Specify the path to Directory.Packages.props. Default is '${DEFAULT_PROPS_FILE}'.
  -p <package> : Specify the package name to update. Default is '${DEFAULT_PACKAGE_NAME}'.
  -v <version> : Specify the new version. No default value.
  -h           : Display this help message.

Example:
  $(basename "$0") -f "../${DEFAULT_PROPS_FILE}" -p "${DEFAULT_PACKAGE_NAME}" -v "1.2.3"
EOF
}

#######################################
# Displays an error message, outputs usage, and terminates the script with an error.
# Arguments:
#   1: The error message to display.
#   2: The error exit code (1 by default).
#######################################
function __error() {
  local -r message="$1"
  local -ir code=${2:-1} # Default error code is 1

  printf '\nError: %s.\n' "$message" >&2
  usage
  exit $code
}

#######################################
# Parse command line options.
# Globals:
#   DEFAULT_PROPS_FILE
#   DEFAULT_PACKAGE_NAME
# Arguments:
#   References to file, package, and version variables.
#######################################
function __parse_options() {
  local -n _file="$1"
  local -n _package="$2"
  local -n _version="$3"
  local opt

  shift 3

  while getopts ':f:p:v:h' opt; do
    case $opt in
      f)
        _file="$OPTARG"
        ;;
      p)
        _package="$OPTARG"
        ;;
      v)
        _version="$OPTARG"
        ;;
      h)
        usage
        exit 0
        ;;
      \?)
        __error "Invalid option: -${OPTARG}" $ERR_INVALID_OPTION
        ;;
      :)
        __error "Option -$OPTARG requires an argument" $ERR_MISSING_ARGUMENT
        ;;
    esac
  done
}

#######################################
# Validate required parameters.
# Arguments:
#   1: The file to update.
#   2: The new version to set.
#######################################
function __validate_parameters() {
  local -r file="$1"
  local -r version="$2"

  [[ -z "$version" ]] && __error 'Version (-v) is required' $ERR_VERSION_REQUIRED
  [[ ! -f "$file" ]] && __error "File '${file}' does not exist" $ERR_FILE_NOT_FOUND
}

#######################################
# Update the package version in the props file or .csproj file.
# Arguments:
#   1: The file to update.
#   2: The package name whose version will be updated.
#   3: The new version to set.
#######################################
function _update_version() {
  local -r file="$1"
  local -r package="$2"
  local -r version="$3"

  sed -i "s/\(e=\"${package}\" Version=\"\)[^\"]*/\1${version}/" "$file"

  if [[ $? -eq 0 ]]; then
    echo "Updated $package to version $version in '${file}'."
  else
    __error "Failed to update version in '${file}'" $ERR_UPDATE_FAILED
  fi
}

#######################################
# Main function to orchestrate script execution.
# Uses global defaults and user inputs to update NuGet package versions.
#######################################
function main() {
  local file="$DEFAULT_PROPS_FILE"
  local package="$DEFAULT_PACKAGE_NAME"
  local version=''

  __parse_options file package version "$@"
  __validate_parameters "$file" "$version"
  _update_version "$file" "$package" "$version"
}

# Execute the main function with all passed arguments
main "$@"
