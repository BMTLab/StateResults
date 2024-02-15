#!/bin/bash
# This script updates the version of a specified NuGet package in Directory.Packages.props or .csproj file.

# Do not forget
# chmod +x rewrite-pkg-version.sh

readonly DEFAULT_PROPS_FILE='Directory.Packages.props'
readonly DEFAULT_PACKAGE_NAME='BMTLab.OneOf.Reduced'

# Display usage information.
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

# Displays an error message, outputs usage and terminates the script with an error.
function error() {
  local error_message="$1"

  printf 'Error: %s.\n' "$error_message" >&2
  usage
  exit 1
}

# Parse command line options.
function __parse_options() {
  local -n _file="$1"
  local -n _package="$2"
  local -n _version="$3"
  local opt

  shift 3

  while getopts ':f:p:v:h' opt; do
    case $opt in
      f)
        if [[ -z $OPTARG || $OPTARG =~ ^- ]]; then
          error 'Option -f requires a file path'
        fi
        _file="$OPTARG"
        ;;
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

# Validate required parameters.
function __validate_parameters() {
  local file="$1"
  local version="$2"

  [[ -z "$version" ]] && error 'Version (-v) is required'
  [[ ! -f "$file" ]] && error "File '${file}' does not exist"
}

# Update the package version in the props file.
function _update_version() {
  local file="$1"
  local package="$2"
  local version="$3"

  # Works for both "Update=..." and "Include=..."
  sed -i "s/\(e=\"${package}\" Version=\"\)[^\"]*/\1${version}/" "$file"

  if [[ $? -eq 0 ]]; then
    echo "Updated $package to version $version in '${file}'"
  else
    error "Failed to update version in '${file}'"
  fi
}

# Main function to orchestrate script execution.
function main() {
  local file="$DEFAULT_PROPS_FILE"
  local package="$DEFAULT_PACKAGE_NAME"
  local version=''

  __parse_options file package version "$@"
  __validate_parameters "$file" "$version"
  _update_version "$file" "$package" "$version"
}

main "$@"
