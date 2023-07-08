using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame
{
    public class Growable : Triggerable, IResetable
    {
        public Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void Trigger()
        {
            transform.localScale += scaleChange;
        }

        public void ResetObject()
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
