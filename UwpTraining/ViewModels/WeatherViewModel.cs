using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpTraining.Commands;
using UwpTraining.Service;
using UwpTraining.Service.Contracts;
using UwpTraining.Service.Model;
using UwpTraining.ViewModels.Base;
using Windows.UI.Xaml.Input;

namespace UwpTraining.ViewModels
{
    public class WeatherViewModel : BindableBase
    {
        private RelayCommand refreshCommand;
        private IWeatherService service = new WeatherService();

        public WeatherViewModel()
        {
            this.refreshCommand = new RelayCommand(
                async () => { await this.Refresh(); },
                () => this.CanRefresh);
        }

        private WeatherInfoModel weather;

        public WeatherInfoModel WeatherInfo
        {
            get { return weather; }
            set 
            { 
                this.SetProperty(ref this.weather, value);
                this.OnPropertyChanged(nameof(IsReady));
            }
        }

        public ICommand RefreshCommand => this.refreshCommand;

        private string city;

        public string City
        {
            get { return city; }
            set 
            {
                this.SetProperty(ref this.city, value);
                this.refreshCommand.RaiseCanExecuteChanged();
            }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return this.isBusy; }
            set
            { 
                this.SetProperty(ref this.isBusy, value);
                this.OnPropertyChanged(nameof(IsReady));
            }
        }

        private bool isReady;

        public bool IsReady => !this.IsBusy && this.WeatherInfo != null;

        private bool CanRefresh =>  !string.IsNullOrEmpty(this.city);

        private async Task Refresh()
        {
            this.IsBusy = true;

            try
            {
                var result = await this.service.GetWeatherAsync(this.city);
                this.WeatherInfo = result;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
