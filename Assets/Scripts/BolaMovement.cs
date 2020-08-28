using UnityEngine;
using Random = UnityEngine.Random;

public class BolaMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    [SerializeField] private float movementForce = 1f;

    private Vector3 direction;

    private void Awake()//Funciona antes del start
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        var direction = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), 0f); //Valores inclusivos, para que la bola salga en una dirección aleatoria.
        _rigidbody2D.AddForce(direction.normalized * movementForce, ForceMode2D.Impulse); //Mantiene la dirección y el sentido pero no la magnitud.
    }

    void Update()
    {
        _velocity = _rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var speed = _velocity.magnitude;
        var newDirection = Vector3.Reflect(_velocity.normalized, other.contacts[0].normal);
        _rigidbody2D.velocity = newDirection * Mathf.Max(speed, 0f);
    }

}
