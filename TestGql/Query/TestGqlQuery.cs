using TestGql.Data;
using TestGql.Model;
using TestGql.Types;

namespace TestGql.Query;

public class TestGqlQuery {
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco degli autori di libri")]
    public IQueryable<Autore> GetAutore(TestGqlDbContext context) => context.Autori;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco delle case editrici")]
    public IQueryable<CasaEditrice> GetCasaEditrice(TestGqlDbContext context) => context.CaseEditrici;

    [UseProjection]
    [UseFiltering(typeof(LibroFilterType))]
    [UseSorting(typeof(LibroSortType))]
    [GraphQLDescription("Elenco dei libri presenti in archivio")] 
    public IQueryable<Libro> GetLibro(TestGqlDbContext context) => context.Libri;
}
