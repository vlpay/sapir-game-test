using UnityEngine;

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * _speed);
    }
}
