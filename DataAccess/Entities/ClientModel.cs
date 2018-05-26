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


namespace DataAccess.Entities
{

    // Clients
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public class ClientModel
    {
        public int ClientId { get; set; } // ClientID (Primary key)
        public string FirstName { get; set; } // FirstName (length: 50)
        public string LastName { get; set; } // LastName (length: 50)
        public System.DateTime? Birthday { get; set; } // Birthday
        public string Phone { get; set; } // Phone (length: 30)

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) Client pointed by [Addresses].[ClientID] (FK_ClientAddress)
        /// </summary>
        public virtual AddressModel AddressModel { get; set; } // Addresses.FK_ClientAddress
        /// <summary>
        /// Child Cards where [Cards].[ClientID] point to this entity (FK_ClientCard)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CardModel> Cards { get; set; } // Cards.FK_ClientCard

        public ClientModel()
        {
            Cards = new System.Collections.Generic.List<CardModel>();
        }

        public override string ToString()
        {
            return new {
                ID = ClientId,
                FullName = $"{FirstName} {LastName}",
                Phone = Phone
            }.ToString();
        }
    }

}
// </auto-generated>
