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
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace DataAccess.DbContext.Mappings
{

    // Operations
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public class OperationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Entities.OperationModel>
    {
        public OperationConfiguration()
            : this("dbo")
        {
        }

        public OperationConfiguration(string schema)
        {
            ToTable("Operations", schema);
            HasKey(x => x.OperationId);

            Property(x => x.OperationId).HasColumnName(@"OperationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OutId).HasColumnName(@"OutID").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(x => x.InId).HasColumnName(@"InID").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(x => x.Amount).HasColumnName(@"Amount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.OutBalanceAfter).HasColumnName(@"OutBalanceAfter").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.InBalanceAfter).HasColumnName(@"InBalanceAfter").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.OperationTime).HasColumnName(@"OperationTime").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.In).WithMany(b => b.Operations_In).HasForeignKey(c => c.InId).WillCascadeOnDelete(false); // FK_InCard
            HasRequired(a => a.Out).WithMany(b => b.Operations_Out).HasForeignKey(c => c.OutId).WillCascadeOnDelete(false); // FK_OutCard
        }
    }

}
// </auto-generated>