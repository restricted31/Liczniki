namespace LicznikMR.Models
{
    internal class Counter
    {
        public string Filename { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public string PlusButtonText => "+";
        public string MinusButtonText => "-";
    }
}
