# ProductAPI

Criação de API CRUD e deploy para Azure Web Service com banco de dados.

Instruções rápidas:

- Restaurar pacotes: `dotnet restore`
- Build: `dotnet build`
- Rodar localmente: `dotnet run --project ProductAPI.csproj`
- Testes: `dotnet test`

## Ambientes e banco de dados

### Desenvolvimento local (SQLite)

1. `Properties/launchSettings.json`
   - Manter `ASPNETCORE_ENVIRONMENT=Development` nos perfis locais.
   - Isso ativa o fluxo de desenvolvimento no código (`UseSqlite` e `EnsureCreated`).

2. `Startup.cs`
   - Não precisa trocar manualmente quando for publicar.
   - O código já está preparado para:
     - `Development` -> `UseSqlite(...)`
     - demais ambientes -> `UseSqlServer(...)`

3. `Program.cs`
   - Não precisa trocar manualmente quando for publicar.
   - O código já está preparado para:
     - `Development` -> `Database.EnsureCreated()`
     - demais ambientes -> `Database.Migrate()`

4. `appsettings.Development.json`
   - Usado somente no ambiente `Development`.
   - Definir `ConnectionStrings:DefaultConnection` para SQLite local.
   - Exemplo: `Data Source=products-local.db`.

### Produção (Azure App Service + Azure SQL)

1. `ASPNETCORE_ENVIRONMENT`
   - Definir `Production` no App Service.
   - Em produção, não usar `Development`.

2. `Connection string`
   - Definir `ConnectionStrings__DefaultConnection` no App Service com a string real da Azure SQL.
   - Atenção: usar exatamente dois underlines (`__`) no nome da chave.
   - Não salvar credencial real em `appsettings.json`.

3. Arquivos `appsettings`
   - `appsettings.Development.json` é para ambiente local e não precisa ser alterado para produção.
   - `appsettings.json` deve permanecer com placeholder.

## Deploy no Azure (produção)

- Configure App Service para runtime `.NET 8 (LTS)`.
- Publique via GitHub Actions ou `dotnet publish` + ZIP deploy.
- Defina `ASPNETCORE_ENVIRONMENT=Production` no App Service.
- Defina `ConnectionStrings__DefaultConnection` com a string real da Azure SQL.

### Validação pós-deploy

- Abra `https://<seu-app>.azurewebsites.net/swagger`.
- Execute `GET /api/Products` para validar leitura.
- Execute `POST /api/Products` e repita `GET /api/Products` para validar gravação no Azure SQL.

## Segurança de credenciais

- Não versionar segredos no repositório (`User ID`, `Password`, chaves e tokens).
- Em `appsettings.json`, manter somente placeholder.
- Para desenvolvimento local com SQL Server, usar User Secrets:
  - `dotnet user-secrets init`
  - `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "SUA_CONNECTION_STRING"`

### Encerramento seguro (após testes)

- Excluir App Service e recursos não utilizados no Azure.
- Excluir a Azure SQL Database (ou o Resource Group de teste completo).
- Remover variáveis sensíveis do App Service antes de excluir, se necessário.
