#!/bin/bash
# Run the database migrator
dotnet /app/dbmigrator/Oakell.DbMigrator.dll

# Start the main application
dotnet Oakell.HttpApi.Host.dll
