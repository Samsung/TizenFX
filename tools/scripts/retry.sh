#!/bin/bash

retry_count=3
cmd="${@}"

n=0
until [ $n -ge $retry_count ]; do
  if [ $n -gt 0 ]; then
    echo "(Failed! Retry $[$n+1]/$retry_count) $cmd"
    sleep 2
  fi
  $cmd
  RET=$?
  if [ $RET -eq 0 ]; then
    break
  else
    n=$[$n+1]
  fi
done

exit $RET
