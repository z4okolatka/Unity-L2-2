using UnityEngine;

public class swing : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    Transform _transform;
    private bool _isSwinging = false;
    private float velocityMultiplier = 1.001f;
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    
    private void Update()
    {
        //Debug.Log(_transform.rotation.z);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _isSwinging = true;
        }
        if (_isSwinging && _rigidBody.velocity.y < 0 && Mathf.Abs(_rigidBody.velocity.x) < 20f &&
            GetComponent<HingeJoint2D>() != null && Mathf.Abs(_transform.rotation.z) <= 0.3f)
        {
            var new_vx = Mathf.Abs(_rigidBody.velocity.x * velocityMultiplier);
            if (5f > new_vx && Mathf.Abs(_transform.rotation.z) <= 0.1f)
            {
                Debug.Log($"boost");
                new_vx = 5f;
            }
            _rigidBody.velocity = new Vector2(
                 Mathf.Sign(_rigidBody.velocity.x) * new_vx,
                _rigidBody.velocity.y * velocityMultiplier);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _isSwinging = false;
        }
    }
}
