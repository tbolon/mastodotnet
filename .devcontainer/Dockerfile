FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN useradd -m -s $(which bash) mastodotnet

RUN mkdir /app && chown mastodotnet:mastodotnet /app

USER mastodotnet