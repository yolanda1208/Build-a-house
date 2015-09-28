using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice02___Build_a_house
{
    public partial class Form1 : Form
    {
        private Location currentLocation;
        private RoomWithDoor 客廳;
        private Room 餐廳;
        private RoomWithDoor 廚房;
        private OutsideWithDoor 前院;
        private OutsideWithDoor 後院;
        private Outside 花圃;

        public Form1()
        {
            InitializeComponent();
            建立所有區域();
            走去(客廳);
        }

        private void 建立所有區域()
        {
            客廳 = new RoomWithDoor("豪華的客廳", "65吋大電視，豪華大沙發", "可以通往前院的門");
            餐廳 = new Room("溫馨的餐廳", "大餐桌，烤箱，大冰箱");
            廚房 = new RoomWithDoor("實用的廚房", "爐子，微波爐，洗碗機", "可以通往後院的門");
            前院 = new OutsideWithDoor("前院", true, "可以回客廳的門");
            後院 = new OutsideWithDoor("後院", true, "可以回廚房的門");
            花圃 = new Outside("美麗的花園", true);

            客廳.Exits = new Location[] { 前院, 餐廳 };
            客廳.DoorLocation = 前院;
            餐廳.Exits = new Location[] { 客廳, 廚房 };
            廚房.Exits = new Location[] { 後院, 餐廳 };
            廚房.DoorLocation = 後院;

            前院.Exits = new Location[] { 客廳, 花圃 };
            前院.DoorLocation = 客廳;

            後院.Exits = new Location[] { 廚房, 花圃 };
            後院.DoorLocation = 廚房;

            花圃.Exits = new Location[] { 前院, 後院 };
        }

        private void 走去(Location 目的地)
        {
            currentLocation = 目的地;
            Exits.Items.Clear();
            foreach (Location location in currentLocation.Exits)
                Exits.Items.Add(location.Name);
            Exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            走去(currentLocation.Exits[Exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor 有對外門的區域 = currentLocation as IHasExteriorDoor;
            走去(有對外門的區域.DoorLocation);
        }
    }
}