using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using RestaurantMVC.BusinessLayer.Services;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IFileProvider _fileProvider;

        public StaffController(IStaffService staffService, IFileProvider fileProvider)
        {
            _staffService = staffService;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            var staff = await _staffService.GetAllAsync();
            var staffViewModel = staff.Select(x => new StaffViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImageURL = x.ImageURL,
                Title = x.Title,
                SocialMedia1 = x.SocialMedia1,
                SocialMedia2 = x.SocialMedia2,
                SocialMedia3 = x.SocialMedia3
            });

            return View(staffViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StaffCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var staff = new Staff
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                SocialMedia1 = model.SocialMedia1,
                SocialMedia2 = model.SocialMedia2,
                SocialMedia3 = model.SocialMedia3
            };

            var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
            var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

            using var stream = new FileStream(newPicturePath, FileMode.Create);
            await model.ImageURL.CopyToAsync(stream);

            staff.ImageURL = randomFileName;


            await _staffService.AddAsync(staff);
            return RedirectToAction("Index", "Staff", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            if (staff == null)
            {
                return View();
            }

            var staffViewModel = new StaffViewModel
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Title = staff.Title,
                ImageURL = staff.ImageURL,
                SocialMedia1 = staff.SocialMedia1,
                SocialMedia2 = staff.SocialMedia2,
                SocialMedia3 = staff.SocialMedia3
            };

            return View(staffViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(StaffUpdateViewModel model)
        {
            var staff = await _staffService.GetByIdAsync(model.Id);
            if (staff == null)
            {
                return View();
            }

            if (model.ImageURL  != null)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await model.ImageURL.CopyToAsync(stream);
                staff.ImageURL = randomFileName;
            }

            staff.FirstName = model.FirstName;
            staff.LastName = model.LastName;
            staff.Title = model.Title;
            staff.SocialMedia1 = model.SocialMedia1;
            staff.SocialMedia2 = model.SocialMedia2;
            staff.SocialMedia3 = model.SocialMedia3;

            _staffService.Update(staff);
            return RedirectToAction("Index", "Staff", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            if (staff == null)
            {
                return View();
            }

            _staffService.Delete(staff);
            return RedirectToAction("Index", "Staff", new { area = "Admin" });
        }
    }
}
