using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class FireCard : Card
    {
        private void Awake()
        {
            Init("Flame Burst", 4, ElementType.Fire, "basic fire Card");
        }
    }
}