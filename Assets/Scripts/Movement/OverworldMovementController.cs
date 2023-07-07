using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class OverworldMovementController : MonoBehaviour
    {
        [SerializeField] private float distance;
        [SerializeField] private float timeBetweenSteps;
        private float _timer;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _directionLastPressed;
        private int _numberOfKeysPressed;
        private List<KeyCode> _keysToCheck; 

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _keysToCheck = new List<KeyCode>
            {
                KeyCode.A,
                KeyCode.D,
                KeyCode.W,
                KeyCode.S
            };
        }
        
        private void Update()
        {
            _timer += Time.deltaTime;
            
            RecordKeysPressedDown();
            RecordKeysLetUp();

            if (Input.GetKeyDown(KeyCode.W))
            {
                _directionLastPressed = Vector2.up;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _directionLastPressed = Vector2.down;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _directionLastPressed = Vector2.left;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _directionLastPressed = Vector2.right;
            }
            
            if (_timer < timeBetweenSteps) return;

            if (Input.GetKey(KeyCode.W) && (_directionLastPressed == Vector2.up || _numberOfKeysPressed == 1))
            {
                MoveInDirection(Vector2.up);
            }
            
            if (Input.GetKey(KeyCode.A) && (_directionLastPressed == Vector2.left || _numberOfKeysPressed == 1))
            {
                MoveInDirection(Vector2.left);
            }
            
            if (Input.GetKey(KeyCode.D) && (_directionLastPressed == Vector2.right || _numberOfKeysPressed == 1))
            {
                MoveInDirection(Vector2.right);
            }
            
            if (Input.GetKey(KeyCode.S) && (_directionLastPressed == Vector2.down || _numberOfKeysPressed == 1))
            {
                MoveInDirection(Vector2.down);
            }

            _timer = 0;
        }

        private void MoveInDirection(Vector2 direction)
        {
            _rigidbody2D.position += direction * distance;
        }

        private void RecordKeysPressedDown()
        {
            foreach (KeyCode code in _keysToCheck)
            {
                if (Input.GetKeyDown(code))
                {
                    _numberOfKeysPressed++;
                }
            }
        }

        private void RecordKeysLetUp()
        {
            foreach (KeyCode code in _keysToCheck)
            {
                if (Input.GetKeyUp(code))
                {
                    _numberOfKeysPressed--;
                }
            }
        }
    }
}
