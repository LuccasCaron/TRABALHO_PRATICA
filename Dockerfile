
#DOCKER 1

# Pegando imagem .net 8 e sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

#criando uma pasta de trabalho chamada app dentro da imagem que acabei de baixar
WORKDIR /app


# copiando tudo dentro de /PROJETO_ADV e passando pra dentro de app
COPY . ./

#restaurando dependencias
RUN dotnet restore

# Realiza a publicação do aplicativo .NET Core no modo Release e o coloca na pasta 'out'
RUN dotnet publish -c Release -o out

#terminou a operacao de cima agora pegou os arquivos e publicou na pasta app/out

#########################################

#DOCKER 2

#gerar novo ambiente docker com a runtime sem sdk
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

#criando nova pasta de trabalho chaamdno de runtime-app
WORKDIR /runtime-app

#copiando tudo que foi gerado no primeiro docker, pra ca
# entao pego o build-env que foi o nome do primeiro container dentro da pasta app/out e copio pra ca usando o " . "
COPY --from=build-env /app/out .

#expor a porta 8080 pq teoricamente aplicacoes .net rodam por padrao na 8080
EXPOSE 8080 

ENTRYPOINT ["dotnet", "PROJETO_ADVOCACIA.dll"]
