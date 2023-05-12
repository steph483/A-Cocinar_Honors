using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristUI : MonoBehaviour
{
    public InputActionAsset inputActions;

    private Canvas wristUICanvas;
    private InputAction menu;

    // Start is called before the first frame update
    void Start()
    {
        wristUICanvas = GetComponent<Canvas>();
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        if (menu == null)
        {
            Debug.LogError("THere is not input acction for menu!");
        }

        menu.Enable();
        menu.performed += ToggleMenu;
    }

    private void OnDestroy()
    {
        menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        wristUICanvas.enabled = !wristUICanvas.enabled;
    }
}
