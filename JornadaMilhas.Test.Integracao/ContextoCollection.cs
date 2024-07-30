namespace JornadaMilhas.Test.Integracao;

[CollectionDefinition(nameof(ContextoCollection))]
public class ContextoCollection : ICollectionFixture<ContextoFixture>
{
}

/*
O que aconteceu? Utilizamos dois recursos do xUnit, o ClassFixture para compartilhar recursos dentro da mesma classe e o CollectionFixture para compartilhar recursos quando temos mais de uma classe diferente, que utiliza o mesmo recurso.

Com isso, conseguimos otimizar bastante a utilização da conexão com o banco, porque não precisamos mais ficar criando e desfazendo uma conexão todas as vezes que executamos um teste. Na próxima aula, vamos continuar avançando em testes de integração. Até lá. 
*/