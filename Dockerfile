# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia os arquivos
COPY . .

# Restaura as dependências
RUN dotnet restore "./SistemaPacientesBlazor.csproj"

# Publica a aplicação (Corrigido para apontar para o .csproj e não para o .sln)
RUN dotnet publish "./SistemaPacientesBlazor.csproj" -c Release -o /app /p:UseAppHost=false

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# --- A CORREÇÃO PRINCIPAL ESTÁ AQUI EMBAIXO ---
# O nome deve ser EXATAMENTE igual ao gerado no log anterior: SistemaPacientesBlazor.dll
ENTRYPOINT ["dotnet", "SistemaPacientesBlazor.dll"]