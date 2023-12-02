using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Movimiento : MonoBehaviour
{
    public Rigidbody dragonAR;
    public Vector3 movimiento;
    public Quaternion rotacion;
    public float velocidad=2f;
    // Start is called before the first frame update
    void Start()
    {
        dragonAR.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        float rotX = Input.GetKey(KeyCode.X) ? 1.0f : 0.0f;
        float rotY = Input.GetKey(KeyCode.Y) ? 1.0f : 0.0f;
        float rotZ = Input.GetKey(KeyCode.Z) ? 1.0f : 0.0f;
        float rotW = Input.GetKey(KeyCode.V) ? 1.0f : 0.0f;
        rotacion = new Quaternion(rotX,rotY,rotZ,rotW);
        movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        dragonAR.MovePosition(transform.position+movimiento*velocidad);
        dragonAR.MoveRotation(transform.rotation*rotacion);
    }
}*/


public class Movimiento : MonoBehaviour
{
    public Rigidbody dragonAR;
    public Vector3 movimiento;
    public float velocidad = 2f;
    public float velocidadRotacion = 200f; // Nueva variable para controlar la velocidad de rotación

    Quaternion rotacionObjetivo = Quaternion.identity; // Variable para la rotación gradual

    void Start()
    {
        dragonAR = GetComponent<Rigidbody>(); // Corrección para obtener el Rigidbody del mismo GameObject
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        dragonAR.MovePosition(transform.position + movimiento * velocidad);

        // Verificación de teclas presionadas para la rotación gradual
        if (Input.GetKey(KeyCode.X))
            rotacionObjetivo *= Quaternion.Euler(Vector3.right * Time.deltaTime * velocidadRotacion);
        if (Input.GetKey(KeyCode.Y))
            rotacionObjetivo *= Quaternion.Euler(Vector3.up * Time.deltaTime * velocidadRotacion);
        if (Input.GetKey(KeyCode.Z))
            rotacionObjetivo *= Quaternion.Euler(Vector3.forward * Time.deltaTime * velocidadRotacion);
        if (Input.GetKey(KeyCode.M))
            rotacionObjetivo *= Quaternion.Euler(Vector3.back * Time.deltaTime * velocidadRotacion);
        if (Input.GetKey(KeyCode.B))
            rotacionObjetivo *= Quaternion.Euler(Vector3.down * Time.deltaTime * velocidadRotacion); // Rotación hacia abajo
        if (Input.GetKey(KeyCode.N))
            rotacionObjetivo *= Quaternion.Euler(Vector3.left * Time.deltaTime * velocidadRotacion); // Rotación hacia la izquierda
        if (Input.GetKey(KeyCode.V))
            rotacionObjetivo = Quaternion.identity; // Reiniciar la rotación a la posición inicial

        dragonAR.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime));
    }
}

