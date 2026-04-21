# ProductAPI

Criação de API CRUD e deploy para Azure Web Service com banco de dados.

Instruções rápidas:

- Restaurar pacotes: `dotnet restore`
- Build: `dotnet build`
- Rodar localmente: `dotnet run --project ProductAPI.csproj`
- Testes: `dotnet test`

Configuração local (desenvolvimento):

- Em `Development`, a API usa SQLite local com `Data Source=products-local.db` (arquivo na raiz do projeto).
- Basta rodar `dotnet run --project ProductAPI.csproj`.

Publicação no Azure App Service:
- Configure App Service para runtime `.NET 8 (LTS)`
- Use GitHub Actions ou `dotnet publish` + ZIP deploy

Segurança de connection string:

- Não versione segredos no repositório.
- `appsettings.json` deve conter apenas placeholder para `ConnectionStrings:DefaultConnection`.
- Configure o valor real por User Secrets (local) ou variável de ambiente.

Exemplo com User Secrets:

- `dotnet user-secrets init`
- `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "SUA_CONNECTION_STRING"`

Exemplo com variável de ambiente:

- `ConnectionStrings__DefaultConnection=SUA_CONNECTION_STRING`
