using UnityEngine;

namespace Util
{
    public static class PauseManager
    {
        public static void Pause()
        {
            Time.timeScale = 0;
        }

        public static void Resume()
        {
            Time.timeScale = 1;
        }
    }
}