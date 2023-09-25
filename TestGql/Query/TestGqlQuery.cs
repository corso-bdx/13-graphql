using TestGql.Data;
using TestGql.Model;
using TestGql.Types;

namespace TestGql.Query;

public class TestGqlQuery {
    [UseDbContext(typeof(TestGqlDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco degli autori di libri")]
    public IQueryable<Autore> GetAutore([Service(ServiceKind.Pooled)] TestGqlDbContext context) => context.Autori;

    [UseDbContext(typeof(TestGqlDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco delle case editrici")]
    public IQueryable<CasaEditrice> GetCasaEditrice([Service(ServiceKind.Pooled)] TestGqlDbContext context) => context.CaseEditrici;

    [UseDbContext(typeof(TestGqlDbContext))]
    //[UseOffsetPaging(IncludeTotalCount = true)]
    [UseFiltering(typeof(LibroFilterType))]
    [UseSorting(typeof(LibroSortType))]
    [GraphQLDescription("Elenco dei libri presenti in archivio")] 
    public IQueryable<Libro> GetLibro([Service(ServiceKind.Pooled)] TestGqlDbContext context) => context.Libri;
}
