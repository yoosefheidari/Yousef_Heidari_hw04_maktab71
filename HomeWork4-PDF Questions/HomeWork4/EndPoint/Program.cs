//**************************************** PART 1 ****************
List<string> input = new List<string>();
Console.WriteLine("Part 1");
Console.WriteLine("Enter Your Card_Number :");
int card = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Your Name :");
var name = Console.ReadLine();
Console.WriteLine("Enter Your Family :");
var family = Console.ReadLine();
Console.WriteLine("Enter Your Height :");
int height = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Your Mobile :");
var mobile = Console.ReadLine();
Console.WriteLine("Enter Your Father Name :");
var father = Console.ReadLine();
Console.WriteLine("Enter Your Weight :");
int weight = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Your Birthday :");
Console.WriteLine("Enter Year");
int year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Month");
int month = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Day");
int day = Convert.ToInt32(Console.ReadLine());
DateTime birthday = new DateTime(year, month, day);
Console.WriteLine("Enter Your Address :");
var address = Console.ReadLine();
Person person=new Person(card,name,family,height,mobile,father,weight,birthday,address);

File.WriteAllText(@"d:\File.txt", Newtonsoft.Json.JsonConvert.SerializeObject(person));

var readfile = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(File.ReadAllText(@"d:\File.txt"));
Console.WriteLine($"Name : {readfile.Name} Family : {readfile.Family} Card_Number : {readfile.CardNo}");
Console.WriteLine("Press Any Key To Go For Next Part");
Console.ReadKey();
File.WriteAllText(@"d:\File.txt", "");
//************************ PART 2 *******************
ISendMessage _smsSend = new SMSSending();
ISendMessage _emailSend=new EmailSending();
Console.WriteLine("Part 2 (Bonus)");
Console.WriteLine("How Do You Want Send Your Message ?");
Console.WriteLine("A - Send As SMS");
Console.WriteLine("B - Send As Email");
var inputkey = Console.ReadKey();
Console.WriteLine();
switch (inputkey.Key)
{
    case ConsoleKey.A:
        _smsSend.Sent();
        break;
    case ConsoleKey.B:
        _emailSend.Sent();
        break;
}
Console.WriteLine("Press Any Key To Close");
Console.ReadKey();