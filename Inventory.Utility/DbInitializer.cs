﻿using Inventory.Models;
using Inventory.Repositary;
using Inventory.Uitility.HelperClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Uitility
{
    public class DbInitializern : IDbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SuperAdmin _superAdmin;
        private ApplicationDbContext _context;
        private IRoleInventory _roleInventory;
        public DbInitializern(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<SuperAdmin> superAdmin, ApplicationDbContext context, IRoleInventory roleInventory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _superAdmin = superAdmin.Value;
            _context = context;
            _roleInventory = roleInventory;
        }

        public async Task CreateSuperAdmin()
        {
            AppUser user = new AppUser();
            user.Email = "";
            user.UserName = "";
            user.EmailConfirmed = true;
            var response = await _userManager.CreateAsync(user, _superAdmin.Password);
            if (response.Succeeded)
            {
                UserProfile userProfile = new UserProfile();
                userProfile.FirstName = "Admin";
                userProfile.LastName = "Admin";
                userProfile.Email = user.Email;
                userProfile.AppUserId = user.Id;
                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();
                await _roleInventory.AddRoleAsync(user.Id);



            }
        }

        public async Task SendEmail(string FromEmail, string FromName, string subject,  string Message, string toEmail, string toName, string smtpUser, string smtpPassword, string smtpHost, string smtpPort, bool smtpSSL)
        {
            var body = Message;
            var messageRequest = new MailMessage();
            messageRequest.To.Add(new MailAddress(toEmail, toName));
            messageRequest.From = new MailAddress(FromEmail, FromName);
            messageRequest.Subject = subject;
            messageRequest.Body = body;
            messageRequest.IsBodyHtml = true;
            using (var smtp = new SmtpClient()) 
            {
                var credientail = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword,
                };
                smtp.Credentials = credientail;
                smtp.Host = smtpHost;
                smtp.Port = Convert.ToInt32(smtpPort);
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(messageRequest);

            }

        }

        public async Task<string> UploadFiles(List<IFormFile> files, IWebHostEnvironment env, string Directory)
        {
            var response = String.Empty;
            var upload = Path.Combine(env.WebRootPath,Directory);
            var fileExtension = string.Empty;
            var filePath = string.Empty;
            var fileName = string.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    fileExtension = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString() + fileExtension;
                    filePath = Path.Combine(upload, fileName);
                    using (var ms = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(ms);
                    }
                    response = fileName;

                }
            }
            return response;

        }

       
    }
}
