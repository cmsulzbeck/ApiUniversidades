FROM ubuntu:20.04
ENV LANG C.UTF-8

# Microsoft Repository key and feed
RUN apt-get update \
  && apt-get install -y wget \
  && rm -rf /var/lib/apt/lists/*
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb

# .NET Core SDK
RUN apt-get update
RUN apt-get install apt-transport-https
RUN apt-get update
RUN apt-get install -y dotnet-sdk-3.1

# ASP.NET Core runtime
RUN apt-get update
RUN apt-get install apt-transport-https
RUN apt-get update
RUN apt-get install aspnetcore-runtime-3.1

#.NET Core runtime
RUN apt-get update
RUN apt-get install apt-transport-https
RUN apt-get update
RUN apt-get install dotnet-runtime-3.1

# To build:
# docker image build -t carlotafrontend:1.0 .

# To run:
# docker run -i -t -d --name carlota_frontend -v $PWD:/root carlotafrontend:1.0
# docker exec -i -t carlota_frontend /bin/bash

# To get a new terminal
# docker start carlota_frontend
# docker exec -i -t carlota_frontend /bin/bash

# To execute
# docker exec -i -t carlota_frontend /bin/bash