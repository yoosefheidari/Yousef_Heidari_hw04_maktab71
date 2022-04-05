public class Person
{
    public int CardNo { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int Height { get; set; }
    public string Mobile { get; set; }
    public string Father { get; set; }
    public int Weight { get; set; }
    public DateTime BirthDay { get; set; }
    public string Address { get; set; }
    public Person(int card, string name, string family, int height, string mobile, string father, int weight, DateTime birth, string address)
    {
        CardNo = card;
        Name = name;
        Family = family;
        Height = height;
        Mobile = mobile;
        Father = father;
        Weight = weight;
        BirthDay = birth;
        Address = address;
    }

}