API e FrontEnd para encontrar Universidades Brasileiras
=================================

### API e Frontend que procura por Universidades Brasileiras dado um parâmetro "name" inserido pelo usuário na página inicial.

FrontEnd chama CarlotaAPI que chama outra API de Universidades do mundo. Git para a API mencionada: https://github.com/Hipo/university-domains-list-api/


### Funcionalidades

A API irá procurar por universidades brasileiras com nome caso especificado na caixa de input da tela inicial e apertando o botão "Buscar". 
Caso nenhum parâmetro seja específicado, a API retornará todas as Universidades do Brasil ao apertar o botão.

### Tecnologias

- API: C# e .NET Core MVC
- FrontEnd: C#, .NET Core MVC, Razor
- Virtualização: Docker

### Rode o projeto

- Clone o repositório `git clone https://github.com/cmsulzbeck/ApiUniversidades.git`
- Setar ambiente virtual usando Docker:
  - Dentro dos diretórios "CarlotaApi" e "FrontEnd" existem arquivos Dockerfile para configuração de ambiente
  - Construir imagem docker baseado no Dockerfile da API e do FrontEnd 
    - `docker image build -t carlotaapi:1.0 .` (-t significa nome e/ou tag opcionais na construção da imagem)
    - `docker image build -t carlotafrontend:1.0 .`
  - Rodar containers docker baseados nas imagens respectivas 
    - `docker run -i -t -d --name carlota_api -v $PWD:/root carlotaapi:1.0`<br /> (-i mantém STDIN aberto, -t aloca um pseudo-TTY, -d Sobrescreve a sequencia para desacoplar de um container)
    - `docker run -i -t -d --name carlota_frontend -v $PWD:/root carlotafrontend:1.0` 
  - Executar containers docker
    - `docker exec -i -t carlota_api /bin/bash` (-i mantém STDIN aberto mesmo se não acoplado, -t aloca um pseudo-TTY, bin/bash é o caminho padrão da imagem)
    - `docker exec -i -t carlota_frontend /bin/bash`
  - Criar novos terminais para API
    - `docker start carlota_api`
    - `docker exec -i -t carlota_api /bin/bash`
  - Criar novos terminais para frontend
    - `docker start carlota_frontend`
    - `docker exec -i -t carlota_frontend /bin/bash`
- Rodar projeto usando `dotnet run` dentro do diretório do projeto
