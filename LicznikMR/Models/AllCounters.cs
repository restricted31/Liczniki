
using System.Collections.ObjectModel;

namespace LicznikMR.Models
{
    class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new();
        public AllCounters() => LoadCounters();
        public void LoadCounters()
        {
            Counters.Clear();
            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Counter> counters = Directory
                .EnumerateFiles(appDataPath, "*.counter.txt")
                .Select(filename => new Counter()
                {
                    Filename = filename,
                    Name = File.ReadAllLines(filename)[0],
                    Value = int.Parse(File.ReadAllLines(filename)[1]),
                    Date = File.GetCreationTime(filename)
                }).OrderBy(counter => counter.Date);

            foreach(Counter counter in counters)
            {
                Counters.Add(counter);
            }


        }

    }
}
