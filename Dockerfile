# استخدام صورة من Microsoft لـ .NET 8 SDK
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# استخدام صورة .NET 8 SDK لبناء التطبيق
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["advmvc/advmvc.csproj", "advmvc/"]
RUN dotnet restore "advmvc"
COPY . .
WORKDIR "/src/advmvc"
RUN dotnet build "advmvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "advmvc.csproj" -c Release -o /app/publish

# إعداد الصورة النهائية لتشغيل التطبيق
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "advmvc.dll"]
