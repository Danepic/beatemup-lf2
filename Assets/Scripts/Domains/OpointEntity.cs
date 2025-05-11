using System;
using UnityEngine;

namespace Domains
{
    [System.Serializable]
    public class OpointEntity
    {
        public float x;
        public float y;
        public float z;
        public int? action;
        public string startFrame;
        public int oid;
        public bool facingFront = true;
        public int poolQuantity;
        public int quantity;
        public bool useSamePalette;
        public bool cancellable = false;
        public bool attachToOwner = false;
        public bool useParentOwner = false;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}