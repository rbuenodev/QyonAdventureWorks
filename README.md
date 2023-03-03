# QyonAdventureWorks

## Projeto WebApi feito em c# .netcore 3.1 com entity framework persistindo num banco de dados Postgres.
#### Recursos: Testes unitários, utilização de SOLID, DDD e cache nos controllers.

### Para executar o projeto, basta iniciar o docker e executar o seguinte comando na raiz do projeto para iniciar automaticamente a API, banco de dados Postgres e PGAdmin:

`docker-compose up -d`

As tabelas serão criadas automaticamente após subir o banco de dados.

#### Para acessar o PGAdmin:

- Abrir o browser e inserir o url:
  `localhost:8000`
- Utilizar as seguintes credenciais:  
  <br>user: `admin@admin.com`
  <br>password: `admin`
- Registrar um novo Service com as seguintes informações:
  <br>Aba General > Name: `Nome de sua escolha`
  <br>Aba Connection > host name/address: `postgres`
  <br>Aba Connection > username: `postgres`
  <br>Aba Connection > password: `postgres`
  
  
  ### Na raiz do projeto possui o arquivo abaixo para importar no Insomnia, com todas as requições que são possíveis fazer: 
  `Insomnia_qyonAdventures.json`
  

