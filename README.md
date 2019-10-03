# Projeto Crrud simples de Apsnet.
## Sobre o projeto

Este projeto é uma crud simples feita com Asp.net core e EntityFramework, tento por base os tutorais da microsoft. Sas consultas são feitas em rest.

Para utilizar o banco de dados postgresql, uma pendencia do projeto um docker-compose para instanciar um banco postgresql foi feito. Logo, se quiser subir estre projeto, é esperado ter Docker

## Para subir o projeto

### Docker com postgresql
Na paste envs, você verá dois arquivos env_samples.env. Um para pgadmim, outro para o postgresql de fato.

Crie arquivos chamados pgadmin.env e postgresql.env na raiz do pojeto, uilizando seus samples para ter noção de como preenche-los

```.env
PGADMIN_DEFAULT_EMAIL=<email>
PGADMIN_DEFAULT_PASSWORD=<password>
```

Este é o sample de pgadmim. Substituar pelo usuário e senha que quer utilizar para acessar a página.

```.env
POSTGRES_PASSWORD=<or_password>
POSTGRES_USER={our_user}
POSTGRES_DB={our-db_database}
```

Estes são os parametros do postgresql. Subistituar as tagas pela senha, usuário padrão e o nome de um banco de dados já criados quando  o docker for iniciado.

Criado os arquvis na Raiz, execute o comando no terminal, na raiz do projto:

```bash
docker-compose up
```

Espere as imagens serem baixadas e os logs mostarem que estar tudo bem.

### Sobre o dódigo .net

Navege até a pasta src. Lá, com o docker do postgresql já iniciado, execute o sseguinte comando:

```.net
dotnet run
``` 

Ele baixarar os objetos que precisa e copilarar o projeto. Se tudo der certo, ele digar que a aplicação vai estar escutando em https://localhost:5001/