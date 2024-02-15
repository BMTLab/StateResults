#!/bin/bash
# Checks if a NuGet package is indexed and available on nuget.org.

# Do not forget
# chmod +x check_nuget_indexing.sh

readonly DEFAULT_PACKAGE_NAME='BMTLab.OneOf.Reduced'
readonly MAX_ATTEMPTS=10
readonly SLEEP_SECONDS=30

# Display usage information.
function usage() {
  cat << EOF
Usage: $(basename "$0") [-p] <package> [-v] <version>

Options:
  -p <package> : Specify the NuGet package name. Default is '${DEFAULT_PACKAGE_NAME}'.
  -v <version> : Specify the package version to check. No default value.
  -h           : Display this help message.

Example:
  $(basename "$0") -p "${DEFAULT_PACKAGE_NAME}" -v "1.2.3"
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
  echo 'Script interrupted by user.'
  exit 0
}

# Register the interrupt handler for SIGINT.
trap interrupt SIGINT

# Parse command line options.
function __parse_options() {
  local -n _package="$1"
  local -n _version="$2"
  local opt

  shift 2

  while getopts ':p:v:h' opt; do
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
      h)
        usage
        exit 0
        ;;
      \?)
        error "Invalid option: -${OPTARG}."
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
  local attempt_counter=0
  local is_success=false

echo "Checking if NuGet package $package with version $version..."

  while [[ $attempt_counter -lt $MAX_ATTEMPTS ]]; do
    local nuget_package_url="https://www.nuget.org/api/v2/package/${package}/${version}"

    # Use -I for the HEAD request and -w '%{http_code}' to output the HTTP status of the response.
    local http_status=$(curl --silent --output /dev/null --write-out '%{http_code}' --location "$nuget_package_url")

    if [[ $http_status -eq 302 || $http_status -eq 200 ]]; then
      echo "Success. Package $package version $version is available for download."
      is_success=true
      break
    else
      echo "Pending. Package $package version $version is not available for download yet. HTTP status: $http_status."
      ((attempt_counter++))
      echo "Attempt $attempt_counter of $MAX_ATTEMPTS. Retrying in $SLEEP_SECONDS seconds..."

      sleep $SLEEP_SECONDS
    fi
  done

  if [[ ! $is_success ]]; then
    error "Package $package version $version was not available for download after $MAX_ATTEMPTS attempts."
  fi
}

# Main function to orchestrate script execution.
function main() {
  local package="$DEFAULT_PACKAGE_NAME"
  local version=''

  __parse_options package version "$@"
  _check_package_indexing "$package" "$version"
}

main "$@"
