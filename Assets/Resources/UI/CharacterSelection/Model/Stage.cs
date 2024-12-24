using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class Stage
    {
        public string id;             
        public string name;                   
        public string size;     
        public string resourcePath;   
        public string boosterId;   
        public int number;    

        public Stage(string id, string name, string size, string resourcePath, string boosterId, int number)
        {
            this.id = id;
            this.name = name;
            this.size = size;
            this.resourcePath = resourcePath;
            this.boosterId = boosterId;
            this.number = number;
        }
    }
}