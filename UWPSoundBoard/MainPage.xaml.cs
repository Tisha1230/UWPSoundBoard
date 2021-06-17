using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSoundBoard.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSoundBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);


            /* var x = new List<int>();
             * x.Add(1);
             * x.Add(2);
             * x.Add(3);
             * 
             * var x= new List<int> {1,2,3};*/

            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Category = SoundCategory.Animals,
                    IconFile = "Assets/Icons/animals.png"
                },

                new MenuItem
                {
                    Category = SoundCategory.Cartoons,
                    IconFile = "Assets/Icons/cartoon.png"
                },

                new MenuItem
                {
                    Category = SoundCategory.Taunts,
                    IconFile = "Assets/Icons/taunt.png"
                },

                new MenuItem
                {
                    Category = SoundCategory.Warnings,
                    IconFile = "Assets/Icons/warning.png"
                },

            };
            //var m1 = new MenuItem();
            //m1.Category = SoundCategory.Animals;
            //m1.IconFile = "Assets/Icons/animals.png";
            //MenuItems.Add(m1);
              
            //MenuItems.Add(new MenuItem
            //{
            //    Category = SoundCategory.Animals,
            //    IconFile = "Assets/Icons/animals.png"
            //});


        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitview.IsPaneOpen = !MySplitview.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(Sounds);
            CategoryTextBlock.Text = "All Sounds";
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.GetSoundsByCategory(Sounds, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile); //This is relative path

            //MyMediaElement.Source = new Uri(@"C:\Users\tisha\Desktop\Bootcamp\June05\UWPSoundBoard\UWPSoundBoard\bin\x86\Debug\AppX\"+sound.AudioFile); THIS ABSOLUTE PATH

        }
    }
}
