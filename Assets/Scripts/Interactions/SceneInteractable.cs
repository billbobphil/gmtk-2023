using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interactions
{
    public class SceneInteractable : InteractableWithNotice
    {
        public string sceneName;
        public Animator transition;
        public float transitionTime = 1f;
        protected override void RunInteraction()
        {
            StartCoroutine(LevelTransition(sceneName));
        }

        IEnumerator LevelTransition(string sceneName)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(sceneName);

        }
    }
}

