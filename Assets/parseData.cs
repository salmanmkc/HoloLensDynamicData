using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class parseData : MonoBehaviour
{

    public class Rootobject
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }

    public class Data
    {
        public Asset[] assets { get; set; }
    }

    public class Asset
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public Threshold[] thresholds { get; set; }
        public Attribute[] attributes { get; set; }
        public Sensor[] sensors { get; set; }
        public object[] events { get; set; }
        public object[] alerts { get; set; }
        public object[] locations { get; set; }
    }

    public class Threshold
    {
        public long attachTimestamp { get; set; }
        public object detachTimestamp { get; set; }
        public Value value { get; set; }
    }

    public class Value
    {
        public int value { get; set; }
        public string severity { get; set; }
        public string direction { get; set; }
        public string measureType { get; set; }
        public bool alwaysTrigger { get; set; }
        public int version { get; set; }
    }

    public class Attribute
    {
        public string name { get; set; }
        public string value { get; set; }
        public long timestamp { get; set; }
    }

    public class Sensor
    {
        public string uuid { get; set; }
        public Type type { get; set; }
        public string devEui { get; set; }
        public string otaaAppEui { get; set; }
        public string otaaAppKey { get; set; }
        public object lastSeenAt { get; set; }
        public Reading[] readings { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public Readingtype[] readingTypes { get; set; }
    }

    public class Readingtype
    {
        public string name { get; set; }
        public string unit { get; set; }
    }

    public class Reading
    {
        public Type1 type { get; set; }
        public object[] values { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string unit { get; set; }
    }

    public class Extensions
    {
    }

}
