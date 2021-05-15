using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

namespace Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public static string GetUserProperty(string accountName, string propertyName)
        {
            if (string.IsNullOrEmpty(accountName)) return string.Empty;
            var entry = new DirectoryEntry
            {
                Path = "LDAP://fg.local:389/DC=fg,DC=local",
                AuthenticationType = AuthenticationTypes.Secure
            };
            var search = new DirectorySearcher(entry) { Filter = "(SAMAccountName=" + accountName + ")" };
            search.PropertiesToLoad.Add(propertyName);
            var results = search.FindAll();
            return results.Count > 0 ? results[0].Properties[propertyName][0].ToString() : "Unknown User";
        }
    }
}