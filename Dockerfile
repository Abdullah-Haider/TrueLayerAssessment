FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TrueLayerAssessment/TrueLayerAssessment.csproj TrueLayerAssessment/
RUN dotnet restore TrueLayerAssessment/TrueLayerAssessment.csproj
COPY . .
WORKDIR /src/TrueLayerAssessment
RUN dotnet build TrueLayerAssessment.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TrueLayerAssessment.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TrueLayerAssessment.dll"]
