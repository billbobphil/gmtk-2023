using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class MoveOverworldObject : MonoBehaviour
    {
        [SerializeField] private float distance;
        [SerializeField] private float timeBetweenSteps;
        private float _timer;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _directionToMove;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetDirectionToMove(Vector2 directionToMove)
        {
            _directionToMove = directionToMove;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < timeBetweenSteps) return;
            
            MoveInDirection(_directionToMove);

            _timer = 0;
        }
        
        private void MoveInDirection(Vector2 direction)
        {
            _rigidbody2D.position += direction * distance;
        }
    }
}