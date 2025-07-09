namespace DemoMVC.Controllers 
{
    public class studentController{ApplicationDbContext context, AutoGenerateCode} : Controller
    {
        private readonly ApplicationDbContext _context;
        public class StudentController(ApplicationDbContext context, AutoGenerateCode AutoGenerateCode) : Controller
        {
            private readonly ApplicationDbContext _context = context;
            private readonly AutoGenerateCode _AutoGenerateCode = AutoGenerateCode;
            //GET; student
            public async Task<IActionResult> Index()
            {
                 return View(await_context.Students.ToListAsync);
                
            }
            //GET: student/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.Students == null)
                {
                    return NotFound();
                }

                var student = await _context.Students
                    .FirstOrDefaultAsync(m => m.StudentID == id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }
            //GET: student/Create
            public IActionResult Create()
            {
                // Generate a new ID for the student
                var lastStudent = _context.Students.OrderByDescending(s => s.StudentID).FirstOrDefault();
                var StudnetId = lastStudent ?.StudentID ??"STU0000";
                var newStudentId = _AutoGenerateCode.GenerateCode(StudnetId);
                ViewBag.StudentID = newStudentId;
                return View();
            }

        }
    }
}