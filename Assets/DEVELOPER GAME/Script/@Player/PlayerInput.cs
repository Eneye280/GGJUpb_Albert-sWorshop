using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private MovementPlayer movementPlayer;

    internal InputPlayer controls;

    private void OnDisable() => controls.Disable();
    private void OnEnable() => controls.Enable();

    private void Awake()
    {
        movementPlayer = GetComponent<MovementPlayer>();
        
        controls = new InputPlayer();

        controls.Player.Movement.performed += ctx => movementPlayer.direction = ctx.ReadValue<Vector2>();
    }

}
