#!/bin/bash
echo "Esperando a que SQL Server inicie..."
sleep 30s

echo "Verificando si la base de datos existe..."
DB_EXISTS=$(/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P B4nc0d31sl4 -Q "
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'bancooccidentedb') 
  PRINT 'EXISTS'
ELSE
  PRINT 'NOT EXISTS'" -h -1 | tr -d '\r')

if [ "$DB_EXISTS" = "NOT EXISTS" ]; then
  echo "La base de datos no existe. Creándola..."
  /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P B4nc0d31sl4 -Q "CREATE DATABASE bancooccidentedb"
fi

echo "Restaurando la base de datos..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P B4nc0d31sl4 -Q "
RESTORE DATABASE bancooccidentedb
FROM DISK = '/var/opt/mssql/bancooccidentedb.bak'
WITH MOVE 'BancoOccidenteDb_Data' TO '/var/opt/mssql/backups/bancooccidentedb.mdf',
MOVE 'BancoOccidenteDb_Log' TO '/var/opt/mssql/data/bancooccidentedb_log.ldf', REPLACE"

echo "Base de datos restaurada correctamente."
