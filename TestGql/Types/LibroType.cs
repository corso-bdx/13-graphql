using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using TestGql.Data;
using TestGql.Model;

namespace TestGql.Types;

public class LibroObjectType : ObjectType<Libro> {
    protected override void Configure(IObjectTypeDescriptor<Libro> descriptor) {
        descriptor.BindFieldsExplicitly();

        descriptor
            .Description("Dettaglio del libro presente in archivio");

        descriptor
            .Field(x => x.LibroID)
            .Description("Codice univoco relativo al libro in archivio");

        descriptor
            .Field(x => x.Titolo)
            .Description("Titolo del libro in archivio");

        descriptor
            .Field(x => x.Prezzo)
            .Description("Prezzo del libro in archivio");

        //descriptor
        //    .Field(x => x.BestSeller)
        //    .Description("Flag indicativo del fatto che il libro in archivio è un bestseller").Ignore();

        descriptor
            .Field(x => x.AutoreID)
            .Description("Codice univoco dell'autore del libro");
            //.Ignore();

        descriptor
            .Field(x => x.CasaEditriceID)
            .Description("Codice univoco della casa editrice del libro");
            //.Ignore();

        descriptor
            .Field(x => x.Autore)
            .ResolveWith<Resolver>(r => r.GetAutore(default!, default!))
            .UseDbContext<TestGqlDbContext>()
            .Description("Dettaglio completo dell'autore del libro in archivio");

        descriptor
            .Field(x => x.CasaEditrice)
            .ResolveWith<Resolver>(r => r.GetCasaEditrice(default!, default!))
            .UseDbContext<TestGqlDbContext>()
            .Description("Dettaglio completo della casa editrice del libro in archivio");

    }

    private class Resolver {
        public Autore? GetAutore([Parent] Libro libro, TestGqlDbContext context) {
            return context.Autori.Where(x => x.AutoreID == libro.AutoreID).FirstOrDefault();
        }

        public CasaEditrice? GetCasaEditrice([Parent] Libro libro, TestGqlDbContext context) {
            return context.CaseEditrici.Where(x => x.CasaEditriceID == libro.CasaEditriceID).FirstOrDefault();
        }
    }
}

public class LibroFilterType : FilterInputType<Libro> {
    protected override void Configure(IFilterInputTypeDescriptor<Libro> descriptor) {
        descriptor.BindFieldsExplicitly();

        descriptor
            .Field(x => x.Titolo);
        descriptor
            .Field(x => x.Prezzo).Name("costo");
        descriptor
            .Field(x => x.Autore).Name("autore");
        descriptor
            .Field(x => x.CasaEditrice).Name("editore");
    }
}

public class LibroSortType : SortInputType<Libro> {

    protected override void Configure(ISortInputTypeDescriptor<Libro> descriptor) {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Prezzo).Name("costo");
        descriptor.Field(x => x.Titolo);
    }
}
