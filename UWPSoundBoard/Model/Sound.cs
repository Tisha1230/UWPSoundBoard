using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundBoard.Model
{
    public enum SoundCategory
    {
        Animals,
        Cartoons,
        Taunts,
        Warnings
    }
    public class Sound //Class
    {
        //properties
        public string Name { get; set; }
        public SoundCategory Category { get; set; }

        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        //constructor
        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            //AudioFile = "/Assets/Audio/" + category + "/" + name + ".wav"; String concatenating
            AudioFile = $"/Assets/Audio/{category}/{name}.wav"; //inline formatting
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
    }
}
