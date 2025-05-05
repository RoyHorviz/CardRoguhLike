using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EarthCard : Card
    {
        private void Awake()
        {
            Init("Rock Slam", 5, ElementType.Earth, "basic Rock Card");
        }
    }
