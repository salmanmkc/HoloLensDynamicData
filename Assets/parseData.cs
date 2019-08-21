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
        public Asset asset { get; set; }
    }

    public class Asset
    {
        public Reading[] readings { get; set; }
    }

    public class Reading
    {
        public Type type { get; set; }
        public Value[] values { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
    }

    public class Value
    {
        public float[] values { get; set; }
    }

    public class Extensions
    {
        public Tracing tracing { get; set; }
    }

    public class Tracing
    {
        public int version { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int duration { get; set; }
        public Execution execution { get; set; }
    }

    public class Execution
    {
        public Resolver[] resolvers { get; set; }
    }

    public class Resolver
    {
        public object[] path { get; set; }
        public string parentType { get; set; }
        public string fieldName { get; set; }
        public string returnType { get; set; }
        public int startOffset { get; set; }
        public int duration { get; set; }
    }


}
