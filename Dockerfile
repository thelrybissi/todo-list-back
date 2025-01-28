# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . .

# Restaura as dependências
RUN dotnet restore

# Compila e publica a aplicação
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/out .

# Exponha a porta da aplicação
EXPOSE 5000

# Define o comando de inicialização
ENTRYPOINT ["dotnet", "TodoAppApi.dll"]
