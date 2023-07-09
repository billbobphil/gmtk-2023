using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame
{
    public class Growable : Triggerable, IResetable, IDamage
    {
        public Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
        private int currentDamage = 0;
        [SerializeField] private int damageBonus = 1; 

        protected override void Trigger()
        {
            transform.localScale += scaleChange;
            currentDamage += damageBonus;
        }

        public void ResetObject()
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            currentDamage = 0;
        }

        public int GetDamage()
        {
            return currentDamage;
        }
    }
}
