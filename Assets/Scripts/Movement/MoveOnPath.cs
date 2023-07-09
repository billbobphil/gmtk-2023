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
        public bool goingForward = true;
        private Vector2 startingPosition;
        private int startingWaypointID = 0;
        private bool startingForward;
        private void Awake()
        {
            startingPosition = new Vector2(transform.position.x, transform.position.y);
            startingWaypointID = currentWayPointID;
            startingForward = goingForward;
        }

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
                else
                {
                    if (currentWayPointID >= editorPath.paths.Count)
                    {
                        currentWayPointID = 0;
                    } else if (currentWayPointID < 0)
                    {
                        currentWayPointID = editorPath.paths.Count - 1;
                    }
                }
            }
        }

        public void ResetObject()
        {
            currentWayPointID = startingWaypointID;
            goingForward = startingForward;
            transform.position = new Vector3(startingPosition.x, startingPosition.y, 0f);
        }
    }
}

