FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
RUN dotnet new console
COPY ./src/test.cs Program.cs
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "app.dll"]
# CMD ["tail","-f", "/dev/null"]
