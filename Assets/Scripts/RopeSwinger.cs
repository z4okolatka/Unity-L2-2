using UnityEngine;

public class RopeSwinger : MonoBehaviour
{
    [SerializeField] KeyCode Key;
    [SerializeField] private float velocityMultiplier = 1.001f;
    [SerializeField] private float maxVelocityX = 20f;
    [SerializeField] private float maxAngle = 30f;
    private bool _isSwinging = false;
    Rigidbody2D _rigidBody;
    Transform _transform;
    HingeJoint2D _joint;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _joint = GetComponent<HingeJoint2D>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            _isSwinging = true;
        }
        if (_isSwinging && _rigidBody.velocity.y < 0 && Mathf.Abs(_rigidBody.velocity.x) < maxVelocityX &&
            _joint.enabled && Mathf.Abs(_transform.rotation.z) <= maxAngle / 100)
        {
            float new_vx = Mathf.Abs(_rigidBody.velocity.x * velocityMultiplier);
            if (5f > new_vx && Mathf.Abs(_transform.rotation.z) <= 0.1f)
            {
                new_vx = 5f;
            }
            _rigidBody.velocity = new Vector2(
                 Mathf.Sign(_rigidBody.velocity.x) * new_vx,
                _rigidBody.velocity.y * velocityMultiplier);
        }
        if (Input.GetKeyUp(Key))
        {
            _isSwinging = false;
        }
    }
}
