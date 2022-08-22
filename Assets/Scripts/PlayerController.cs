using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    
    [SerializeField] Animator _animator;
    Rigidbody rb;
    private CharacterController _controller;
    private Vector3 _vector, _jump;
    private float _speed = 5f;
    private float _moveSpeed = 0.1f;
    public bool isGrounted;
    public float jumpForce = 2.0f;
    void OnCollisionEnter()
    {
        isGrounted = true;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        _jump = new Vector3(0.0f, 250.0f, 0.0f);
    }
    void FixedUpdate()
    {
        _vector.z = _speed;
        _controller.Move(_vector*Time.deltaTime);
        _speed += 0.01f;
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepose = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (mousepose.y > 0.5 && isGrounted) 
            {
                isGrounted = false;
                rb.AddForce(_jump * jumpForce, ForceMode.Impulse);
            }
            else if (mousepose.x > 0.5) transform.Translate(_moveSpeed, 0, 0);
            else if (mousepose.x < 0.5) transform.Translate(-_moveSpeed, 0, 0);
        }

    }
   
}
/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}*/