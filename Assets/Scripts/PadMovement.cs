
using UnityEngine;

/// <summary>
/// El PadMovement, mueve el jugador a lo largo del eje x.
/// </summary>

//Lo pone genérico 
[RequireComponent(typeof(Rigidbody2D))]

public class PadMovement : MonoBehaviour
{   
    [Tooltip("¡Velocidad en unidades!")]
    //Velocidad de movimiento, serializable para que Unity la vea.
    [SerializeField]private float velocity = 5f;

    [Header("Controles para el GamePad:")]
    [SerializeField] private KeyCode upControl;
    [SerializeField] private KeyCode downControl;

    private Rigidbody2D _rigidbody2D;
    private float padLimit = 3.5f;
   
   
    private void awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //Leer el control de las teclas
        //Aplicar movimiento

        //Mover hacia arriba
        if (Input.GetKey(upControl))
        {
            transform.Translate(0f, velocity, 0f);
        }

        //Mover hacia abajo
        else if (Input.GetKey(downControl))
        {
            transform.Translate(0f, -velocity, 0f);
        }

        transform.position = new UnityEngine.Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -padLimit, padLimit), transform.position.z);
    }
}

