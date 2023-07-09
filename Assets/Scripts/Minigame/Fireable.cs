using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Minigame
{
    public class Fireable : InteractionController, IResetable
    {
        public float speed = 5f;
        public Rigidbody2D rigidbody2d;
        public List<MonoBehaviour> disableList = new List<MonoBehaviour>();
        private Renderer _renderer;
        private Vector2 originalPosition;
        public Growable damage; // wouldve used interface type but unity doesnt like me
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            originalPosition = new Vector2(transform.position.x, transform.position.y);
        }

        private void Update()
        {
            if (checkKeys())
            {
                Fire();
            }
            
            if(!_renderer.isVisible)
            {
                ResetObject();
            }
        }
        protected void Fire()
        {
            ToggleObject(false);
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;
            Vector2 pos = new Vector2(mousePos.x, mousePos.y);
            rigidbody2d.velocity = speed * 0.01f * pos;
        }
        protected void ToggleObject(bool state)
        {
            foreach (MonoBehaviour script in disableList)
            {
                script.enabled = state;
            }
        }

        public void ResetObject()
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
            transform.position = new Vector2(originalPosition.x, originalPosition.y);
            foreach (MonoBehaviour script in disableList)
            {
                if (script is IResetable)
                {
                    IResetable resetable = script as IResetable;
                    resetable.ResetObject();
                }
            }
            ToggleObject(true);
        }
    }
}
