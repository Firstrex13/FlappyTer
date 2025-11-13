using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode _spaceButton = KeyCode.Space;
    private const int _leftMouseButton = 0;

    public event Action FlyUpButtonPressed;
    public event Action ShootButtonPressed;
    
    public bool SpacePressed { get; private set; }
    public bool LBMPressed { get; private set; }


    private void Update()
    {
        if (SpacePressed = Input.GetKeyDown(_spaceButton))
        {
            FlyUpButtonPressed?.Invoke();
        }

        if (LBMPressed = Input.GetMouseButtonDown(_leftMouseButton))
        {
            ShootButtonPressed?.Invoke();
        }
    }
}
