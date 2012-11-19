using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARMS_Project
{
    public class Lab
    {
        public int id;
        public String name;

        public Lab()
        {
            id = 0;
            name = "";
        }

        public Lab(int newID, String newName)
        {
            id = newID;
            name = newName;
        }

        public String toString()
        {
            return("Lab ID: " + id + " || Name: " + name);
        }
    }
}