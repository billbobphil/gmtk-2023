using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interactions
{
    public class SceneInteractable : Interactable
    {
        public string sceneName;

        protected override void RunInteraction()
        {
            Debug.Log("Play animation here!");
            SceneManager.LoadScene(sceneName);
        }

        public override void MarkAsCurrentInteractable()
        {
        }

        public override void UnMarkAsCurrentInteractable()
        {
        }
    }
}

