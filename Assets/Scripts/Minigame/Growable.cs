using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame
{
    public class Growable : Triggerable
    {
        public Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void Trigger()
        {
            this.transform.localScale += scaleChange;
        }
    }
}
