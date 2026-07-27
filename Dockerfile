FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["DialogueAnalyzer.Web/DialogueAnalyzer.Web.csproj", "DialogueAnalyzer.Web/"]
COPY ["DialogueAnalyzer.Application/DialogueAnalyzer.Application.csproj", "DialogueAnalyzer.Application/"]
COPY ["DialogueAnalyzer.Infrastructure/DialogueAnalyzer.Infrastructure.csproj", "DialogueAnalyzer.Infrastructure/"]
COPY ["DialogueAnalyzer.Domain/DialogueAnalyzer.Domain.csproj", "DialogueAnalyzer.Domain/"]
COPY ["DialogueAnalyzer.Web.Tests/DialogueAnalyzer.Web.Tests.csproj", "DialogueAnalyzer.Tests/"]
RUN dotnet restore "DialogueAnalyzer.Web/DialogueAnalyzer.Web.csproj"
COPY . .
WORKDIR "/src/DialogueAnalyzer.Web"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DialogueAnalyzer.Web.dll"]