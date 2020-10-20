using Acklann.Mockaroo;
using Acklann.Mockaroo.Fields;
using Model;
using System;

namespace Tester
{
    internal class MockarooFiller : IDataFiller
    {
        private readonly Schema<Wykaz> WykazySchema;
        private readonly Schema<Katalog> KatalogiSchema;
        private readonly Schema<OpisStanu> StanySchema;
        private readonly Schema<Zdarzenie> ZdarzeniaSchema;

        public MockarooFiller()
        {
            WykazySchema = new Schema<Wykaz>();
            KatalogiSchema = new Schema<Katalog>();
            StanySchema = new Schema<OpisStanu>();
            ZdarzeniaSchema = new Schema<Zdarzenie>();
            SetupSchema();
        }

        private void SetupSchema()
        {
            WykazySchema.Replace(x => x.Imie, DataType.FirstName);
            WykazySchema.Replace(x => x.Nazwisko, DataType.LastName);
            WykazySchema.Replace(x => x.ID, DataType.RowNumber);

            KatalogiSchema.Replace(x => x.Autor, DataType.FullName);
            KatalogiSchema.Replace(x => x.DataWydania, new DateField
            {
                Min = DateTime.Parse("1997-01-01"),
                Max = DateTime.Parse("2002-12-31")
            });
            KatalogiSchema.Replace(x => x.LiczbaStron, new NumberField
            {
                Min = 5,
                Max = 500
            });
            // Opis jest lorem


        }

        public void Fill(DataContext context)
        {
            throw new NotImplementedException();
        }
    }
}