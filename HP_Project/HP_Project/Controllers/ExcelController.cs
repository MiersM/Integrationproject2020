using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP_Project.DAL.Models;
using HP_Project.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace HP_Project.Controllers
{
    [Authorize]
    public class ExcelController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IApolloRepository _apolloRepository;
        private readonly IRevenueActualsRepository _revenueActualsRepository;
        public ExcelController(IWebHostEnvironment hostingEnvironment, IApolloRepository apolloRepository, IRevenueActualsRepository revenueActualsRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _apolloRepository = apolloRepository;
            _revenueActualsRepository = revenueActualsRepository;
        }

        [HttpGet]
        public IActionResult Index(string message)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            //StringBuilder sb = new StringBuilder();

            if (!Directory.Exists(newPath)) 
            {
                Directory.CreateDirectory(newPath);
            }
            
            if (file.Length > 0) 
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                
                ISheet sheet;
                
                string fullPath = Path.Combine(newPath, file.FileName);
                
                using (var stream = new FileStream(fullPath, FileMode.Create)) 
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    
                    if (sFileExtension == ".xls")  
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else   
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    
                    int cellCount = headerRow.LastCellNum;

                    /* we dont want to add the header rows to the database
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        columns += cell.ToString();
                    }*/
                    /*
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File  
                    {
                        IRow row = sheet.GetRow(i);
                        
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                    }*/
                    
                    //test only 3-4 row
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var x = new ApolloRow() { };
                        IRow row = sheet.GetRow(i);
                        if(row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                //columns += row.GetCell(j).ToString();
                                //if (j == 0)
                                //{
                                //    Name = row.GetCell(j).ToString();
                                //}
                                switch (j)
                                {
                                    case 0:
                                        x.Name = row.GetCell(j).ToString();
                                        break;
                                    case 5:
                                        x.IndustrySegment = row.GetCell(j).ToString();
                                        break;
                                    case 6:
                                        x.IndustryVertical = row.GetCell(j).ToString();
                                        break;
                                    case 14:
                                        x.AccountSTID = Convert.ToInt32(row.GetCell(j).ToString());
                                        break;
                                    case 15:
                                        x.AccountSTName = row.GetCell(j).ToString();
                                        break;
                                    case 16:
                                        try
                                        {
                                            x.TopParentSTID = Convert.ToInt32(row.GetCell(j).ToString());
                                        }
                                        catch(Exception ex)
                                        {
                                            x.TopParentSTID = null;
                                        }
                                        break;
                                    case 17:
                                            x.TopParentSTName = row.GetCell(j).ToString();
                                        break;
                                    case 20:
                                        x.OrganizationID = Convert.ToInt32(row.GetCell(j).ToString());
                                        break;
                                    case 21:
                                        x.OPSIID = Convert.ToInt32(row.GetCell(j).ToString());
                                        break;
                                    case 22:
                                        x.PRMID = row.GetCell(j).ToString();
                                        break;
                                    case 23:
                                        x.BusinessRelationshipID = Convert.ToInt32(row.GetCell(j).ToString());
                                        break;
                                    case 24:
                                        x.TaxIdentifier = row.GetCell(j).ToString();
                                        break;
                                    default:
                                        break;
                                }
                            }    
                        }
                        _apolloRepository.Add(x);
                    } 
                }
            }
            return View("Index", "Successfully uploaded Apollo");
        }
    
        public IActionResult RevenueActuals(string message)
        {
            return View();
        }

        [HttpPost]
        public IActionResult RevenueActuals()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            //StringBuilder sb = new StringBuilder();

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();

                ISheet sheet;

                string fullPath = Path.Combine(newPath, file.FileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;

                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }

                    IRow headerRow = sheet.GetRow(0); //Get Header Row

                    int cellCount = headerRow.LastCellNum;

                    //test only 3-4 row
                    for (int i = 1; i <= 685; i++)
                    {
                        var x = new RevenueActuals() { };
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                //columns += row.GetCell(j).ToString();
                                //if (j == 0)
                                //{
                                //    Name = row.GetCell(j).ToString();
                                //}
                                switch (j)
                                {
                                    case 1:
                                        x.Quarter = row.GetCell(j).ToString();
                                        break;
                                    case 5:
                                        x.BusinessUnitL5 = row.GetCell(j).ToString();
                                        break;
                                    case 10:
                                        x.EndCustomerName = row.GetCell(j).ToString();
                                        break;
                                    case 13:
                                        x.RevKSadj = Convert.ToDouble(row.GetCell(j).ToString());
                                        break;
                                    case 14:
                                        x.CosKSadj = Convert.ToDouble(row.GetCell(j).ToString());
                                        break;
                                    case 15:
                                        x.Units = Convert.ToInt32(row.GetCell(j).ToString());
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        _revenueActualsRepository.Add(x);
                    }
                }
            }
            return View("RevenueActuals", "Successfully uploaded revenue actuals");
        }
    }
}