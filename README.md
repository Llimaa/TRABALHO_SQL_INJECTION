# TRABALHO_SQL_INJECTION
Está aplicação tem como finalidade demonstrar como o ataque Sql_Injection funciona. Vamos demonstrar, na prática, como identificar se a sua aplicação esta vulnerável, e como remover essa vulnerabilidade.

Apos Baixar o projeto. abra o mesmo em seu visual studio,
e localize a linha.
> Public static string ConnectonString = "CONEXAO_DB".

No lugar de CONEXAO_DB, coloque sua conexao do banco de dados. 
Com seu SGBD aberto crie o banco de dados com o seginte nome "sqlInjectDemo".

### Agora é só executar a aplicação.
#### O primeiro passo que você deve executar, é o 3°
  Este passo vair criar uma tabela no banco de dados, e inserir alguns dados.

### Agora você pode executar os outros passos na ordem que preferir.

#### O passo 1° realiza consulta com dados Parametrizados
  Ou seja esse passo estamos parametrizando os dados para evitar ataques de sql injection.
  
  #### O passo 2° realiza consulta com dados não Parametrizados
  Ou seja esse passo estamos deixando nossa aplicação vulnerável para os ataques de sql injection. 
  Neste passo voce pode inserir os seguintes comandos para realizar o ataque:
  > ;'DROP TABLE pessoa--'
  esté comando vai apagar a tabela de pessoa.
  > 'OR '1'='1'--;'
  esté comando vai listar todos os dados cadastrado na tabela pessoa.
  
  #### O passo 3° Vai criar a tabela e inserir alguns dados na mesma.
  
  #### O passo 4° Vai finalizar a aplicação.
  
