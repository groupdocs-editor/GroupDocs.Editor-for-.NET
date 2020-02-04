# to build image run in PS - `docker build --pull --target viewer_test -t viewer:test .`
# to run tests run in PS - `docker run --rm -it -v ${PWD}:/viewer/test/TestResults viewer:test`
 
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS viewer_examples
ENV DEBIAN_FRONTEND noninteractive

#begin System.Drawing.Common dependencies
RUN apt-get update && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libgdiplus && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libc6-dev
#end System.Drawing.Common dependencies

# begin Aspose.Words dependencies - https://docs.aspose.com/display/wordsnet/Xamarin+and+.NET+Standard+2.0+API+Differences+and+Limitations
RUN apt-get update && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libfontconfig1
# end Aspose.Words dependencies

# begin Aspose.PDF dependencies - https://docs.aspose.com/display/pdfnet/Installation
#       Aspose.Imaging dependencies - https://docs.aspose.com/display/imagingnet/Installation

RUN echo "deb http://httpredir.debian.org/debian jessie main contrib" > /etc/apt/sources.list \
    && echo "deb http://security.debian.org/ jessie/updates main contrib" >> /etc/apt/sources.list \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y ttf-mscorefonts-installer \
    && apt-get clean \
    && apt-get autoremove -y \
    && rm -rf /var/lib/apt/lists/*

# end Aspose.PDF & Aspose.Imaging dependencies

# prepare to restore
WORKDIR /viewer
#RUN git clone https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET.git

COPY ./Examples/ ./Examples/

# begin one more Aspose.Words dependency - https://docs.aspose.com/display/wordsnet/Xamarin+and+.NET+Standard+2.0+API+Differences+and+Limitations
# WORKDIR /viewer
# RUN dotnet add ./test/GroupDocs.Viewer.Tests.csproj package SkiaSharp.NativeAssets.Linux --framework netcoreapp2.1
# end one more Aspose.Words dependency

WORKDIR /viewer/Examples/
RUN dotnet restore

# build
WORKDIR /viewer/Examples/GroupDocs.Viewer.Examples.CSharp.Core
RUN dotnet build GroupDocs.Viewer.Examples.CSharp.Core.csproj --no-restore --framework netcoreapp2.1 --configuration Debug
# end build

# dotnet test --no-restore --no-build --framework netcoreapp2.1 --logger:trx --filter TestCategory!=TestLicense
#WORKDIR /viewer/Examples/GroupDocs.Viewer.Examples.CSharp.Core
WORKDIR /viewer
ENTRYPOINT ["dotnet", "run", "--no-restore", "--project", "Examples/GroupDocs.Viewer.Examples.CSharp.Core/GroupDocs.Viewer.Examples.CSharp.Core.csproj", "--framework", "netcoreapp2.1"]
#ENTRYPOINT ["ls"]