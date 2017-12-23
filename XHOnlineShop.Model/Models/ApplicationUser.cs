using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace XHOnlineShop.Model.Models
{
    public class ApplicationUser:IdentityUser
    {
        [MaxLength(256)]
        public string FullName { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            //quản lí thông tin identity thông qua cookies
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
