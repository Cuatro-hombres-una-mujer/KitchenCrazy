using Entities;
using UnityEngine;

public class ClientScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Client _client;
    private ClientPool _clientPool;
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float speed = 0.15f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (_clientPool == null)
        {
            _clientPool = ClientHandlerScript.GetMainClientPool();
            _client = _clientPool.GetClient(name);

            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        if (!_client.IsWalking())
        {
            Debug.Log("Pruebarrrr");
            return;
        }
        
        
        Debug.Log("RRRRRRRRRRR");
        IMovementStrategy movementStrategy = _clientPool.GetMovementStrategy();
        //Vector2 vectorMovement = movementStrategy.Move();
        
        Vector2 position = _rigidbody.position;

        Vector2 newVector = new Vector2(-1, 0);

        _rigidbody.MovePosition(position + newVector * speed * Time.deltaTime);
        
        print("Position: ");
        print(_rigidbody.position.x);
        print(_rigidbody.position.y);
        print("<--->");
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        //_client.StopWalk();
        
    }
}