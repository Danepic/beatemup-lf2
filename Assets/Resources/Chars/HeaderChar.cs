using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;
using UnityEngine;

namespace Chars
{
    [System.Serializable]
    public class HeaderChar
    {
        public string name;
        public int startHp;
        public int startMp;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}