using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Minigame
{
    public class Target : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wave"))
            {
                Fireable wave = other.GetComponent<Fireable>();
                wave.ResetObject();
                gameObject.SetActive(false);
            }
        }
    }
}
