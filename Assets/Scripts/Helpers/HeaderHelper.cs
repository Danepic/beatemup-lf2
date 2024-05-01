using System.Collections.Generic;
using Domains;
using Enums;
using UnityEngine;

namespace Helpers {
    [System.Serializable]
    public class HeaderHelper {
        public string name;

        public int startHp;

        public int startMp;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}