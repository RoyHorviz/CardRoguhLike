using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.scripts
{
    public class AirCard : Card
    {
        private void Start ()
        {
            Init("Wind Blade", 1, ElementType.Air, "basic Air Card");
        }

    }
}
