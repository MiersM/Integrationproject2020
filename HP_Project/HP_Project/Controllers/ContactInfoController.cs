using HP_Project.DAL.Models;
using HP_Project.DAL.Repositories;
using HP_Project.ViewModels;
using HP_Project.ViewModels.ContactInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Project.Controllers
{
    [Authorize]
    public class ContactInfoController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ITouchpointRepository _touchpointRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactInfoController(
            IContactRepository contactRepository,
            ITouchpointRepository touchpointRepository,
            UserManager<ApplicationUser> userManager)
        {
            _contactRepository = contactRepository;
            _touchpointRepository = touchpointRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            var touchpoints = await _touchpointRepository.GetAllAsync();

            var contactInfoViewModel = new ContactInfoViewModel()
            {
                Contacts = contacts.ToList(),
                Touchpoints = touchpoints.ToList(),
            };

            return View("ContactInfo", contactInfoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ContactCreateAsync()
        {
            var applicationuser = await _userManager.GetUserAsync(HttpContext.User);

            var contactCreateViewModel = new ContactCreateViewModel()
            {
                ApplicationUser = applicationuser,
                ApplicationUserId = applicationuser.Id,
            };

            return View(contactCreateViewModel);
        }

        [HttpPost]
        public IActionResult ContactCreate(ContactCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newContact = new Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                Email = model.Email,
                Phone = model.Phone,
                Mkt = model.Mkt,
                CIOCircle = model.CIOCircle,
                InnovationForum = model.InnovationForum,
                TAC = model.TAC,
                PostalAddress = model.PostalAddress,
                Comments = model.Comments,
                ApplicationUserId = model.ApplicationUserId,
            };

            var response = _contactRepository.Add(newContact);

            if (response == null || response.Id == 0)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ContactUpdate(ContactInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }            

            foreach (var contact in model.Contacts)
            {
                var oldContact = _contactRepository.GetById(contact.Id);

                oldContact.FirstName = contact.FirstName;
                oldContact.LastName = contact.LastName;
                oldContact.Role = contact.Role;
                oldContact.Email = contact.Email;
                oldContact.Phone = contact.Phone;
                oldContact.Mkt = contact.Mkt;
                oldContact.CIOCircle = contact.CIOCircle;
                oldContact.InnovationForum = contact.InnovationForum;
                oldContact.TAC = contact.TAC;
                oldContact.PostalAddress = contact.PostalAddress;
                oldContact.Comments = contact.Comments;

                var response = _contactRepository.Update(oldContact);

                if (response == null || response.Id == 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ContactDelete(int id)
        {
            var contact = _contactRepository.GetById(id);

            if (contact == null)
            {
                return RedirectToAction("Error", id);
            }

            var result = _contactRepository.Delete(id);

            if (result == null)
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> TouchpointCreateAsync()
        {
            var applicationuser = await _userManager.GetUserAsync(HttpContext.User);
            var contacts = await _contactRepository.GetAllAsync();

            var contactSelectListItems = new List<SelectListItem>();

            foreach (var contact in contacts)
            {
                contactSelectListItems.Add(new SelectListItem()
                {
                    Text = $"{contact.FirstName} {contact.LastName}",
                    Value = contact.Id.ToString(),
                });
            }

            var touchpointCreateViewModel = new TouchpointCreateViewModel()
            {
                ApplicationUser = applicationuser,
                ApplicationUserId = applicationuser.Id,
                ContactItems = contactSelectListItems,
            };

            return View(touchpointCreateViewModel);
        }

        [HttpPost]
        public IActionResult TouchpointCreate(TouchpointCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newTouchpoint = new Touchpoint
            {
                Date = model.Date,
                SortOfEvent = model.SortOfEvent,
                Description = model.Description,
                Reminder = model.Reminder,
                ContactId = model.ContactId,
                ApplicationUserId = model.ApplicationUserId,
            };

            var response = _touchpointRepository.Add(newTouchpoint);

            if (response == null || response.Id == 0)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult TouchpointUpdate(ContactInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var touchpoint in model.Touchpoints)
            {
                var oldTouchpoint = _touchpointRepository.GetById(touchpoint.Id);

                oldTouchpoint.Date = touchpoint.Date;
                oldTouchpoint.SortOfEvent = touchpoint.SortOfEvent;
                oldTouchpoint.Description = touchpoint.Description;
                oldTouchpoint.Reminder = touchpoint.Reminder;

                var response = _touchpointRepository.Update(oldTouchpoint);

                if (response == null || response.Id == 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult TouchpointDelete(int id)
        {
            var touchpoint = _touchpointRepository.GetById(id);

            if (touchpoint == null)
            {
                return RedirectToAction("Error", id);
            }

            var result = _touchpointRepository.Delete(id);

            if (result == null)
            {
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
