using System.ComponentModel.DataAnnotations;
 
namespace CashMachine.ViewModels.Operations
{
    public class WithdrawViewModel
    {
        [Required]
        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "Invalid format. Example: 60,12")]
        public string Amount { get; set; }
    }
}