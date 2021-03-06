// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6

using DataAccess.DbContext.Initializer;

#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace DataAccess.DbContext
{

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public class BankContext : System.Data.Entity.DbContext, IBankContext
    {
        public System.Data.Entity.DbSet<Entities.AddressModel> Addresses { get; set; } // Addresses
        public System.Data.Entity.DbSet<Entities.CardModel> Cards { get; set; } // Cards
        public System.Data.Entity.DbSet<Entities.ClientModel> Clients { get; set; } // Clients
        public System.Data.Entity.DbSet<Entities.OperationModel> Operations { get; set; } // Operations


        /// <summary>
        /// Static constructor creates new database if it doesn't exist
        /// </summary>
        static BankContext()
        {
            System.Data.Entity.Database.SetInitializer<BankContext>(
                new CashMachineInitializer());
        }

        public BankContext()
            : base()
        {
        }

        /// <summary>
        /// BankContext constructor
        /// </summary>
        /// <param name="connectionString">A connection string or a database name</param>
        public BankContext(string connectionString)
            : base(connectionString)
        {
        }

        public BankContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public BankContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public BankContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Mappings.AddressConfiguration());
            modelBuilder.Configurations.Add(new Mappings.CardConfiguration());
            modelBuilder.Configurations.Add(new Mappings.ClientConfiguration());
            modelBuilder.Configurations.Add(new Mappings.OperationConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new Mappings.AddressConfiguration(schema));
            modelBuilder.Configurations.Add(new Mappings.CardConfiguration(schema));
            modelBuilder.Configurations.Add(new Mappings.ClientConfiguration(schema));
            modelBuilder.Configurations.Add(new Mappings.OperationConfiguration(schema));
            return modelBuilder;
        }
    }
}
// </auto-generated>
