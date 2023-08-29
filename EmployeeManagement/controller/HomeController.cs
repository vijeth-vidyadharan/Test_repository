


using EmployeeManagement.model;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;


namespace EmployeeManagement.controller
{
    //[Route("[controller]/[action]")]  //common routing for all the members  // attribute routing method
    
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public HomeController(IEmployeeRepository employeeRepository , Microsoft.AspNetCore.Hosting.IHostingEnvironment host)
        {
            _employeeRepository = employeeRepository;
            _environment = host;
        }



        [Route("Home/details/{id?}")]

        public ViewResult details (int ? id)
        {
           Employee employee = _employeeRepository.GetEmployee(id ??1);
            //----------------------------------------------------
            //ViewData["employee"]=employee;    // using view data
            //ViewData["header"] = "Employee details";
            //return  View (ViewData);
            //----------------------------------------------------
            //ViewBag.Titlename = "Employee details";    //using vie bag 
            //ViewBag.Employee = employee;
            //----------------------------------------------------
            //ViewBag.Titlename = "Employee details";   //using vie bag and model
            //return View(employee);
            //----------------------------------------------------
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel() { employee = employee , Title="Tile from view model"};
            return View(viewModel);

        }

        //[Route("")]
        //[Route("Index")]
        [Route("~/")]  // to set it as default
        public ViewResult Index()
        {
            //  return _employeeRepository.GetEmployee(1).Name; 
            IEnumerable < Employee > employeeList = _employeeRepository.GetAllEmployee();
            return View(employeeList);
           
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpGet]
        public ViewResult Edit (int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EditViewModel editView = new EditViewModel
            {   Department = employee.Department,
                Email = employee.Email,
                Name = employee.Name,
                ExistingPhotoPath=employee.PhotoLocation
            };

            return View(editView);
                                                       
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(editViewModel.Id);

                employee.Name = editViewModel.Name;
                employee.Email=editViewModel.Email;
                employee.Department=editViewModel.Department;

                if (editViewModel.PhotoLocation != null)
                {
                    string filePath = Path.Combine(_environment.WebRootPath, "IMG");
                    string fileName = Guid.NewGuid().ToString() + "_" + editViewModel.PhotoLocation.FileName;
                    string imagePath = Path.Combine(filePath, fileName);

                    employee.PhotoLocation = fileName;

                    editViewModel.PhotoLocation.CopyTo(new FileStream(imagePath, FileMode.Create));

                }
                Employee newId = _employeeRepository.Update(employee);

                return RedirectToAction("details", new { id = newId.Id });




            }
            
            return View(editViewModel);
        }


        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel employee )
        {
            if (ModelState.IsValid)
            {
                if (employee.PhotoLocation != null)
                {
                   string filePath=Path.Combine(_environment.WebRootPath,"IMG");
                    string fileName = Guid.NewGuid().ToString() + "_" + employee.PhotoLocation.FileName;
                    string imagePath = Path.Combine(filePath, fileName);

                    

                    employee.PhotoLocation.CopyTo(new FileStream(imagePath, FileMode.Create));


                    Employee employee1 = new Employee
                    {
                        Department = employee.Department,
                        Email = employee.Email,
                        Name = employee.Name,
                        PhotoLocation = fileName
                    };

                    Employee newId = _employeeRepository.Add(employee1);
                    return RedirectToAction("details", new { id = newId.Id });
                }
                return View();
            }

            else
            {
                return View();
            }
        }
    }
}
