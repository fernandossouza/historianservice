using System;
namespace historianservice.Model
{
    public class Historian
    {
        public int id{get;set;}
        public int thingId{get;set;}
        public string tag{get;set;}
        public string value{get;set;}
        public DateTime date{get;set;}
    }
}