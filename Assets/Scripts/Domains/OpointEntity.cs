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
        public int oid;
        public bool facingFront = true;
        public int poolQuantity;
        public int quantity;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}