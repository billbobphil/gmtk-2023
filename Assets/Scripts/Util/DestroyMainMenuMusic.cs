using UnityEngine;

namespace Util
{
    public class DestroyMainMenuMusic : MonoBehaviour
    {
        private void Start()
        {
            MenuMusicPlayer.ManualDestroy();
        }
    }
}
