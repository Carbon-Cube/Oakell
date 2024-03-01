#!/bin/bash
dotnet /app/dbmigrator/Oakell.DbMigrator.dll

dotnet Oakell.HttpApi.Host.dll
