#!/usr/bin/env bash
#
# Regenerates the C# entity/stub code this sample uses to build the
# Tizen.Entity.App annotation payload.
#
# Tool locations and configuration can be overridden via environment variables:
#   ACTIONC            path to the actionc binary (default: look in PATH)
#   ACTIONC_DATA_DIR   path to the directory holding the framework's actions/ and entities/
#                      (default: actionc's built-in default)
#
# Requires tidlc >= 2.9.0: earlier versions do not emit TizenEntityApp.ToJson().

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
GEN_DIR="${SCRIPT_DIR}/gen"

find_actionc() {
  if [[ -n "${ACTIONC:-}" ]]; then echo "${ACTIONC}"; return; fi
  if command -v actionc >/dev/null 2>&1; then command -v actionc; return; fi
  return 1
}

ACTIONC_BIN="$(find_actionc)" || {
  echo "error: actionc not found in PATH. Please install actionc or set the ACTIONC environment variable." >&2
  exit 1
}

echo "actionc: ${ACTIONC_BIN}"

mkdir -p "${GEN_DIR}"

echo "[1/1] actionc: generating C# App action stub -> gen/ImplApp"
( cd "${GEN_DIR}" && "${ACTIONC_BIN}" -a Tizen.Action.App -l C# -o ImplApp )

echo "Done."
echo "  generated stub:      ${GEN_DIR}/ImplApp.cs"
