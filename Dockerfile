# Etapa 1: Build (Construção)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY . .
RUN dotnet restore

# Publica a aplicação
RUN dotnet publish -c Release -o /app

# Etapa 2: Runtime (Para rodar o site)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# --- IMPORTANTE: Mude "NomeDoSeuProjeto" abaixo para o nome do seu arquivo .dll ---
# (Geralmente é o mesmo nome do seu arquivo .csproj)
ENTRYPOINT ["dotnet", "SistemasPacientes.dll"]