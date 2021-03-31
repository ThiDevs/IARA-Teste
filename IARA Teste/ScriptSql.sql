Create table Cotacao(
IdCotacao int identity(1,1),
CNPJComprador varchar(15) not null,
CNPJFornecedor varchar(15) not null,
NumeroCotacao int not null,
DataCotacao DateTime not null,
DataEntregaCotacao DateTime not null,
CEP varchar(10) not null,
Logradouro varchar(100),
Complemento varchar(100),
Bairro varchar(100),
UF varchar (2),
Observacao varchar(250),
)

Create table CotacaoItem(
IdCotacaoItem int identity(1,1),
IdCotacao int not null,
Descricao varchar(max) not null,
NumeroItem int not null,
Preco Decimal (16,2),
Quantidade int not null,
Marca varchar(100) not null,
Unidade varchar(100) not null,
)