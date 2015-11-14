using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace VoxUniversal.BLL
{
    public class SoundManipulation
    {
        private MediaCaptureInitializationSettings _settings;
        private MediaCapture _capturer;
        private MediaEncodingProfile _profile;
        

        public SoundManipulation()
        {
            Initialize();
            
        }

        private void Initialize()
        {
            _settings = new MediaCaptureInitializationSettings();
            _settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            _capturer = new MediaCapture();
            _profile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.High);           
        }

        public void Record()
        {
            Task task = Task.Run(async () => {
                await _capturer.InitializeAsync(_settings);
                StorageFile file = await KnownFolders.MusicLibrary.CreateFileAsync("captured.wav", CreationCollisionOption.ReplaceExisting);
                await _capturer.StartRecordToStorageFileAsync(_profile, file);                
            });
        }
        public void Play()
        {
            Task task = Task.Run(async () => {
                StorageFolder location = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder folder = await location.GetFolderAsync("CountDown");
                StorageFolder subfolder = await folder.GetFolderAsync("Assets");
                StorageFile file = await subfolder.GetFileAsync("Ding.wav");
                Uri path = new Uri(file.Path, UriKind.Absolute);
                MediaElement mediaElement = new MediaElement()
                {
                    AutoPlay = false,
                    Source = path,
                };
                mediaElement.Play();
            });            
        }
        public void Stop()
        {
            Task task = Task.Run(async () => {
                await _capturer.StopRecordAsync();
            });
            task.Wait();
        }
        public void Save()
        {
            //TODO
        }
    }
}
