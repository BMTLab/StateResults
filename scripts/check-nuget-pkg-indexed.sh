#!/bin/bash

# Author: Nikita Neverov (BMTLab)
# Version: 2.0.2

# Description: Checks if a NuGet package is indexed and available on nuget.org.
# Used in CI/CD to automatically check if a dependency package is indexed before pushing a dependent package.

# Usage:
# chmod +x check-nuget-pkg-indexed.sh
# ./check-nuget-pkg-indexed.sh [-p] <package> [-a] <attempts> -v <version>

set -uo pipefail
IFS=$'\n\t'

# Default settings
readonly DEFAULT_PACKAGE_NAME='BMTLab.OneOf.Reduced'
readonly DEFAULT_MAX_ATTEMPTS=10
readonly SLEEP_SECONDS=30

# Error codes
readonly ERR_MISSING_ARGUMENT=20
readonly ERR_INVALID_OPTION=30
readonly ERR_INVALID_VERSION=40
readonly ERR_PACKAGE_NOT_FOUND=50

#######################################
# Display usage information.
# Outputs:
#   Help information.
#######################################
function usage() {
  cat <<EOF
Usage: $(basename "$0") [-p] <package> [-a] <attempts> -v <version>

Options:
  -p <package>  : Specify the NuGet package name. Default is '${DEFAULT_PACKAGE_NAME}'.
  -a <attempts> : Specify the max attempts count. Default is ${DEFAULT_MAX_ATTEMPTS}.
  -v <version>  : Specify the package version to check. Required.
  -h            : Display this help message.

Example:
  $(basename "$0") -p "${DEFAULT_PACKAGE_NAME}" -a 5 -v "1.2.3"
EOF
}

#######################################
# Displays an error message, outputs usage, and terminates the script with an error.
# Arguments:
#   1: The error message to display.
#   2: The error exit code (optional).
#######################################
function __error() {
  local -r message="$1"
  local -ir code=${2:-1} # Default error code is 1

  usage
  printf '\nError: %s.\n' "$message" >&2

  exit $code
}

#######################################
# Parses command line options.
# Arguments:
#   References to package, version, and max_attempts variables.
#######################################
function __parse_options() {
  local -n _package="$1"
  local -n _version="$2"
  local -n _max_attempts=$3
  local opt

  shift 3

  while getopts ':p:v:a:h' opt; do
    case $opt in
    p)
      _package="$OPTARG"
      ;;
    v)
      _version="$OPTARG"
      ;;
    a)
      _max_attempts=$OPTARG
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

  if [[ -z $_version || $_version =~ ^[[:space:]]+$ ]]; then
    __error "Version (-v) is required" $ERR_INVALID_VERSION
  fi
}

#######################################
# Check if the specified NuGet package version is indexed on nuget.org.
# Arguments:
#   1: The NuGet package name.
#   2: The package version.
#   3: Maximum number of attempts to check the package availability.
#######################################
function _check_package_indexing() {
  local -r package="$1"
  local -r version="$2"
  local -ir max_attempts=$3
  local -i attempt=1
  local -r nuget_package_url="https://www.nuget.org/api/v2/package/${package}/${version}"
  local -i status_code

  while [[ $attempt -le $max_attempts ]]; do
    printf "Checking if %s version %s is indexed on nuget.org (Attempt: %d)...\n" "$package" "$version" $attempt

    status_code=$(curl --silent -L --output /dev/null --write-out '%{http_code}' "$nuget_package_url")

    if [[ $status_code -eq 200 ]]; then
      printf "Package %s version %s is indexed on nuget.org.\n" "$package" "$version"
      exit 0
    else
      printf "Pending. Package %s version %s is not indexed yet. Status code: %d\n" "$package" "$version" "$status_code"

      if [[ $attempt -lt $max_attempts ]]; then
        printf "Sleeping for %d seconds before the next attempt %d of %d...\n" $SLEEP_SECONDS $attempt $max_attempts >&2
        sleep $SLEEP_SECONDS
      fi
    fi

    ((attempt++))
  done

  __error "Package $package version $version was not indexed after $max_attempts attempts" $ERR_PACKAGE_NOT_FOUND
}

#######################################
# Main function to orchestrate script execution.
# Uses global defaults and user inputs to check NuGet package versions.
#######################################
function main() {
  local package="$DEFAULT_PACKAGE_NAME"
  local version=''
  local -i max_attempts=$DEFAULT_MAX_ATTEMPTS

  __parse_options package version max_attempts "$@"
  _check_package_indexing "$package" "$version" "$max_attempts"
}

# Execute the main function with all passed arguments
main "$@"
