using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceHandler : MonoBehaviour
{
    #region Singleton
    private static InterfaceHandler _instance;
    public static InterfaceHandler Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Two instances of InterfaceHandler are in the scene, Singleton..");
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inputActions = new InputActions();
        inputActions.PlayerTank.Enable();
    }
    #endregion

    public InputActions inputActions;
}
