using UnityEngine;

namespace Util
{
    public class MenuMusicPlayer : MonoBehaviour
    {
        public static void ManualDestroy()
        {
            if (instance)
            {
                Destroy(instance.gameObject);    
            }
        }

        private static MenuMusicPlayer instance;
        
        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
