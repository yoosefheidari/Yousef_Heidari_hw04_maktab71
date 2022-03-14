//**************************************** PART 1 ****************
List<string> input = new List<string>();
Console.WriteLine("Part 1");
Console.WriteLine("Enter Your Card_Number :");
var card = Console.ReadLine();
input.Add(card);
Console.WriteLine("Enter Your Name :");
var name = Console.ReadLine();
input.Add(name);
Console.WriteLine("Enter Your Family :");
var family = Console.ReadLine();
input.Add(family);
Console.WriteLine("Enter Your Height :");
var height = Console.ReadLine();
input.Add(height);
Console.WriteLine("Enter Your Mobile :");
var mobile = Console.ReadLine();
input.Add(mobile);
Console.WriteLine("Enter Your Father Name :");
var father = Console.ReadLine();
input.Add(father);
Console.WriteLine("Enter Your Weight :");
var weight = Console.ReadLine();
input.Add(weight);
Console.WriteLine("Enter Your Birthday :");
var birthday = Console.ReadLine();
input.Add(birthday);
Console.WriteLine("Enter Your Address :");
var address = Console.ReadLine();
input.Add(address);
File.WriteAllText(@"d:\File.txt", "");
File.AppendAllLines(@"d:\File.txt", input);
var readfile = File.ReadAllLines(@"d:\File.txt");
Console.WriteLine($"Name : {readfile[1]} Family : {readfile[2]} Card_Number : {readfile[0]}");
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