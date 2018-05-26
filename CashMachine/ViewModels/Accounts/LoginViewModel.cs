using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CashMachine.ViewModels.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [CreditCard(ErrorMessage = "Enter valid card number")]
        [DisplayName("Card number")]
        public string CardID { get; set; }
        
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Pin Code must be exactly 4 digits!")]
        public string PinCode { get; set; }
    }
}