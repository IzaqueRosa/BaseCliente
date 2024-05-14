O projeto consiste em três pastas principais:

-Scripts: Contém um arquivo .sql responsável pela criação do banco de dados, tabelas e insert de alguns exemplos de cadastros, deve ser executado antes de iniciar os outros dois projetos.
-API: API Web responsável pela comunicação com o banco de dados, a solution está dentro da pasta /BaseClienteAPI. O APP settings está apontando para a minha conexão local, deve ser ajustado com base na conexão utilizada pelo tester:
  -"DefaultConnection": "Server=localhost;Database=BaseCliente;User=sa;Password=123;Encrypt=False;"
-BaseCliente: Aplicação Web responsável pelo front da aplicação. 
