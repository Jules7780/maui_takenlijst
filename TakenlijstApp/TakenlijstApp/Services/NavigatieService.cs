using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenlijstApp.Services
{
    public class NavigatieService
    {
        public async Task GoToAsync(string route, IDictionary<string, object>? parameters = null)
        {
            if (parameters is null)
                await Shell.Current.GoToAsync(route);
            else
                await Shell.Current.GoToAsync(route, parameters);
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
