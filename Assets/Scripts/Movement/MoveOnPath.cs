using System;
using Minigame;
using Unity.VisualScripting;
using UnityEngine;

namespace Movement
{
    public class MoveOnPath : MonoBehaviour, IResetable
    {
        public EditorPath editorPath;
        public int currentWayPointID = 0;

        public float speed;
        public float reachDistance = 1.0f;

        private Vector3 _currentPosition;
        public bool loop = true;
        private bool goingForward = true;

        private void Update()
        {
            if (currentWayPointID < editorPath.paths.Count)
            {
                float distance = Vector3.Distance(editorPath.paths[currentWayPointID].position, transform.position);
                transform.position = Vector3.MoveTowards(transform.position, editorPath.paths[currentWayPointID].position,
                    Time.deltaTime * speed);

                if (distance <= reachDistance)
                {
                    if (goingForward)
                    {
                        currentWayPointID++;
                    }
                    else
                    {
                        currentWayPointID--;
                    }
                }

                if (loop)
                {
                    if (currentWayPointID >= editorPath.paths.Count)
                    {
                        goingForward = false;
                        currentWayPointID--;
                    }
                    else if (currentWayPointID < 0)
                    {
                        goingForward = true;
                        currentWayPointID++;
                    }
                }
            }
        }

        public void ResetObject()
        {
            currentWayPointID = 0;
            goingForward = true;
        }
    }
}

