using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HP_Project.Models;
using HP_Project.DAL.Models;
using HP_Project.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using HP_Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPOI.OpenXmlFormats.Dml;

namespace HP_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApolloRepository _apolloRepository;
        private readonly IClientEmployeeRepository _clientEmployeeRepository;
        private readonly IInstallBaseRepository _installBaseRepository;
        private readonly IProductHierarchyRepository _productHierarchyRepository;
        private readonly IRADRepository _rADRepository;
        private readonly IRevenueActualsRepository _revenueActualsRepository;
        private readonly ITerritoryCompanyRepository _territoryCompanyRepository;
        private readonly IWorkdayRepository _workdayRepository;
        private readonly IInsightRepository _insightRepository;

        public HomeController(ILogger<HomeController> logger,
            IApolloRepository apolloRepository,
            IClientEmployeeRepository clientEmployeeRepository,
            IInstallBaseRepository installBaseRepository,
            IProductHierarchyRepository productHierarchyRepository,
            IRADRepository rADRepository,
            IRevenueActualsRepository revenueActualsRepository,
            ITerritoryCompanyRepository territoryCompanyRepository,
            IWorkdayRepository workdayRepository,
            IInsightRepository insightRepository)
        {
            _logger = logger;
            _apolloRepository = apolloRepository;
            _clientEmployeeRepository = clientEmployeeRepository;
            _installBaseRepository = installBaseRepository;
            _productHierarchyRepository = productHierarchyRepository;
            _rADRepository = rADRepository;
            _revenueActualsRepository = revenueActualsRepository;
            _territoryCompanyRepository = territoryCompanyRepository;
            _workdayRepository = workdayRepository;
            _insightRepository = insightRepository;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            int newId = id ?? 1;

            //if (newId > 5)
            //{
            //    newId = 1;
            //}

            var apollo = _apolloRepository.GetAll();
            var apolloRowFilters = new List<SelectListItem>();

            foreach (var apolloRow in apollo)
            {
                apolloRowFilters.Add(new SelectListItem
                {
                    Text = $"{apolloRow.Name}",
                    Value = apolloRow.Id.ToString(),
                });
            }

            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                apolloRow = _apolloRepository.GetById(newId),
                clientEmployee = _clientEmployeeRepository.GetById(newId),
                installBase = _installBaseRepository.GetById(newId),
                //productHierarchy = _productHierarchyRepository.GetById(newId),
                rAD = _rADRepository.GetById(newId),
                revenueActuals = _revenueActualsRepository.GetById(newId),
                territoryCompany = _territoryCompanyRepository.GetById(newId),
                //workday = _workdayRepository.GetById(newId),

                ApolloFilterItems = apolloRowFilters,
            };

            //Math.Round((decimal)4);

            //List<TerritoryCompany> list = _territoryCompanyRepository.GetAll().ToList();
            //var item = list.Max(x => x.AmountDesktop);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int id = model.apolloRow.Id;

            var apollo = _apolloRepository.GetAll();
            var apolloRowFilters = new List<SelectListItem>();

            foreach (var apolloRow in apollo)
            {
                apolloRowFilters.Add(new SelectListItem
                {
                    Text = $"{apolloRow.Name}",
                    Value = apolloRow.Id.ToString(),
                });
            }

            HomeIndexViewModel newModel = new HomeIndexViewModel()
            {
                apolloRow = _apolloRepository.GetById(id),
                clientEmployee = _clientEmployeeRepository.GetById(id),
                installBase = _installBaseRepository.GetById(id),
                //productHierarchy = _productHierarchyRepository.GetById(newId),
                rAD = _rADRepository.GetById(id),
                revenueActuals = _revenueActualsRepository.GetById(id),
                territoryCompany = _territoryCompanyRepository.GetById(id),
                //workday = _workdayRepository.GetById(newId),

                ApolloFilterItems = apolloRowFilters,
            };

            return View(newModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApolloCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var apolloRow = new ApolloRow()
                {
                    Id = model.Id,
                    Name = model.Name,
                    IndustrySegment = model.IndustrySegment,
                    IndustryVertical = model.IndustryVertical,
                    AccountSTID = model.AccountSTID,
                    AccountSTName = model.AccountSTName,
                    TopParentSTID = model.TopParentSTID,
                    TopParentSTName = model.TopParentSTName,
                    OrganizationID = model.OrganizationID,
                    OPSIID = model.OPSIID,
                    PRMID = model.PRMID,
                    BusinessRelationshipID = model.BusinessRelationshipID,
                    TaxIdentifier = model.TaxIdentifier
                };


                _apolloRepository.Add(apolloRow);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apolloRow = _apolloRepository.GetById(id);
            var model = new ApolloEditViewModel()
            {
                Id = apolloRow.Id,
                Name = apolloRow.Name,
                IndustrySegment = apolloRow.IndustrySegment,
                IndustryVertical = apolloRow.IndustryVertical,
                AccountSTID = apolloRow.AccountSTID,
                AccountSTName = apolloRow.AccountSTName,
                //TopParentSTID = (int)apolloRow.TopParentSTID ,
                TopParentSTName = apolloRow.TopParentSTName,
                OrganizationID = apolloRow.OrganizationID,
                OPSIID = apolloRow.OPSIID,
                PRMID = apolloRow.PRMID,
                BusinessRelationshipID = apolloRow.BusinessRelationshipID,
                TaxIdentifier = apolloRow.TaxIdentifier
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ApolloEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var apolloRow = _apolloRepository.GetById(model.Id);

                apolloRow.Id = model.Id;
                apolloRow.Name = model.Name;
                apolloRow.IndustrySegment = model.IndustrySegment;
                apolloRow.IndustryVertical = model.IndustryVertical;
                apolloRow.AccountSTID = model.AccountSTID;
                apolloRow.AccountSTName = model.AccountSTName;
                apolloRow.TopParentSTID = model.TopParentSTID;
                apolloRow.TopParentSTName = model.TopParentSTName;
                apolloRow.OrganizationID = model.OrganizationID;
                apolloRow.OPSIID = model.OPSIID;
                apolloRow.PRMID = model.PRMID;
                apolloRow.BusinessRelationshipID = model.BusinessRelationshipID;
                apolloRow.TaxIdentifier = model.TaxIdentifier;

                var updatedApolloRow = _apolloRepository.Update(apolloRow);

                if (updatedApolloRow != null && updatedApolloRow.Id != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 1)
            {
                return RedirectToAction("Index");
            }
            var apolloRow = _apolloRepository.Delete(id);

            if (apolloRow == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        // move to other controllers
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // actions voor navigatie

        [HttpGet]
        public IActionResult Insights()
        {
            var insights = _insightRepository.GetAll();

            InsightsViewModel model = new InsightsViewModel()
            {
                Insights = insights
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Insights(InsightsViewModel model)
        {
            var insights = _insightRepository.GetAll();
            model.Insights = insights;

            if (model.Client == null || model.Text == null || model.Date == null)
            {
                ModelState.AddModelError(String.Empty, "Niet correct ingevuld!");
                return View(model);
            }

            var insight = new Insight()
            {
                Client = model.Client,
                Text = model.Text,
                Date = model.Date//DateTime.Now
            };

            _insightRepository.Add(insight);

            return RedirectToAction("Insights");
        }

        public IActionResult LandscapeShaper()
        {
            return View();
        }

        public IActionResult CustomerFinancials()
        {
            var revenueActuals = _revenueActualsRepository.GetAll();

            var revQ12017 = revenueActuals.Where(r => r.Quarter == "2017Q1").Select(r => r.RevKSadj);

            double result2017Q1 = 0;
            foreach (var revk in revQ12017)
            {
                result2017Q1 += revk;
            }

            var revQ22017 = revenueActuals.Where(r => r.Quarter == "2017Q2").Select(r => r.RevKSadj);

            double result2017Q2 = 0;
            foreach (var revk in revQ22017)
            {
                result2017Q2 += revk;
            }

            var revQ32017 = revenueActuals.Where(r => r.Quarter == "2017Q3").Select(r => r.RevKSadj);

            double result2017Q3 = 0;
            foreach (var revk in revQ32017)
            {
                result2017Q3 += revk;
            }

            var revQ42017 = revenueActuals.Where(r => r.Quarter == "2017Q4").Select(r => r.RevKSadj);

            double result2017Q4 = 0;
            foreach (var revk in revQ12017)
            {
                result2017Q4 += revk;
            }

            //Q1
            var cos2017Q1 = revenueActuals.Where(r => r.Quarter == "2017Q1").Select(r => r.CosKSadj);
            double resultcos2017Q1 = 0;
            foreach (var revcos in cos2017Q1)
            {
                resultcos2017Q1 += revcos;
            }

            //Q2
            var cos2017Q2 = revenueActuals.Where(r => r.Quarter == "2017Q2").Select(r => r.CosKSadj);
            double resultcos2017Q2 = 0;
            foreach (var revcos in cos2017Q2)
            {
                resultcos2017Q2 += revcos;
            }

            //Q3
            var cos2017Q3 = revenueActuals.Where(r => r.Quarter == "2017Q3").Select(r => r.CosKSadj);
            double resultcos2017Q3 = 0;
            foreach (var revcos in cos2017Q3)
            {
                resultcos2017Q3 += revcos;
            }

            //Q4
            var cos2017Q4 = revenueActuals.Where(r => r.Quarter == "2017Q4").Select(r => r.CosKSadj);
            double resultcos2017Q4 = 0;
            foreach (var revcos in cos2017Q4)
            {
                resultcos2017Q4 += revcos;
            }

            CustomerFinancialsViewModel model = new CustomerFinancialsViewModel()
            {
                rev2017Q1 = Math.Round(result2017Q1, 2),
                rev2017Q2 = Math.Round(result2017Q2, 2),
                rev2017Q3 = Math.Round(result2017Q3, 2),
                rev2017Q4 = Math.Round(result2017Q4, 2),

                GPM2017Q1percent = Math.Round((result2017Q1 - resultcos2017Q1) / result2017Q1 * 100, 2),
                GPM2017Q2percent = Math.Round((result2017Q2 - resultcos2017Q2) / result2017Q2 * 100, 2),
                GPM2017Q3percent = Math.Round((result2017Q3 - resultcos2017Q3) / result2017Q3 * 100, 2),
                GPM2017Q4percent = Math.Round((result2017Q4 - resultcos2017Q4) / result2017Q4 * 100, 2),

                GPM2017Q1 = Math.Round(result2017Q1 * ((result2017Q1 - resultcos2017Q1) / result2017Q1), 2),
                GPM2017Q2 = Math.Round(result2017Q2 * ((result2017Q2 - resultcos2017Q2) / result2017Q2), 2),
                GPM2017Q3 = Math.Round(result2017Q3 * ((result2017Q3 - resultcos2017Q3) / result2017Q3), 2),
                GPM2017Q4 = Math.Round(result2017Q4 * ((result2017Q4 - resultcos2017Q4) / result2017Q4), 2),
            };

            return View(model);
        }
    }
}
