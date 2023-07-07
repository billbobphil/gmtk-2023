using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Movement
{
    public class PlayerOverworldMovementController : MonoBehaviour
    {
        //This works, just don't try and use the arrow controls and the WASD controls at the same time..
        //Could be improved by recording each key on down into a list, then when that key is let go, remove from list,
        //when a player lets go of the current key, get the next item in the keys down array until nothing remains
        //gamejam though, time to move on
        [SerializeField] private MoveOverworldObject _moveOverworldObject;
        private Vector2 _directionLastPressed;
        private int _numberOfKeysPressed;
        private List<KeyCode> _keysToCheck;
        [SerializeField] private List<KeyCode> rightMovementKeyCodes;
        [SerializeField] private List<KeyCode> leftMovementKeyCodes;
        [SerializeField] private List<KeyCode> upMovementKeyCodes;
        [SerializeField] private List<KeyCode> downMovementKeyCodes;
        
        private void Awake()
        {
            // _keysToCheck = new List<KeyCode>
            // {
            //     KeyCode.A,
            //     KeyCode.D,
            //     KeyCode.W,
            //     KeyCode.S
            // };

            _keysToCheck = new List<KeyCode>();
            
            _keysToCheck.AddRange(rightMovementKeyCodes);
            _keysToCheck.AddRange(leftMovementKeyCodes);
            _keysToCheck.AddRange(upMovementKeyCodes);
            _keysToCheck.AddRange(downMovementKeyCodes);
        }
        private void Update()
        {
            RecordKeysPressedDown();
            RecordKeysLetUp();
            
            if (upMovementKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                _directionLastPressed = Vector2.up;
            }

            if (downMovementKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                _directionLastPressed = Vector2.down;
            }

            if (leftMovementKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                _directionLastPressed = Vector2.left;
            }

            if (rightMovementKeyCodes.Any(code => Input.GetKeyDown(code)))
            {
                _directionLastPressed = Vector2.right;
            }
            
            
            if (upMovementKeyCodes.Any(code => Input.GetKey(code)) && 
                (_directionLastPressed == Vector2.up || _numberOfKeysPressed == 1))
            {
                _moveOverworldObject.SetDirectionToMove(Vector2.up);
            }
            
            if (leftMovementKeyCodes.Any(code => Input.GetKey(code)) &&
                (_directionLastPressed == Vector2.left || _numberOfKeysPressed == 1))
            {
                _moveOverworldObject.SetDirectionToMove(Vector2.left);
            }
            
            if (rightMovementKeyCodes.Any(code => Input.GetKey(code)) && 
                (_directionLastPressed == Vector2.right || _numberOfKeysPressed == 1))
            {
                _moveOverworldObject.SetDirectionToMove(Vector2.right);
            }
            
            if (downMovementKeyCodes.Any(code => Input.GetKey(code)) && 
                (_directionLastPressed == Vector2.down || _numberOfKeysPressed == 1))
            {
                _moveOverworldObject.SetDirectionToMove(Vector2.down);
            }

            if (_numberOfKeysPressed == 0)
            {
                _moveOverworldObject.SetDirectionToMove(new Vector2(0,0));
            }
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