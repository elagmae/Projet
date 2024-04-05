
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Contrôle les déplacements du joueur.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField]
    private float _speed;
    private void Awake()
    {
        var InputHandler = this.GetComponent<InputHandler>();
        InputHandler.Movement += Movement;
    }
    public void Movement(InputAction.CallbackContext ctx, Vector2 _dir)
    {
        _direction = _dir;
    }

    private void FixedUpdate()
    {
        _direction.y = 0;
        this.transform.position += (((Vector3)_direction) * _speed * Time.fixedDeltaTime);
    }
}
