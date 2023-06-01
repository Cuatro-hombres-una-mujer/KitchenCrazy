using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    
    private const string MovementVertical = "Vertical";
    private const string MovementHorizontal = "Horizontal";
    
    [SerializeField]private float _speed = 15f;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveInput;
    private Animator _animator;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        var moveX = Input.GetAxisRaw(MovementHorizontal);
        var moveY = Input.GetAxisRaw(MovementVertical);
        _moveInput = new Vector2(moveX,moveY).normalized;

        _animator.SetFloat(MovementHorizontal, moveX);
        _animator.SetFloat(MovementVertical, moveY);
        
    }
    private void FixedUpdate()
    {
        _rigidBody.
            MovePosition(_rigidBody.position + _moveInput * _speed * Time.fixedDeltaTime);

    }
}
