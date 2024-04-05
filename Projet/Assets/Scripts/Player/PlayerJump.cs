using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.InputSystem.Switch;
/// <summary>
/// Contrôle les sauts du joueur.
/// </summary>

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce;
    private bool _isJumping = false;
    private SwitchProControllerHID SwitchProControllerHID;

    private void Awake()
    {
        var InputHandler = this.GetComponent<InputHandler>();
        InputHandler.Jump += Jump;
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !_isJumping)
        {
            _isJumping = true;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            SwitchProControllerHID.current.SetMotorSpeeds(2.0f, 2.0f);
        }
    }
}
