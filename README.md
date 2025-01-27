Como rodar projeto

Execute os comandos para criar as migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

Exceute
- dotnet clean
- dotnet restore
- dotnet build
- dotnet run

Swagger estará no link: http://localhost:5123/swagger/index.html
Obs: a porta pode ser diferente dependo da maquina que subiu.

O banco de dados usado foi o Postgres, mas para SQL Server basta mudar no Program.cs a linha 26 e trocar UseNpgsql por UseSqlServer e adicionar a connetionString do SQL Server
O banco Postgres está hospedado no https://railway.com/
