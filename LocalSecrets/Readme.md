# .NET Secret Manager

## Initialize .NET Secret Manager
```powershell
dotnet user-secrets init
```

## See local secrets
```powershell
dotnet user-secrets list
```

## Starting SQL Server
```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@1q2w3e4r" -p 1433:1433 -v sqlvolume:/var/opt/mssql --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager
```powershell
$sa_password = "@1q2w3e4r"
dotnet user-secrets set "ConnectionStrings:WeatherStoreContext" "Server=localhost; Database=WeatherStore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```