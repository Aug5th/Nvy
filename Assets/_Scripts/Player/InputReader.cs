using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Input / Input Reader", fileName = "Input Reader")]
public class InputReader : ScriptableObject
{
    [SerializeField] private InputActionAsset _inputAsset;

    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction JumpEvent;
    public event UnityAction JumpCancelledEvent;
    public event UnityAction DashEvent;
    public event UnityAction DashCancelledEvent;
    public event UnityAction AttackEvent;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _dashAction;
    private InputAction _attackAction;


    private void OnEnable()
    {
        _moveAction = _inputAsset.FindAction("Move");
        _jumpAction = _inputAsset.FindAction("Jump");
        _dashAction = _inputAsset.FindAction("Dash");
        _attackAction = _inputAsset.FindAction("Attack");

        _moveAction.started += OnMove;
        _moveAction.performed += OnMove;
        _moveAction.canceled += OnMove; 

        _jumpAction.started += OnJump;
        _jumpAction.performed += OnJump;
        _jumpAction.canceled += OnJump; 

        _dashAction.started += OnDash;
        _dashAction.performed += OnDash;
        _dashAction.canceled += OnDash; 

        _attackAction.started += OnAttack;
        _attackAction.performed += OnAttack;
        _attackAction.canceled += OnAttack; 

        _moveAction.Enable();
        _jumpAction.Enable();
        _dashAction.Enable();
        _attackAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.started -= OnMove;
        _moveAction.performed -= OnMove;
        _moveAction.canceled -= OnMove; 

        _jumpAction.started -= OnJump;
        _jumpAction.performed -= OnJump;
        _jumpAction.canceled -= OnJump; 

        _dashAction.started -= OnDash;
        _dashAction.performed -= OnDash;
        _dashAction.canceled -= OnDash; 

        _attackAction.started -= OnAttack;
        _attackAction.performed -= OnAttack;
        _attackAction.canceled -= OnAttack; 

        _moveAction.Disable();
        _jumpAction.Disable();
        _dashAction.Disable();
        _attackAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if(JumpEvent != null && context.started)
        {
            JumpEvent.Invoke();
        }

        if(JumpCancelledEvent != null && context.canceled)
        {
            JumpCancelledEvent.Invoke();
        }
    }
    private void OnDash(InputAction.CallbackContext context)
    {
        if(DashEvent != null && context.started)
        {
            DashEvent.Invoke();
        }

        if(DashCancelledEvent != null && context.canceled)
        {
            DashCancelledEvent.Invoke();
        }
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        if(AttackEvent != null && context.started)
        {
            AttackEvent.Invoke();
        }
    }
}
