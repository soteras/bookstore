from mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app

COPY *.sln .
COPY Bookstore/*.csproj ./Bookstore/
RUN dotnet restore ./Bookstore/

COPY Bookstore/. ./Bookstore/
WORKDIR /app/Bookstore
RUN dotnet publish -c RELEASE -o out

from mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app
COPY --from=build /app/Bookstore/out ./
EXPOSE 80

ENTRYPOINT ["dotnet", "Bookstore.dll"]
