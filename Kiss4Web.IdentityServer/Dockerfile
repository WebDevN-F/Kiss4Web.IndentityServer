#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kiss4Web.IdentityServer/Kiss4Web.IdentityServer.csproj", "Kiss4Web.IdentityServer/"]
RUN dotnet restore "Kiss4Web.IdentityServer/Kiss4Web.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Kiss4Web.IdentityServer"
RUN dotnet build "Kiss4Web.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kiss4Web.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kiss4Web.IdentityServer.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT ./Kiss4Web.IdentityServer