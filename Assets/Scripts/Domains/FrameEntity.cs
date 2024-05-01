using UnityEngine;

namespace Domains
{
    [System.Serializable]
    public class FrameEntity
    {
        public int id;
        public string name;
        public PropertiesEntity properties;
        public BdyEntity bdy;
        public ItrEntity itr;
        public OpointEntity opoint;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}