#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p b727c6ee-a474-4496-b5f2-79d7e12640d8 -t
    fi
    cd ../
fi

docker-compose up -d
