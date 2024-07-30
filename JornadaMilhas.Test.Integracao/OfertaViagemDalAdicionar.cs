using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalAdicionar
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalAdicionar(ITestOutputHelper output, ContextoFixture contextoFixture)
    {
        context = contextoFixture.Context;
        output.WriteLine(context.GetHashCode().ToString());
    }

    [Fact]
    public void RegistraOfertaNoBanco()
    {
        //arrange
        Rota rota = new("S�o Paulo", "Fortaleza");
        Periodo periodo = new(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;        

        var oferta = new OfertaViagem(rota, periodo, preco);
        var dal = new OfertaViagemDAL(context);

        //act
        dal.Adicionar(oferta);

        //assert
        var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
        Assert.NotNull(ofertaIncluida);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
    }

    [Fact]
    public void RegistraOfertaNoBancoComInformacoesCorretas()
    {
        //arrange
        Rota rota = new("S�o Paulo", "Fortaleza");
        Periodo periodo = new(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = 350;        

        var oferta = new OfertaViagem(rota, periodo, preco);
        var dal = new OfertaViagemDAL(context);

        //act
        dal.Adicionar(oferta);

        //assert
        OfertaViagem ofertaIncluida = dal.RecuperarPorId(oferta.Id) ?? new();
        Assert.Equal(ofertaIncluida.Rota.Origem, oferta.Rota.Origem);
        Assert.Equal(ofertaIncluida.Rota.Destino, oferta.Rota.Destino);
        Assert.Equal(ofertaIncluida.Periodo.DataInicial, oferta.Periodo.DataInicial);
        Assert.Equal(ofertaIncluida.Periodo.DataFinal, oferta.Periodo.DataFinal);
        Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.001);
    }
}