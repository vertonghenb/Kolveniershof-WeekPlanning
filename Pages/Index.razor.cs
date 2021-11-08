using FluentDateTime;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolveniershof.Pages
{
	public partial class Index
	{
		private readonly List<DateTime> weekDays = new();
		private DateTime selectedDay = DateTime.Now;

		protected override void OnInitialized()
		{
			PopulateDays();
		}

		/// <summary>
		/// Function to load the day details
		/// </summary>
		/// <param name="day"></param>
		/// <returns></returns>
		private async Task OnDaySelectedHandler(DateTime day)
		{
			await Task.Delay(100);
			selectedDay = day;
			Console.WriteLine($"Get Day : {day.ToShortDateString()} details here and rerender");
		}

		private async Task SelectDateFromPicker(ChangeEventArgs args)
		{
			await Task.Delay(100);
			selectedDay = DateTime.Parse(args.Value.ToString());
			PopulateDays();
			Console.WriteLine($"Get Day : {selectedDay.ToShortDateString()} details here and rerender");
		}

		/// <summary>
		/// Populates all the weekdays for a given date, starts on monday.
		/// </summary>
		private void PopulateDays()
		{
			if (weekDays.Contains(selectedDay))
				return;

			weekDays.Clear();
			var monday = selectedDay.FirstDayOfWeek();
			var friday = monday.AddDays(4);

			for (var dt = monday; dt <= friday; dt = dt.AddDays(1))
			{
				weekDays.Add(dt);
			}
		}
	}
}
