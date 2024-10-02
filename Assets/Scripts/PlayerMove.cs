using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;

    public float lastHorizontalVector;
    public float lastVerticalVector;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        // Obtener la velocidad desde InitialPlayerStats
        float speed = InitialPlayerStats.instance.speed;

        movementVector.Normalize();
        movementVector *= speed;
        rgbd2d.velocity = movementVector;
    }

    private void FixedUpdate()
    {
        // Actualizar la velocidad usando InitialPlayerStats
        rgbd2d.velocity = movementVector * InitialPlayerStats.instance.speed;
    }
}
