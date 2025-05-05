using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class WaterCard : Card
    {
        private void Awake()
        {
            Init("Splash", 3, ElementType.Water, "the basic water card");
        }
    }
}