#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
RUN apt-get update && apt-get install -y \
 libgdiplus  \
 libc6-dev  \
 libfontconfig1 \
 libfreetype6 \
 libexpat1 \
 libpng16-16
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GroupDocs.Editor.Examples.CSharp.LinuxNET6/GroupDocs.Editor.Examples.CSharp.LinuxNET6.csproj", "GroupDocs.Editor.Examples.CSharp.LinuxNET6/"]
RUN dotnet restore "./GroupDocs.Editor.Examples.CSharp.LinuxNET6/./GroupDocs.Editor.Examples.CSharp.LinuxNET6.csproj"
COPY . .
WORKDIR "/src/GroupDocs.Editor.Examples.CSharp.LinuxNET6"
RUN dotnet build "./GroupDocs.Editor.Examples.CSharp.LinuxNET6.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GroupDocs.Editor.Examples.CSharp.LinuxNET6.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroupDocs.Editor.Examples.CSharp.LinuxNET6.dll"]