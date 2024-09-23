using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;

    public float lastHorizontalVector;

    public float lastVerticalVector;


    [SerializeField] private float speed = 3f;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    private void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if(movementVector.y != 0) 
        {
            lastVerticalVector = movementVector.y; 
        }


        movementVector.Normalize(); // Normalizamos para evitar velocidades extrañas en diagonales
        movementVector *= speed;
        rgbd2d.velocity = movementVector;
    }

    private void FixedUpdate()
    {
        rgbd2d.velocity = movementVector * speed;
    }
}
