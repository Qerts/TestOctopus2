using System;
using System.Collections.Generic;
using System.Text;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;

namespace VoxUniversal.DAL
{
    public class VoxSimplex
    {
        private MediaCapture _capture;
        private IRandomAccessStream _stream;

        VoxSimplex()
        {
            
        }
    }

    public enum AudioFormat
    {
        mp3,
        mp4,
        wma
    }

    
}
