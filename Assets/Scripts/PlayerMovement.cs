using Entities;
using Entities.Player;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static Player _player;

    private const string MovementVertical = "Vertical";
    private const string MovementHorizontal = "Horizontal";
    public AudioSource clip;

    [SerializeField] private float _speed = 15f;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveInput;
    private Animator _animator;
    private bool Hactivo;
    private bool Vactivo;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = new Player();
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

        if (_player.HasOpenInventory())
        {
            return;
        }

        var moveX = Input.GetAxisRaw(MovementHorizontal);
        var moveY = Input.GetAxisRaw(MovementVertical);
        _moveInput = new Vector2(moveX, moveY).normalized;

        _animator.SetFloat(MovementHorizontal, moveX);
        _animator.SetFloat(MovementVertical, moveY);

        if (Input.GetButtonDown(MovementHorizontal))
        {
            Hactivo = true;
            clip.Play();
        }

        if (Input.GetButtonDown(MovementVertical))
        {
            Vactivo = true;
            clip.Play();
        }

        if (Input.GetButtonUp(MovementHorizontal))
        {
            if (Vactivo == false)
            {
                clip.Pause();
            }

            Hactivo = false;
        }

        if (Input.GetButtonUp(MovementVertical))
        {
            if (Hactivo == false)
            {
                clip.Pause();
            }

            Vactivo = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_player.HasOpenInventory())
        {
            _rigidBody.MovePosition(_rigidBody.position + _moveInput * _speed * Time.fixedDeltaTime);
        }
        
    }

    public static Player GetPlayer()
    {
        return _player;
    }
}