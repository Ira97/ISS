using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISectionProvider _sectionProvider;

        public ContactController(ISectionProvider sectionProvider)
        {
            _sectionProvider = sectionProvider;
        }

        // GET: ContactController
        public async Task<IActionResult> IndexAsync(int researchId)
        {
            var contactViewModel = new ContactViewModel
            {
                ResearchId = researchId,
                DataObjectList = await _sectionProvider.GetObjectListAsync(),
                SecondDataObjectList = await _sectionProvider.GetObjectListAsync(),
                ContactList = await _sectionProvider.GetContactListAsync(),
                SectionList = await _sectionProvider.GetSectionListAsync()
            };
            return View(contactViewModel);
        }
    }
}
