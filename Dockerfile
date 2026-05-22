#BUILD STAGE
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet restore "TrainingManagement.CourseApi.csproj"
RUN dotnet publish "TrainingManagement.CourseApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY --from=build /app/publish .
EXPOSE 8080
entrypoint ["dotnet","TrainingManagement.CourseApi.dll"]
