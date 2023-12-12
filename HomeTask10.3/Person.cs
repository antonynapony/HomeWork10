namespace HomeTask10._3
{
    public class Person
    {
        public string name { get; set; }
        public string birthday { get; set; }
        public double height {  get; set; }
        public double weight { get; set; }
        public bool car { get; set; }
        public List<string> languages { get; set; }

        public Person()
        {
            languages = new List<string>();
        }

        public string ToString()
        {
            return $"Person: {name}, \n{birthday}, \n{height}, \n{weight}, \n{car}";
        }
    }
}