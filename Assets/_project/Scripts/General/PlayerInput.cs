using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action FlyUpButtonPressed;
    public event Action ShootButtonPressed;

    public bool SpacePressed { get; private set; }
    public bool LBMPressed { get; private set; }

    private void Update()
    {
        if (SpacePressed = Input.GetKeyDown(KeyCode.Space))
        {
            FlyUpButtonPressed?.Invoke();
        }

        if (LBMPressed = Input.GetMouseButtonDown(0))
        {
            ShootButtonPressed?.Invoke();
        }
    }
}
