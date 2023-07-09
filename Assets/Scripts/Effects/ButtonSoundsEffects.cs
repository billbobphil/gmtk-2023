using UnityEngine;

namespace Effects
{
    public class ButtonSoundsEffects : MonoBehaviour
    {
        [SerializeField] private AudioSource buttonClickAudioSource;
        [SerializeField] private AudioSource buttonHoverAudioSource;

        public void PlayButtonClick()
        {
            buttonClickAudioSource.Play();
        }

        public void PlayButtonHover()
        {
            buttonHoverAudioSource.Play();
        }
    }
}
