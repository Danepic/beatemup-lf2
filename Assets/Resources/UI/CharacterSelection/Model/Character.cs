using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class Character
    {
        public string id;             
        public string name;                   
        public string suffix;        
        public string resourcePath;   
        public string boosterId;   
        public int number;    

        public Character(string id, string name, string suffix, string resourcePath, string boosterId, int number)
        {
            this.id = id;
            this.name = name;
            this.suffix = suffix;
            this.resourcePath = resourcePath;
            this.boosterId = boosterId;
            this.number = number;
        }
    }
}