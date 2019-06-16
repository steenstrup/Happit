using System.Collections.Generic;

namespace Happit.Shared
{
    public enum Icon { Done, NotDone, Not};

    public class Habit
    {
        public Habit() { }
        public int id { get; set; }
        public string Name { get; set; }
        public string Done { get; set; } = "oi oi-arrow-circle-bottom";
        public string NotDone { get; set; } = "oi oi-arrow-circle-right";
        public string Not { get; set; } = "oi oi-arrow-circle-top";
        public List<string> PerWeek { get; set; }
}
}