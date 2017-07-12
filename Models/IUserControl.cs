using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
   
    interface IUserControl
    {
        void logout();
        void login(string Email, string Password);
        void listUsers();
        void setStudent(Student Student);
        void toggleBlockStatus(Student Student);
    }
}