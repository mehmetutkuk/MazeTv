﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MazteTv.Service.Models
{
    public class GetCastResponse
    {
        public Person person { get; set; }
        public Character character { get; set; }
        public int ShowId { get; set; } 
        public bool self { get; set; }
        public bool voice { get; set; }
    }

    public class Person
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public string gender { get; set; }
        public Image image { get; set; }
        public int updated { get; set; }
        public _Links _links { get; set; }
    }


    public class Character
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Image1 image { get; set; }
        public _Links1 _links { get; set; }
    }

    public class Image1
    {
        public string medium { get; set; }
        public string original { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }
}
