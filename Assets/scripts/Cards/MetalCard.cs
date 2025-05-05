using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class MetalCard : Card
    {
        private void Awake()
        {
            Init("Steel Crush", 2, ElementType.Metal, "Basic metal Card");
        }
    }
}