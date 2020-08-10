using RealWorldApp.Models;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = RealWorldApp.Models.Image;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ObservableCollection<Image> VehicleImage;
        private int totalImages;
        private string number;
        private string email;
        public ItemDetailPage(int id)
        {
            InitializeComponent();
            VehicleImage = new ObservableCollection<Image>();
            GetVehicleDetails(id);
        }

        private async void GetVehicleDetails(int id)
        {
            var vehicle = await ApiService.GetVehicleDetail(id);
            LblTitle.Text = vehicle.Title;
            LblLocation.Text = vehicle.Location;
            LblCondition.Text = vehicle.Condition;
            LblPrice.Text = vehicle.Price.ToString();
            LblCompany.Text = vehicle.Company;
            LblDescription.Text = vehicle.Description;
            LblColor.Text = vehicle.Color;
            LblModelNo.Text = vehicle.Model;
            LblEngine.Text = vehicle.Engine;

            ImgUser.Source = vehicle.FullImageUrl;

            var images = vehicle.Images;
            totalImages = vehicle.Images.Count;
            number = vehicle.Phone;
            email = vehicle.Email;
            foreach (var image in images)
            {
                VehicleImage.Add(image);
            }
            CrvImages.ItemsSource = VehicleImage;
        }

        private void CrvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= totalImages)
            {
                var count = e.FirstVisibleItemIndex + 1;
                LblCount.Text = count + " of " + totalImages;
            }
        }

        private void BtnEmail_Clicked(object sender, EventArgs e)
        {
            var emailMessage = new EmailMessage("Interest about your vehicle", "I want to know more about this vehicle", email);
            Email.ComposeAsync(emailMessage);
        }

        private void BtnSms_Clicked(object sender, EventArgs e)
        {
            var smsMessage = new SmsMessage("Hi! I want to know more about this vehicle", number);
            Sms.ComposeAsync(smsMessage);
        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}