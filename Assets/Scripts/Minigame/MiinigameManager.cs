using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigame
{
    public class MinigameManager : SceneInteractable
    {
        public List<GameObject> toDestroy = new List<GameObject>();

        private void Update()
        {
            if (CheckObjectsDestroyed())
            {
                RunInteraction();
            }
        }

        private bool CheckObjectsDestroyed()
        {
            foreach (GameObject obj in toDestroy)
            {
                if (obj.activeSelf)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
