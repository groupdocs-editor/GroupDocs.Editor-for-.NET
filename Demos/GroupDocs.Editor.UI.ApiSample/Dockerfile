#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

RUN apt-get update && apt-get install -y \
 libfontconfig1 \
 libfreetype6 \
 libexpat1 \
 libpng16-16

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GroupDocs.Editor.UI.ApiSample/GroupDocs.Editor.UI.ApiSample.csproj", "GroupDocs.Editor.UI.ApiSample/"]
RUN dotnet restore "GroupDocs.Editor.UI.ApiSample/GroupDocs.Editor.UI.ApiSample.csproj"
COPY . .
WORKDIR "/src/GroupDocs.Editor.UI.ApiSample"
RUN dotnet build "GroupDocs.Editor.UI.ApiSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroupDocs.Editor.UI.ApiSample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupDocs.Editor.UI.ApiSample.dll"]