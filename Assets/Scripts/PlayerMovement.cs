using Entities;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string MovementVertical = "Vertical";
    private const string MovementHorizontal = "Horizontal";
    public AudioSource clip;

    [SerializeField] private float _speed = 15f;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveInput;
    private Animator _animator;
    private bool Hactivo;
    private bool Vactivo;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClientPool clientPool = ClientHandlerScript.GetMainClientPool();
            
            if (clientPool == null)
            {
                print("Es null el client pooll");
                return;
            }

            clientPool.Spawn();
            print("Spawned");
        }

        var moveX = Input.GetAxisRaw(MovementHorizontal);
        var moveY = Input.GetAxisRaw(MovementVertical);
        _moveInput = new Vector2(moveX, moveY).normalized;

        _animator.SetFloat(MovementHorizontal, moveX);
        _animator.SetFloat(MovementVertical, moveY);

        if (Input.GetButtonDown(MovementHorizontal)){
            Hactivo = true;
            clip.Play();
        }
        if (Input.GetButtonDown(MovementVertical)){
            Vactivo = true;
            clip.Play();
        }
        if (Input.GetButtonUp(MovementHorizontal)){
            if (Vactivo == false){
                clip.Pause();
            }            
            Hactivo = false;
        }
        if (Input.GetButtonUp(MovementVertical)){
            if (Hactivo == false){
                clip.Pause();
            }
            Vactivo = false;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _moveInput * _speed * Time.fixedDeltaTime);
    }
}