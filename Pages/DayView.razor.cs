using Kolveniershof.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Kolveniershof.Pages
{
    public partial class DayView
    {
        [Parameter] public DateTime Day { get; set; }
		[Parameter] public EventCallback<DateTime> OnDaySelected { get; set; }


		public async Task SelectDate()
		{
			await OnDaySelected.InvokeAsync(Day);
		}
	}
}
