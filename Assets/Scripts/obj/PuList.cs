using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "PowerupList", menuName = "PuList", order = 0)]
    public class PuList : ScriptableObject
    {
        public List<PowerUpObj> list;
    }