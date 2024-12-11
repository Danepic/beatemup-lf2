using System;
using Enums;
using UnityEngine;

namespace Domains
{
    [System.Serializable]
    public class BdyEntity
    {
        public bool defaultBdy = false;
        public BdyKindEnum kind;
        public float x;
        public float y;
        public float z;
        public float h;
        public float w;
        public float zwidth;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}