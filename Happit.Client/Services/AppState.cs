using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Happit.Shared;

namespace Happit.Client.Services
{
    public class AppState
    {

        private readonly List<Habit> habits = new List<Habit>();
        public IReadOnlyList<Habit> Habits => habits;

        private Habit habit = new Habit() { id = 0};
        public Habit Habit => habit;


        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;

        // Receive 'http' instance from DI
        private readonly HttpClient http;

        public AppState(HttpClient httpInstance)//, LocalStorage localStorageInstance)
        {
            http = httpInstance;
            
            Task.Run(async () => { await LoadDemoAsync(); });

            
            NotifyStateChanged();
        }

        protected async Task LoadDemoAsync()
        {
            try
            {
                var tmp = await http.GetJsonAsync<List<Habit>>("api/SampleData/GetHabits");
                //characthers.Add(new Characther() { Name = "LoadDemoAsync 2" });
                habits.AddRange(tmp);
                habit = habits.First();
                NotifyStateChanged();
            }
            catch(Exception e)
            {
                habits.Add(new Habit() { Name = e.Message });
                habit = habits.First();
                NotifyStateChanged();
            }
        }

        public void NewHabit()
        {
            var perWeek = new List<Icon>() { Icon.NotDone, Icon.Not, Icon.NotDone, Icon.Done };
            var iconMap = new Dictionary<Icon, string>
            {
                [Icon.Done] = "oi oi-arrow-circle-bottom",
                [Icon.NotDone] = "oi oi-arrow-circle-right",
                [Icon.Not] = "oi oi-arrow-circle-top"
            };

            var h = new Habit() {
                id = Habits.Count,
                Name = "Habit " + Habits.Count,
                PerWeek = new List<string>()
            };
            habits.Add(h);
            habit = h;
            NotifyStateChanged();
        }

        public void SetActiveHabit(Habit habit)
        {
            this.habit = habit;
            NotifyStateChanged();
        }

        public void buttomClick(Habit habit)
        {
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

    }
}
