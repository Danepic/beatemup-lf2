using Enums;
using UnityEngine;

namespace Domains
{
    [System.Serializable]
    public class ItrEntity
    {
        public ItrKindEnum kind;
        public float x;
        public float y;
        public float z;
        public float w;
        public float h;
        public float zwidth;
        public float dvx;
        public float dvy;
        public float dvz;

        public float rest;
        public bool applyInSingleEnemy;

        public int action;
        public bool defensable;
        public int injury;
        public int nextIfHit;
        public int level;

        public AudioClip sound;
        public ItrEffectEnum effect;

        public float duration;
        public bool defaultItr = false;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}