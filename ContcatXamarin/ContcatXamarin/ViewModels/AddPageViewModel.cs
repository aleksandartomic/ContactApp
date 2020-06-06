using ContcatXamarin.Models;
using ContcatXamarin.Services;
using ContcatXamarin.Views;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContcatXamarin.ViewModels
{
    [QueryProperty("Id", "Id")]
    public class AddPageViewModel : BaseViewModel
    {
        private string id;

        public string Id
        {
            set { SetProperty(ref id, Uri.UnescapeDataString(value)); }
            get { return id; }
        }
        public User User { get; set; }

        //public ICommand CameraCommand { get; set; }
        //public ICommand OpenGalleryCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ICommand OpenCameraOrGalleryCommand { get; set; }

        //public ICommand DeletePhotoCommand { get; set; }

        public AddPageViewModel()
        {
            SaveCommand = new Command(Save);

            //CameraCommand = new Command(Camera);

            //OpenGalleryCommand = new Command(OpenGallery);

            OpenCameraOrGalleryCommand = new Command(OpenCameraOrGallery);

            //DeletePhotoCommand = new Command(DeletePhoto);
        }

        public override async void OnNavigatedTo(object parameters)
        {
            if (id == null)
            {
                User = new User();
            }
            else
            {
                User = await Repository.GetUserAsync(int.Parse(id));
            }
        }
        public void Save()
        {
            Repository.UpdateUserAsync(User);

            NavigateToAddPage();
        }

        public void NavigateToAddPage()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public async void OpenCameraOrGallery()
        {
            if (User.ImageUrl == null)
            {
                var userSelection = await Shell.Current.DisplayActionSheet("Camera Or Gallery", "Cancel", null, "Camera", "Gallery");
                if (userSelection == "Camera")
                {
                    Camera();
                }
                if (userSelection == "Gallery")
                {
                    OpenGallery();
                }
            }

            if (User.ImageUrl != null)
            {
                var userSelectionn = await Shell.Current.DisplayActionSheet("Camera Or Gallery", "Cancel", null, "Camera", "Gallery", "Delete Photo");
                if (userSelectionn == "Camera")
                {
                    Camera();
                }
                if (userSelectionn == "Gallery")
                {
                    OpenGallery();
                }
                if (userSelectionn == "Delete Photo")
                {
                    User.ImageUrl = null;
                }
            }   
        }

        public async void Camera()
        {
            if (PermissionStatus.Granted == await CheckCameraPermissionAsync<Permissions.Camera>())
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Shell.Current.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                using (var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Name = $"{Guid.NewGuid()}.jpg"

                }))
                {
                    if (file != null)
                    {
                        User.ImageUrl = file.Path;
                    }
                }
            }
        }

        public async void OpenGallery()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Shell.Current.DisplayAlert("No Gallery", ":( No gallery available.", "OK");
                return;
            }

            using (var selectedImage = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()))
            {
                if (selectedImage != null)
                {
                    User.ImageUrl = selectedImage.Path;
                }
            } 
        }
    }
}
