using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class EditorPath : MonoBehaviour
    {

        public Color rayColor = Color.white;
        public List<Transform> paths = new List<Transform>();
        private Transform[] transforms;

        private void OnDrawGizmos()
        {
            Gizmos.color = rayColor;

            for (int i = 0; i < paths.Count; i++)
            {
                if (i > 0)
                {
                    Vector3 pathPosition = paths[i].position;
                    Vector3 previous = paths[i - 1].position;
                    Gizmos.DrawLine(previous, pathPosition);
                    Gizmos.DrawWireSphere(pathPosition, 0.3f);
                }
            }
        }
    }
}
