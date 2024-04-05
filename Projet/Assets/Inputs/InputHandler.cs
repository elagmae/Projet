using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput _input;

    public event Action<InputAction.CallbackContext, Vector2> Movement;
    public event Action<InputAction.CallbackContext> Jump;

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _input.onActionTriggered += OnInput;
    }

    void OnInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.action.name)
        {
            case "Movement":
                Movement?.Invoke(ctx, ctx.ReadValue<Vector2>());
                break;

            case "Jump":
                Jump?.Invoke(ctx); 
                break;
        }
    }
}

