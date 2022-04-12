using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter Account.")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }
        public string DenialReason { get; set; }
    }
    public class LoginAuthorizeVM
    {
        public LoginAuthorizeVM(int userId, int teamId,string userName)
        {
            UserId = userId;
            UserName = userName;
            TeamId = teamId;
            LookOrders_Proccess = false;
            LookOrders_Place = false;
            LookInventory = false;
            LookEntities = false;
            LookReports = false;
            LookSettings = true;
            LookAdmin = false;
        }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public string UserName { get; set; }
        public bool LookOrders_Proccess { get; set; }
        public bool LookOrders_Place { get; set; }
        public bool LookInventory { get; set; }
        public bool LookEntities { get; set; }
        public bool LookReports { get; set; }
        public bool LookSettings { get; set; }
        public  bool LookAdmin { get; set; }
    }

}
