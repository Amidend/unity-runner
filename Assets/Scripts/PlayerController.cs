using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    private CharacterController _controller;
    private Vector3 _vector;
    private float _speed = 10f;
    private float _moveSpeed = 0.01f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        _vector.z = _speed;
        _speed += _moveSpeed;
        _vector.y = -1f;
        _controller.Move(_vector * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepose = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
            if (mousepose.y > 0.5 && _controller.isGrounded)
            {
                _animator.SetTrigger("Jump");
                _speed -= _moveSpeed*10f;
            }
            else if (mousepose.x > 0.5) transform.Translate(_moveSpeed, 0, 0);
            else if (mousepose.x < 0.5) transform.Translate(-_moveSpeed, 0, 0);
        }
        if (_speed > 40f) _animator.SetTrigger("SpeedTrigger");
    }
}

