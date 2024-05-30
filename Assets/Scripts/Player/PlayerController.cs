using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnInteractEvent;
    public event Action OnInventoryEvent;
    public void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>().normalized;
        if (context.phase == InputActionPhase.Performed)
        {
            OnMoveEvent?.Invoke(direction);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            OnMoveEvent?.Invoke(Vector2.zero);
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnJumpEvent?.Invoke();
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        OnLookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteraction(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Started&&GameManager.Instance.PlayerData.curItem!=null){
            OnInteractEvent?.Invoke();
        }
    }

    public void OnInventory(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Started){
            OnInventoryEvent?.Invoke();
        }
    }
}
