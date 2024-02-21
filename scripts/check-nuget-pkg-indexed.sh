#!/bin/bash
# Checks if a NuGet package is indexed and available on nuget.org.

# Do not forget
# chmod +x check-nuget-pkg-indexed.sh

set -uo pipefail
IFS=$'\n\t'

readonly DEFAULT_PACKAGE_NAME='BMTLab.OneOf.Reduced'
readonly DEFAULT_MAX_ATTEMPTS=10
readonly SLEEP_SECONDS=30

# Display usage information.
function usage() {
  cat << EOF
Usage: $(basename "$0") [-p] <package> [-a] <attempts> -v <version>

Options:
  -p <package>  : Specify the NuGet package name. Default is '${DEFAULT_PACKAGE_NAME}'.
  -a <attempts> : Specify the max attempts count. Default is ${DEFAULT_MAX_ATTEMPTS}.
  -v <version>  : Specify the package version to check. No default value.
  -h            : Display this help message.

Example:
  $(basename "$0") -p "${DEFAULT_PACKAGE_NAME}" -v "1.2.3" -a 5
EOF
}

# Displays an error message, outputs usage and terminates the script with an error.
function error() {
  local error_message="$1"

  printf 'Error: %s.\n' "$error_message" >&2
  usage
  exit 1
}

# Function to handle script interruption (Ctrl+C).
function interrupt() {
  error 'Script interrupted by user'
}

# Register the interrupt handler for SIGINT.
trap interrupt SIGINT

# Parse command line options.
function __parse_options() {
  local -n _package="$1"
  local -n _version="$2"
  local -n _max_attempts="$3"
  local opt

  shift 3

  while getopts ':p:v:a:h' opt; do
    case $opt in
      p)
        if [[ -z $OPTARG || $OPTARG =~ ^- ]]; then
          error 'Option -p requires a package name'
        fi
        _package="$OPTARG"
        ;;
      v)
        if [[ -z $OPTARG || $OPTARG =~ ^- ]]; then
          error 'Option -v requires a version'
        fi
        _version="$OPTARG"
        ;;
      a)
        if [[ -z $OPTARG || $OPTARG =~ ^- ]]; then
          error 'Option -a requires a number'
        fi
        _max_attempts="$OPTARG"
        ;;
      h)
        usage
        exit 0
        ;;
      \?)
        error "Invalid option: -${OPTARG}"
        ;;
      :)
        error "Option -$OPTARG requires an argument"
        ;;
    esac
  done
}

# Check if the specified NuGet package version is indexed on nuget.org.
function _check_package_indexing() {
  local package="$1"
  local version="$2"
  local max_attempts="$3"
  local attempt_counter=0
  local is_success=false

  while [[ $attempt_counter -lt $max_attempts ]]; do
    local nuget_package_url="https://www.nuget.org/api/v2/package/${package}/${version}"

    local http_status=$(curl --silent --output /dev/null --write-out '%{http_code}' --location "$nuget_package_url")

    if [[ $http_status -eq 302 || $http_status -eq 200 ]]; then
      is_success=true
      break
    else
      >&2 echo "Pending. Package $package version $version is not available for download yet. HTTP status: ${http_status}."
      ((attempt_counter++))

      if [[ $max_attempts -gt 1 ]]; then
        >&2 echo "Attempt $attempt_counter of $max_attempts. Retrying in $SLEEP_SECONDS seconds..."
        sleep $SLEEP_SECONDS
      fi
    fi
  done

  if [[ $is_success == false ]]; then
    >&2 echo "Package $package version $version was not available for download after $max_attempts attempts."
  fi

  # Return
  echo "$is_success"
}

# Main function to orchestrate script execution.
function main() {
  local package="$DEFAULT_PACKAGE_NAME"
  local version=''
  local max_attempts="$DEFAULT_MAX_ATTEMPTS"

  __parse_options package version max_attempts "$@"
  _check_package_indexing "$package" "$version" "$max_attempts"
}

main "$@"
