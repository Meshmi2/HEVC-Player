using System;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.Media.Playback;
using Windows.Media.Editing;
using Windows.Media.MediaProperties;
// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace HVECPlayer
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadHEVCVideo();
        }
        private async void LoadHEVCVideo()
        {
            // Load and play HEVC video file
            // The video file should be added to the Assets folder of the project
            // Create filePicker object
            Windows.Storage.Pickers.FileOpenPicker filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            filePicker.FileTypeFilter.Add(".mp4");
            filePicker.FileTypeFilter.Add(".hevc");
            // Show filePicker and get the file
            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                // Create a MediaSource object
                MediaSource mediaSource = MediaSource.CreateFromStorageFile(file);
                // Create a MediaPlaybackItem object
                MediaPlaybackItem mediaPlaybackItem = new MediaPlaybackItem(mediaSource);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create a MediaElement object
            MediaElement mediaElement = new MediaElement();
            // Add the MediaElement object to the page
            this.Content = mediaElement;
            // play the filepicker video
            // Create a FileOpenPicker object
            Windows.Storage.Pickers.FileOpenPicker filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            filePicker.FileTypeFilter.Add(".mp4");
            filePicker.FileTypeFilter.Add(".hevc");
            // Show filePicker and get the file
            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            // Create a MediaSource object
            MediaSource mediaSource = MediaSource.CreateFromStorageFile(file);
            // Set the MediaSource object to the MediaElement object
            mediaElement.SetPlaybackSource(mediaSource);
            // Play the video
            mediaElement.Play();
        }
    }
}