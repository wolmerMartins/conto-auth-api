FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /App

COPY . /App/

RUN dotnet restore src/ContoAuthApi.sln

RUN dotnet publish -c Release -o out src/ContoAuthApi/ContoAuthApi.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0

EXPOSE 8080

WORKDIR /App

COPY --from=build /App/out .

CMD [ "./ContoAuthApi" ]
