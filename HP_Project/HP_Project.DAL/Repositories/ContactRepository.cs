using HP_Project.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_Project.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var contacts = _context.Contacts;

            foreach (var contact in contacts)
            {
                contact.ApplicationUser = await _userManager.FindByIdAsync(contact.ApplicationUserId);
            }

            return contacts;
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public Contact Add(Contact contact)
        {
            var newContact = _context.Contacts.Add(contact);

            if (newContact != null && newContact.State == EntityState.Added)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newContact.Entity;
                }
            }

            return null;
        }

        public Contact Update(Contact contact)
        {
            var newContact = _context.Contacts.Update(contact);

            if (newContact != null && newContact.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newContact.Entity;
                }
            }

            return null;
        }

        public Contact Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact != null)
            {
                var deletedContact = _context.Contacts.Remove(contact);

                if (deletedContact != null && deletedContact.State == EntityState.Deleted)
                {
                    try
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            return deletedContact.Entity;
                        }
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                    
                }
            }

            return null;
        }
    }
}
