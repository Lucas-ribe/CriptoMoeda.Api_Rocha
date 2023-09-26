# CriptoMoeda.Api_Rocha

Foram criados 3 novos endpoints
1 - Ao pesquisar uma criptomoeda seus dados são salvos na tabela de Historico e de Registro, ao pesquisar novamente a mesma criptomoeda é criada uma nova linha na tabela de historico, porem na tabela de Registro é feito uma atualização mantendo assim somente uma linha para cada criptomoeda.
2 - Endpoint que retorna todo o historico de uma criptomoeda especifica.
3 - Endpoint que retorna o registro de uma criptomoeda especifica.


Create table HistoricoPesquisaMoedas
( Id int IDENTITY(1,1) not null,
Sigla varchar(20) not null, 
MaiorPreco decimal not null, 
MenorPreco decimal not null,
QuantidadeNegociada decimal not null,
PrecoUnitario decimal not null,
MaiorPrecoOfertado decimal not null,
MenorPrecoOfertado decimal not null,
DataHora datetime not null, 
constraint Pk_Id_Historico primary key clustered (Id ASC) );

Create table RegistroAtualizadoMoedas 
( Id int IDENTITY(1,1) not null,
Sigla varchar(20) not null, 
MaiorPreco decimal not null, 
MenorPreco decimal not null,
QuantidadeNegociada decimal not null,
PrecoUnitario decimal not null,
MaiorPrecoOfertado decimal not null,
MenorPrecoOfertado decimal not null,
DataHora datetime not null, 
constraint Pk_Id_Registro primary key clustered (Id ASC) );
