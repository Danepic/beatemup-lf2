
using System.Collections.Generic;
using Domains;
using Enums;
using UnityEngine;

namespace Helpers {
    [System.Serializable]
    public class StatsHelper {
        public int aggressive;

        public int technique;

        public int intelligent;

        public int speed;

        public int resistance;

        public int stamina;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}