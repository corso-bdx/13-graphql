using TestGQL.Data;
using TestGQL.Model;
using TestGQL.Types;

namespace TestGQL.Query {
    public class TestGQLQuery {

        [UseDbContext(typeof(TestGQLDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Elenco degli autori di libri")]
        public IQueryable<Autore> GetAutore([ScopedService] TestGQLDBContext context) => context.Autori;

        [UseDbContext(typeof(TestGQLDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Elenco delle case editrici")]
        public IQueryable<CasaEditrice> GetCasaEditrice([ScopedService] TestGQLDBContext context) => context.CaseEditrici;

        [UseDbContext(typeof(TestGQLDBContext))]
        //[UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(LibroFilterType))]
        [UseSorting(typeof(LibroSortType))]
        [GraphQLDescription("Elenco dei libri presenti in archivio")] 
        public IQueryable<Libro> GetLibro([ScopedService] TestGQLDBContext context) => context.Libri;
    }
}
