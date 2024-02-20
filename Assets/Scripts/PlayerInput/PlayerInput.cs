using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance = default;

    private GameInput gameInput;

    [SerializeField]private Vector2 mousePos = default;

    public Action OnChangeLight = default;
    public Action<Vector2> OnMouseSelect = default;

    private void Awake()
    {
        if(Instance==null){
            Instance=this;
            // DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
    
    private void Start()
    {
        gameInput = new GameInput();
        gameInput.Enable();
        gameInput.TrafficLight.ChangeLight.performed += ChangeLight;//green => red => green
        gameInput.ObjSelected.Selected.performed += GetScreenPosition;
        gameInput.ObjSelected.Click.performed += ClickPerformed;
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }

    private void ChangeLight(InputAction.CallbackContext ctx){
        Debug.Log("ChangeLight Input");
        OnChangeLight?.Invoke();

    }
    private void GetScreenPosition(InputAction.CallbackContext ctx){
        mousePos = ctx.ReadValue<Vector2>();
    }
    private void ClickPerformed(InputAction.CallbackContext ctx)
    {   
        OnMouseSelect?.Invoke(mousePos);
    }

}
