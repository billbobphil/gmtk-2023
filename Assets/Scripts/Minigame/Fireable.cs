using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Minigame
{
    public class Fireable : InteractionController
    {
        public float speed = 5f;
        public Rigidbody2D rigidbody2d;
        public List<MonoBehaviour> disableList = new List<MonoBehaviour>();
        private void Update()
        {
            if (checkKeys())
            {
                Fire();
            }
        }
        protected void Fire()
        {
            DisableObjects();
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            Vector2 pos = new Vector2(mousePos.x, mousePos.y);
            rigidbody2d.velocity = speed * 0.01f * pos;
        }
        protected void DisableObjects()
        {
            foreach (MonoBehaviour toDisable in disableList)
            {
                toDisable.enabled = false;
            }
        }
    }
}
