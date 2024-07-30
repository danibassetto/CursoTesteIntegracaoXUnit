using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao;

public class ContextoFixture
{
    public JornadaMilhasContext Context { get; }

    public ContextoFixture()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").Options;

        Context = new JornadaMilhasContext(options);
    }
}