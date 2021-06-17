using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSoundBoard.Model
{
    public static class SoundManager
    {
        //Method
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allSounds = getSounds();
            sounds.Clear();

            /* foreach (var sound in allSounds)  Assigning a collection to another collection
             {
                 sounds.Add(sound);
             }*/

            allSounds.ForEach(sound => sounds.Add(sound)); //lambda expression
        }

        public static void GetSoundsByCategory(ObservableCollection<Sound> sounds, SoundCategory category)
        {
            var allSounds = getSounds();
            
            //foreach (var sound in allSounds)
            //{
            //    if (sound.Category == category)
            //    {
            //        sounds.Add(sound);
            //    }
            //}
            //var filteredSounds = new List<Sounds>();
            var filteredSounds = allSounds.Where(sound => sound.Category == category).ToList();
            sounds.Clear();
            filteredSounds.ForEach(sound => sounds.Add(sound));
        }

        private static List<Sound> getSounds()
        {
            var sounds = new List<Sound>();

            /*var s1 = new Sound("Cat", SoundCategory.Animals);
            sounds.Add(s1);*/

            sounds.Add(new Sound("Cat", SoundCategory.Animals));
            sounds.Add(new Sound("Cow", SoundCategory.Animals));
            sounds.Add(new Sound("Gun", SoundCategory.Cartoons));
            sounds.Add(new Sound("Spring", SoundCategory.Cartoons));
            sounds.Add(new Sound("Clock", SoundCategory.Taunts));
            sounds.Add(new Sound("LOL", SoundCategory.Taunts));
            sounds.Add(new Sound("Ship", SoundCategory.Warnings));
            sounds.Add(new Sound("Siren", SoundCategory.Warnings));

            return sounds;
        }
    }
}
