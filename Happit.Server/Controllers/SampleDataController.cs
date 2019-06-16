using Happit.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Happit.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       
        [HttpGet("[action]")]
        public Habit GetHabit(int id)
        {
            var habit = new Habit()
            {
                Name = "Cola",
                id = 0,
            };
            habit.PerWeek.Add(habit.Done);
            habit.PerWeek.Add(habit.Done);
            habit.PerWeek.Add(habit.Done);
            habit.PerWeek.Add(habit.NotDone);
            habit.PerWeek.Add(habit.Not);

            return habit;
        }

        [HttpGet("[action]")]
        public List<Habit> GetHabits()
        {
            var habit1 = new Habit()
            {
                Name = "Cola",
                id = 0,
            };

            habit1.PerWeek = new List<string>()
            {
                habit1.Done,
                habit1.Done,
                habit1.Done,
                habit1.Done,
                habit1.NotDone,
                habit1.Not
            };

            var habit2 = new Habit()
            {
                Name = "Aktiviti",
                id = 1,
            };
            habit2.PerWeek = new List<string>()
            {
                habit2.Done,
                habit2.Done,
                habit2.NotDone,
                habit2.Not
            };
            return new List<Habit>()
            {
                habit1, habit2
            };
        }
    }
}
