using UnityEngine;

namespace Effects
{
    public class Float : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float floatUpDistance;
        [SerializeField] private float floatDownDistance;
        private float startingYPosition;
        private float topYPosition;
        private float bottomYPosition;
        private int currentDirection;
        [SerializeField] private bool _isFloating;

        private void Start()
        {
            currentDirection = 1;
            startingYPosition = transform.position.y;
            topYPosition = startingYPosition + floatUpDistance;
            bottomYPosition = startingYPosition - floatDownDistance;
        }

        public void StartFloating()
        {
            _isFloating = true;
        }

        public void StopFloating()
        {
            _isFloating = false;
        }

        public void Reset()
        {
            transform.position = new Vector2(transform.position.x, startingYPosition);
        }

        private void Update()
        {
            if (!_isFloating) return;
            
            float step = speed * Time.deltaTime;
            
            if (currentDirection == 1)
            {
                if (transform.position.y <= topYPosition)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x, topYPosition + (floatUpDistance / 5)), step);
                }
                else
                {
                    currentDirection *= -1;
                }
            }
            else
            {
                if (transform.position.y >= bottomYPosition)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x, bottomYPosition - (floatDownDistance / 5)), step);
                }
                else
                {
                    currentDirection *= -1;
                }
            }
            
        }
    }
}