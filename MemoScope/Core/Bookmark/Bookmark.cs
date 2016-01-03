﻿using BrightIdeasSoftware;
using MemoScope.Core.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MemoScope.Core.Bookmark
{
    public class Bookmark : IAddressData
    {
        [OLVColumn]
        public ulong Address { get; set; }

        [OLVColumn(IsVisible=false)]
        public string TypeName { get; set; }

        [XmlIgnore]
        [OLVColumn(Width=75)] 
        public Color Color { get; set; }

        [OLVColumn(Title = "Color Pick", TextAlign = HorizontalAlignment.Center, Width = 50)]
        [XmlIgnore]
        public string ColorPick => "...";

        public string ColorRGB
        {
            get
            {
                return Color == Color.Empty ? "" : Color.R + "," + Color.G + "," + Color.B;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Color = Color.Empty;
                }
                else
                {
                    string[] c = value.Split(',');
                    Color = Color.FromArgb(int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2]));
                }
            }
        }

        //XmlSerializer needs a parameter less constructor
        public Bookmark()
        {
        }

        public Bookmark(ulong address, string typeName)
        {
            Address = address;
            TypeName = typeName;
        }
    }
}