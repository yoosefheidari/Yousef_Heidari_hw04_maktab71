IUserRepository _userRepository = new UserRepository();
IStudentRepository _studentRepository = new StudentRepository();
ICourseRepository _courseRepository = new CourseRepository();
var currentuser = _userRepository.GetCurrentUser();
//****************************************************
if (currentuser == null)
    LoginOrRegisterMenu();

void LoginOrRegisterMenu()
{
    Console.Clear();
    Console.WriteLine("------ Wellcome To Etectronic School App--------");
    Console.WriteLine("L - Login");
    Console.WriteLine("R - Register");
    var inputKey = Console.ReadKey();
    if (inputKey.Key == ConsoleKey.L)
        Login();
    else if (inputKey.Key == ConsoleKey.R)
        Register();
    else
    {
        Console.WriteLine("You Press Invalid Key , Please Try Again.");
        Console.WriteLine("Please Enter Any Key To Continue .");
        Console.ReadKey();
        LoginOrRegisterMenu();
    }
}
void Login()
{
    Console.Clear();
    Console.WriteLine("------- Login -------------");
    Console.Write("Please Enter Your Email : ");
    var email = Console.ReadLine();
    if(email == null || email =="")
    {
        Console.WriteLine("Incorrect Email . Please Try Again .");
        Console.WriteLine("Please Enter Any Key To Continue.");
        Console.ReadKey();
        Login();
    }
    else
    {
        Console.WriteLine();
        Console.Write("Please Enter Your Password : ");
        var password = Console.ReadLine();
        if(password == null || password=="")
        {
            Console.WriteLine("Incorrect Password . Please Try Again .");
            Console.WriteLine("Please Enter Any Key To Continue.");
            Console.ReadKey();
            Login();
        }
        else
        {
            Console.WriteLine();
            var result = _userRepository.Login(email, password);
            if (result == "OK")
                MainMenu();
            else
            {
                Console.WriteLine(result);
                Console.WriteLine("Please Enter Any Key To Continue .");
                Console.ReadKey();
                LoginOrRegisterMenu();
            }
        }        
    }    
}
void Register()
{
    Console.Clear();
    Console.WriteLine("--------------- Register -----------");
    Console.Write("Please Enter Your Email : ");
    var email = Console.ReadLine();
    if(email is null || email=="")
    {
        Console.WriteLine("Incorrect Email Entered . Please Try Again.");
        Console.WriteLine("Please Enter Any Key To Continue .");
        Console.ReadKey();
        Register();
    }
    else
    {
        Console.WriteLine();
        Console.Write("Please Enter Your Password : ");
        var password = Console.ReadLine();
        if (password is null || password =="")
        {
            Console.WriteLine("Incorrect Password Entered . Please Try Again.");
            Console.WriteLine("Please Enter Any Key To Continue .");
            Console.ReadKey();
            Register();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"{(int)RoleEnum.Student} - {RoleEnum.Student}");
            Console.WriteLine($"{(int)RoleEnum.Teacher} - {RoleEnum.Teacher}");
            Console.Write("Please Select Your Role : ");
            var roleId = Convert.ToInt32(Console.ReadLine());
            if (roleId != (int)RoleEnum.Student && roleId != (int)RoleEnum.Teacher)
            {
                Console.WriteLine("You Entered Incorrect Role. Please Try Again .");
                Console.WriteLine("Please Enter Any Key To Continue .");
                Console.ReadKey();
                Register();
            }
            var role = (RoleEnum)roleId;
            Console.WriteLine();
            Console.WriteLine($"{(int)GradeEnum.MiddleSchool} - {GradeEnum.MiddleSchool}");
            Console.WriteLine($"{(int)GradeEnum.HighSchool} - {GradeEnum.HighSchool}");
            Console.Write("Please Select Your Grade : ");
            var gradeId = Convert.ToInt32(Console.ReadLine());
            if (gradeId != (int)GradeEnum.MiddleSchool && gradeId != (int)GradeEnum.HighSchool)
            {
                Console.WriteLine("You Entered Incorrect Grade. Please Try Again .");
                Console.WriteLine("Please Enter Any Key To Continue .");
                Console.ReadKey();
                Register();
            }
            var grade = (GradeEnum)gradeId;

            User? newUser = null;

            switch (role)
            {
                case RoleEnum.Teacher:
                    switch (grade)
                    {
                        case GradeEnum.MiddleSchool:
                            newUser = new MiddleSchoolTeacher(email, password);
                            break;
                        case GradeEnum.HighSchool:
                            newUser = new HighSchoolTeacher(email, password);
                            break;
                    }
                    break;
                case RoleEnum.Student:
                    switch (grade)
                    {
                        case GradeEnum.MiddleSchool:
                            newUser = new MiddleSchoolStudent(email, password);
                            break;
                        case GradeEnum.HighSchool:
                            newUser = new HighSchoolStudent(email, password);
                            break;
                    }
                    break;
            }
            if(newUser is null)
            {
                Console.WriteLine("Registration Failed . Please Try Again .");
                Console.WriteLine("Please Enter Any Key To Continue .");
                Console.ReadKey();
                Register();
            }
            else
            {
                Console.WriteLine();
                Console.Write("Please Enter Your Name : ");
                newUser.Name = Console.ReadLine();
                Console.Write("Please Enter Your Mobile : ");
                newUser.Mobile = Console.ReadLine();
                _userRepository.RegisterUser(newUser);
                Console.WriteLine("Registration Is Successfull");
                Console.WriteLine("Please Enter Any Key To Continue .");
                Console.ReadKey();
                LoginOrRegisterMenu();
            }
        }
    }
}
void MainMenu()
{
    var currentUser = _userRepository.GetCurrentUser();
    if (currentUser == null)
        LoginOrRegisterMenu();
    else
    {        
        switch (currentUser.Role)
        {
            case RoleEnum.Admin:
                AdminMenu();
                break;
            case RoleEnum.Teacher:
                var currentTeacher = (Teacher)currentUser;
                TeacherMenu();
                break;
            case RoleEnum.Student:
                var currentStudent = (Student)currentUser;
                StudentMenu();
                break;
            default:
                break;
        }
    }    
}
void AdminMenu()
{
    var currentUser = _userRepository.GetCurrentUser();
    if (currentUser == null)
        LoginOrRegisterMenu();
    else
    {
        Console.Clear();
        Console.WriteLine("----------- Admin Menu ------------");
        Console.WriteLine($"Welcome {currentUser.Name}");
        var currentAdmin = (Admin)currentUser;
        Console.Clear();
        Console.WriteLine("C - Add Course");
        Console.WriteLine("T - Assign Course To Teacher");
        Console.WriteLine("S - Assign Course To Student");
        Console.WriteLine("E - Edit User Information");
        Console.WriteLine("L - List Of Users");
        Console.WriteLine("A - Activate User");
        Console.WriteLine("O - LogOff");
        Console.Write("Please Select Action : ");
        var inputKey = Console.ReadKey();
        Console.WriteLine();
        switch (inputKey.Key)
        {
            case ConsoleKey.L:
                PrintListOfUser();
                break;
            case ConsoleKey.E:
                EditInfo();
                break;
            case ConsoleKey.A:
                ActivateUser();
                break;
            case ConsoleKey.O:
                LogOff();
                break;
            case ConsoleKey.C:
                Course? newCourse = null;
                Console.WriteLine("Enter Name of Course :");
                var courseName = Console.ReadLine();               
                Console.WriteLine("Enter Grade of Course :");
                Console.WriteLine("A - MiddleSchool");
                Console.WriteLine("B - HighSchool");
                var gradeCourse= Console.ReadKey();
                Console.WriteLine();
                int unitNumbers = 0;
                if(gradeCourse.Key == ConsoleKey.B)
                {
                    Console.WriteLine("Enter Number Of Units");
                    unitNumbers=Convert.ToInt32(Console.ReadLine());
                }
                switch (gradeCourse.Key)
                {
                    case ConsoleKey.A:
                        newCourse=new MiddleSchoolCourse(courseName,GradeEnum.MiddleSchool);
                        break;
                    case ConsoleKey.B:
                        newCourse = new HighSchoolCourse(courseName, GradeEnum.HighSchool, unitNumbers);
                        break;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                }
                _courseRepository.AddCourse(newCourse);
                break;
            case ConsoleKey.T:
                var users =_userRepository.GetUsers();
                var courses=_courseRepository.GetCourses();
                if(users.Count ==0 || courses.Count == 0)
                {
                    Console.WriteLine("Cannot Assign Course PLease Add Course Or Teacher");
                }
                else
                {
                    foreach(var course in courses)
                    {
                        Console.WriteLine($"Which Teacher Should Teach {course.Name}({course.Grade}) ?");
                        foreach(var user in users)
                        {
                            if(user.Role == RoleEnum.Teacher)
                            {
                                Teacher tempT = (Teacher)user;
                                Console.WriteLine($"{tempT.Name} ({tempT.Grade})");
                            }                            
                        }
                        Console.WriteLine("Enter Name Of Teacher From List Above");
                        var teach = Console.ReadLine();
                        foreach(var user in users)
                        {
                            if (user.Name == teach)
                            {                              
                                var newTeacher= (Teacher)user;
                                course._Teacher = newTeacher;
                                newTeacher.Courses.Add(course);
                            }                                                           
                        }                        
                    }
                }                             
                break;
            case ConsoleKey.S:
                var studentss=_userRepository.GetUsers().FindAll(p=>p.Role == RoleEnum.Student);
                var allCourses = _courseRepository.GetCourses();
                foreach(var st in studentss)
                {
                    foreach(var courseItem in allCourses)
                    {
                        Console.WriteLine($"Do You Want Give {courseItem.Name} To {st.Name} ? Y/N");
                        var inputkey=Console.ReadKey();
                        Console.WriteLine();
                        if (inputkey.Key == ConsoleKey.Y)
                        {
                            StudentCouse newC = new StudentCouse(courseItem);
                            Student newS = (Student)st;
                            newS.Courses.Add(newC);
                        }
                    }
                    Console.WriteLine("Press Any Key For Next Student");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                break;
            default:
                break;
        }
    }
    AdminMenu();
}
void TeacherMenu()
{   
    currentuser = _userRepository.GetCurrentUser();
    Teacher currentTeacher = (Teacher)currentuser;
    if (currentuser == null)
        LoginOrRegisterMenu();
    else
    {        
        Console.Clear();
        Console.WriteLine("----------- Teacher Menu ------------");
        Console.WriteLine($"Welcome {currentTeacher.Name}");        
        //Console.Clear();
        Console.WriteLine("A - Get List Of Your Students");
        Console.WriteLine("B - Get List Of Your Courses");
        Console.WriteLine("C - Give Score To Your Students");
        Console.WriteLine("S - Calculate Your Salary");
        Console.WriteLine("D - Log Off");
        var inputKey=Console.ReadKey();
        Console.WriteLine();
        switch (inputKey.Key)
        {
            case ConsoleKey.A:
                Console.WriteLine("Which Course Do You Want To See");
                foreach(var item in currentTeacher.Courses)
                {
                    Console.WriteLine(item.Name);
                }
                string? course = Console.ReadLine();
                PrintListOfStudents(course);
                break;
            case ConsoleKey.B:
                foreach(var item in currentTeacher.Courses)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press Any Key To Countinue");
                Console.ReadKey();
                break;
            case ConsoleKey.C:
                var users = _userRepository.GetUsers();
                foreach (var item in currentTeacher.Courses)
                {
                    foreach(var user in users)
                    {
                        if(user.Role == RoleEnum.Student)
                        {
                            var student=(Student)user;
                            var studentCourse = student.Courses;
                            foreach(var courseitem in studentCourse)
                            {
                                if(courseitem._Course.Name == item.Name)
                                {
                                    Console.WriteLine($"Please Give Score To {student.Name} for {courseitem._Course.Name}");
                                    Console.WriteLine("Enter Score :");
                                    var score = Convert.ToInt32(Console.ReadLine());
                                    courseitem.Score= score;
                                    if(courseitem.Score == score)
                                    {
                                        Console.WriteLine("Task Done");
                                    }
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
                break;
            case ConsoleKey.D:
                LogOff();
                break;
            case ConsoleKey.S:
                if (currentTeacher.Grade == GradeEnum.MiddleSchool)
                {
                    MiddleSchoolTeacher newTeacher = (MiddleSchoolTeacher)currentTeacher;
                    Console.WriteLine($"Dear {newTeacher.Name} Your Salary is :");
                    Console.WriteLine(newTeacher.CalculateSalary());
                }
                else
                {
                    HighSchoolTeacher newTeacher = (HighSchoolTeacher)currentTeacher;
                    Console.WriteLine($"Dear {newTeacher.Name} Your Salary is :");
                    Console.WriteLine(newTeacher.CalculateSalary());
                }
                Console.WriteLine("Press Any Key To Countinue");
                Console.ReadKey();
                break;
            default:                
                break;
        }
    }
    TeacherMenu();
}
void StudentMenu()
{
    currentuser = _userRepository.GetCurrentUser();
    Student currentStudent = (Student)currentuser;
    if (currentuser == null)
        LoginOrRegisterMenu();
    else
    {
        Console.Clear();
        Console.WriteLine("----------- Student Menu ------------");
        Console.WriteLine($"Welcome {currentStudent.Name}");
        //Console.Clear();
        Console.WriteLine("A - Get List Of Your Courses");
        Console.WriteLine("B - See Your Resume");
        Console.WriteLine("C - Log Off");
        var inputkey = Console.ReadKey();
        Console.WriteLine();
        switch (inputkey.Key)
        {
            case ConsoleKey.A:
                var stCourses = currentStudent.Courses;
                foreach (var item in stCourses)
                {
                    Console.WriteLine(item._Course.Name);
                }
                Console.WriteLine("Press Any Key To Countinue");
                Console.ReadKey();
                break;
            case ConsoleKey.B:
                
                if (currentStudent.Grade == GradeEnum.MiddleSchool)
                {
                    MiddleSchoolStudent newSt=(MiddleSchoolStudent)currentStudent;
                    var coursesList=newSt.Courses;
                    foreach(var item in coursesList)
                    {
                        Console.WriteLine($" Name : {item._Course.Name} --> Score : {item.Score}");
                    }
                    Console.WriteLine("Average Of Your Score Is :");
                    Console.WriteLine(newSt.CalculateAverage());
                    Console.WriteLine("Press Any Key To Countinue");
                    Console.ReadKey();
                }
                else
                {
                    HighSchoolStudent newSt = (HighSchoolStudent)currentStudent;
                    var courseList =newSt.Courses;
                    foreach( var item in courseList)
                    {
                        Console.WriteLine($" Name : {item._Course.Name} --> Score : {item.Score}");
                    }
                    Console.WriteLine("Average Of Your Score Is :");
                    Console.WriteLine(newSt.CalculateAverage());
                    Console.WriteLine("Press Any Key To Countinue");
                    Console.ReadKey();
                }
                break;
            case ConsoleKey.C:
                LogOff();
                break;
        }

    }
    StudentMenu();
}
void LogOff()
{
    _userRepository.LogOff();
    LoginOrRegisterMenu();
}
void PrintListOfUser()
{
    var users = _userRepository.GetUsers();
    Console.Clear();
    Console.WriteLine("------------ List Of Users -------------");
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
    Console.WriteLine("Press Any key To Continue");
    Console.ReadKey();
    AdminMenu();
}
void PrintListOfStudents(string? course)
{
    var users=_userRepository.GetUsers();
    foreach (var user in users)
    {
        if (user.Role == RoleEnum.Student)
        {
            var student = (Student)user;
            var courses = student.Courses;
            foreach (var item in courses)
            {
                if(item._Course.Name.ToLower() == course.ToLower())
                    Console.WriteLine(student.Name);
            }
        }        
    }
    Console.WriteLine("Press Any Key To Countinue");
    Console.ReadKey();
}
void ActivateUser()
{
    Console.Clear();
    Console.WriteLine("--------------- User Activation --------------");
    Console.Write("Please Enter User's Email : ");
    var email = Console.ReadLine();
    if (email == null)
    {
        Console.WriteLine("Invalid Email . Please Try Again .");
        Console.WriteLine("Please Enter Any Key To Continue .");
        Console.ReadKey();
        ActivateUser();
    }
    else
    {
        var user =_userRepository.GetUser(email);
        if (user == null)
        {
            Console.WriteLine("This User Dose Not Exist.");
            Console.WriteLine("Please Enter Any Key To Continue .");
            Console.ReadKey();
            ActivateUser();
        }
        else
        {
            user.Activate();
            Console.WriteLine("Success");
            Console.WriteLine("Please Enter Any Key To Continue .");
            Console.ReadKey();
            AdminMenu();
        }
    }
}
void EditInfo()
{
    var users = _userRepository.GetUsers();
    foreach(var user in users)
    {
        Console.WriteLine($"{user.Name} - {user.Role}");
    }
    Console.WriteLine("Enter Name From Above List");
    var selectedUser=Console.ReadLine();
    User? user1 = null;
    user1=users.FirstOrDefault(x => x.Name.ToLower() == selectedUser.ToLower());
    Console.WriteLine("A - Change Email");
    Console.WriteLine("B - Change Password");
    Console.WriteLine("C - Change Mobile");
    Console.WriteLine("D - Return To Admin Menu");
    var input = Console.ReadKey();
    Console.WriteLine();
    switch (input.Key)
    {
        case ConsoleKey.A:
            Console.WriteLine("Inser New Email :");
            var email = Console.ReadLine();
            user1.ChangeEmail(email);
            break;
        case ConsoleKey.B:
            if (user1.Role == RoleEnum.Teacher)
            {
                Teacher newT = (Teacher)user1;
                Console.WriteLine("Enter New Password (At Least 9 Character)");
                var pass = Console.ReadLine();
                newT.ChangePassword(pass);
                Console.WriteLine("Password Changed Press Any Key To Countinue");
                Console.ReadKey();
                Console.WriteLine();
            }
            if (user1.Role == RoleEnum.Student)
            {
                Student newS=(Student)user1;
                Console.WriteLine("Enter New Password (At Least 7 Character)");
                var pass = Console.ReadLine();
                newS.CheckPassword(pass);
                Console.WriteLine("Password Changed Press Any Key To Countinue");
                Console.ReadKey();
                Console.WriteLine();
            }
            break;
        case ConsoleKey.C:
            Console.WriteLine("Enter New Mobile");
            var mob=Console.ReadLine();
            user1.Mobile=mob;
            break;
        case ConsoleKey.D:
            AdminMenu();
            break;
    }
    EditInfo();
}