# OpenBankingAPI
 API bancária para realizar saques, depósitos e consultas a extrato bancário.

##Configurações do sistema
- Banco de Dados: é utilizado o banco de dados SQL Server em Arquivo, que esta dentro do projeto. Logo, é possível executar a aplicação em qualquer computador sem que haja necessidade de novas configurações.

- Autenticação: O sistema utiliza autenticação JWT. Para consumir os endpoints é necessário acrescentar ao cabeçalho um token do tipo "bearer". O token pode ser gerado a partir da rota de login. Por default, para realizar o login podemos utilizar o seguinte corpo para a requisição:

 {
  "usuario" : "usuario",
  "senha" : "senha" 
 }
 
 O token esta configurado para expirar após 4 minutos.
 
 Os cabeçalhos das requisições deverão conter a chave "Authorization" com o valor "bearer tokenGeradoAoRealizarLogin"
 
##Rotas
- Login (POST): https://localhost:44368/api/login

- Consulta Extrato (GET): https://localhost:44368/api/transacoes/P/CPF onde P é o período de consulta (7, 15, 30, 60) e o CPF é o número do CPF do cliente (existem dois exemplo salvos no banco: 30070010010 e 40050010010). Se o período utilizado for diferente dos sugeridos acima a aplicação reportará erro.

- Realizar Saque (POST): https://localhost:44368/api/transacoes/sacar/CPF onde CPF é o número do CPF do cliente, como no exemplo acima. O valor a ser inserido deve ser passado pelo corpo da requisição, como no exemplo abaixo:

100.55

- Realizar Depósito (POST): https://localhost:44368/api/transacoes/depositar/CPF onde as características são similares a ação de saque.
