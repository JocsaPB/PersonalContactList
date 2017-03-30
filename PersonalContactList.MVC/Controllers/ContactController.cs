using PersonalContactList.Domain.Entities;
using PersonalContactList.Domain.ValueObjects;
using PersonalContactList.Infra.Data.Repositories;
using PersonalContactList.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PersonalContactList.MVC.Controllers
{
    public class ContactController : Controller
    {

        private readonly ContactRepository _contactRepository = new ContactRepository();

        // GET: Contact
        public ActionResult Index()
        {
            IEnumerable<Contact> ContactsFromBase = _contactRepository.FindAll();

            List<ContactViewModel> contactsToView = new List<ContactViewModel>();
            foreach(Contact contact in ContactsFromBase)
            {
                contactsToView.Add(new ContactViewModel
                {
                    ContatId = contact.ContatId,
                    Name = contact.Name,
                    KnownAs = contact.KnownAs,
                    CategoryId = contact.CategoryId,
                    EmailA = contact.Emails.EmailA,
                    EmailB = contact.Emails.EmailB,
                    TelNumberA = contact.Numbers.TelNumberA,
                    TelNumberB = contact.Numbers.TelNumberB,
                    Facebook = contact.Social.Facebook,
                    Instagran = contact.Social.Instagran,
                    Linkedin = contact.Social.Linkedin,
                    Twiiter = contact.Social.Twiiter,
                    Whatsapp = contact.Social.Whatsapp
                });
            }

            return View(contactsToView);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            Contact contactFromBase = _contactRepository.FindById(id);

            ContactViewModel contactViewModel = new ContactViewModel
            {
                ContatId = contactFromBase.ContatId,
                Name = contactFromBase.Name,
                KnownAs = contactFromBase.KnownAs,
                CategoryId = contactFromBase.CategoryId,
                EmailA = contactFromBase.Emails.EmailA,
                EmailB = contactFromBase.Emails.EmailB,
                TelNumberA = contactFromBase.Numbers.TelNumberA,
                TelNumberB = contactFromBase.Numbers.TelNumberB,
                Facebook = contactFromBase.Social.Facebook,
                Instagran = contactFromBase.Social.Instagran,
                Linkedin = contactFromBase.Social.Linkedin,
                Twiiter = contactFromBase.Social.Twiiter,
                Whatsapp = contactFromBase.Social.Whatsapp
            };

            return View(contactViewModel);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactViewModel contactViewModel)
        {
            try
            {
                Contact contactToBase = new Contact
                {
                    ContatId = contactViewModel.ContatId,
                    Name = contactViewModel.Name,
                    KnownAs = contactViewModel.KnownAs,
                    CategoryId = contactViewModel.CategoryId,
                    Emails = new Emails
                        {
                            EmailA = contactViewModel.EmailA,
                            EmailB = contactViewModel.EmailB
                        },
                    Numbers = new TelNumbers
                    {
                        TelNumberA = contactViewModel.TelNumberA,
                        TelNumberB = contactViewModel.TelNumberB
                    },
                    Social = new Social
                    {
                        Facebook = contactViewModel.Facebook,
                        Instagran = contactViewModel.Instagran,
                        Linkedin = contactViewModel.Linkedin,
                        Twiiter = contactViewModel.Twiiter,
                        Whatsapp = contactViewModel.Whatsapp
                    }
                };

                _contactRepository.Add(contactToBase);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contactFromBase = _contactRepository.FindById(id);

            ContactViewModel contactViewModel = new ContactViewModel
            {
                ContatId = contactFromBase.ContatId,
                Name = contactFromBase.Name,
                KnownAs = contactFromBase.KnownAs,
                CategoryId = contactFromBase.CategoryId,
                EmailA = contactFromBase.Emails.EmailA,
                EmailB = contactFromBase.Emails.EmailB,
                TelNumberA = contactFromBase.Numbers.TelNumberA,
                TelNumberB = contactFromBase.Numbers.TelNumberB,
                Facebook = contactFromBase.Social.Facebook,
                Instagran = contactFromBase.Social.Instagran,
                Linkedin = contactFromBase.Social.Linkedin,
                Twiiter = contactFromBase.Social.Twiiter,
                Whatsapp = contactFromBase.Social.Whatsapp
            };

            return View(contactViewModel);
        }

        // POST: Contact/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, ContactViewModel contactViewModel)
        {
            Contact contactToBase = _contactRepository.FindById(id);
            contactToBase.Name = contactViewModel.Name;
            contactToBase.KnownAs = contactViewModel.KnownAs;
            contactToBase.CategoryId = contactViewModel.CategoryId;
            contactToBase.Numbers = new TelNumbers
            {
                TelNumberA = contactViewModel.TelNumberA,
                TelNumberB = contactViewModel.TelNumberB
            };
            contactToBase.Emails = new Emails
            {
                EmailA = contactViewModel.EmailA,
                EmailB = contactViewModel.EmailB
            };
            contactToBase.Social = new Social
            {
                Facebook = contactViewModel.Facebook,
                Instagran = contactViewModel.Instagran,
                Linkedin = contactViewModel.Linkedin,
                Twiiter = contactViewModel.Twiiter,
                Whatsapp = contactViewModel.Whatsapp
            };

            _contactRepository.Update(contactToBase);

            return RedirectToAction("Index");
           
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contactFromBase = _contactRepository.FindById(id);

            ContactViewModel contactViewModel = new ContactViewModel
            {
                ContatId = contactFromBase.ContatId,
                Name = contactFromBase.Name,
                KnownAs = contactFromBase.KnownAs,
                CategoryId = contactFromBase.CategoryId,
                EmailA = contactFromBase.Emails.EmailA,
                EmailB = contactFromBase.Emails.EmailB,
                TelNumberA = contactFromBase.Numbers.TelNumberA,
                TelNumberB = contactFromBase.Numbers.TelNumberB,
                Facebook = contactFromBase.Social.Facebook,
                Instagran = contactFromBase.Social.Instagran,
                Linkedin = contactFromBase.Social.Linkedin,
                Twiiter = contactFromBase.Social.Twiiter,
                Whatsapp = contactFromBase.Social.Whatsapp
            };

            return View(contactViewModel);
        }

        // POST: Contact/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, ContactViewModel contactViewModel)
        {

            Contact contactToBase = _contactRepository.FindById(id);
            _contactRepository.Delete(contactToBase);

            return RedirectToAction("Index");
           
        }
    }
}
