using UnityEngine;

namespace _Project._Scripts.Core.Movement
{
    public class InputController: MonoBehaviour
    {
        private IMovable _movable;

        private void Awake()
        {
            _movable = GetComponent<IMovable>();
            
            if (_movable == null)
                throw new System.Exception($"No IMovable attached on {gameObject.name}");
        }

        private void Update()
        {
            ReadInput();
        }
        
        private void ReadInput()
        {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
            
            _movable.Move(new (xAxis, 0f, yAxis));
        }
    }
}