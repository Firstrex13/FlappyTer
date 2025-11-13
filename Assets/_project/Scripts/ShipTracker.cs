using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    private Ship _ship;

    [SerializeField] private float _xOffset;

    private void LateUpdate()
    {
        if (_ship != null)
        {
            var position = transform.position;
            position.x = _ship.transform.position.x + _xOffset;
            transform.position = position;
        }
    }

    public void Initialize(Ship ship)
    {
        _ship = ship;
    }
}
