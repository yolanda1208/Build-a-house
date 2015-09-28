﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice02___Build_a_house
{
    internal class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;

        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }

        private Location doorLocation;

        public Location DoorLocation
        {
            get
            {
                return doorLocation;
            }

            set
            {
                doorLocation = value;
            }
        }
    }
}