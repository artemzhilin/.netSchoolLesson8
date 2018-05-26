using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAccess.Entities;

namespace CashMachine.ViewModels.Accounts
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(16)]
        [CreditCard(ErrorMessage = "Enter valid card number")]
        [DisplayName("Card number")]
        public string CardID { get; set; }
        
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Pin Code must be exactly 4 digits!")]
        public string PinCode { get; set; }
        
        [Required]
        [Compare("PinCode", ErrorMessage = "PinCode and PinCodeConfirm do not match!")]
        public string PinCodeConfirm { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string Country { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string City { get; set; }
        
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string State { get; set; }
        
        [MaxLength(50, ErrorMessage = "Maximum length is 100 characters")]
        public string Address { get; set; }

        public ClientModel ParseClient()
        {
            return new ClientModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Phone = this.Phone,
                Cards = new List<CardModel> {new CardModel {CardId = this.CardID, PinCode = this.PinCode, Balance = 0}},
                AddressModel = new AddressModel
                {
                    Country = this.Country,
                    City = this.City,
                    State = this.State,
                    Address_ = this.Address
                }
            };
        }
    }
}