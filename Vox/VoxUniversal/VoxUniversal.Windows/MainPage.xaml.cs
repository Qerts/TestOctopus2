using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VoxUniversal.BLL;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VoxUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SoundManipulation _manipulator;
        public MainPage()
        {
            this.InitializeComponent();                       
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _manipulator = new SoundManipulation();
        }

        private void button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "buttonRecordNew":
                    _manipulator.Record();
                    buttonPlay.IsEnabled = false;
                    buttonSave.IsEnabled = false;
                    buttonRecordNew.IsEnabled = true;
                    buttonStop.IsEnabled = true;
                    break;
                case "buttonPlay":
                    _manipulator.Play();
                    buttonPlay.IsEnabled = true;
                    buttonSave.IsEnabled = true;
                    buttonRecordNew.IsEnabled = true;
                    buttonStop.IsEnabled = true;
                    break;
                case "buttonStop":
                    _manipulator.Stop();
                    buttonPlay.IsEnabled = true;
                    buttonSave.IsEnabled = true;
                    buttonRecordNew.IsEnabled = true;
                    buttonStop.IsEnabled = true;
                    break;
                case "buttonSave":
                    _manipulator.Save();
                    buttonPlay.IsEnabled = true;
                    buttonSave.IsEnabled = true;
                    buttonRecordNew.IsEnabled = true;
                    buttonStop.IsEnabled = true;
                    break;
                default:
                    throw new NotImplementedException("Invalid name of button.");
            }
        }
    }
}
