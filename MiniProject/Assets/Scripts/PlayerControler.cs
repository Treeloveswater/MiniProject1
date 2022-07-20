using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject role;
    [SerializeField] public float speed = 5.0f;

    public float jumpspeed = 15f;
    //public float gravity = 1;
    //public float fallMultiplier = 5f;

    Camera https://www.youtube.com/watch?v=USLp-4iwNnQ;

    public LayerMask groundLayer;
    public GameObject groundpos;
    private Rigidbody2D _rigidbody2D = null;
    private float facedirection;
    private Vector2 inputmove = Vector2.zero;

    private bool dojump;

    void Start()
    {

        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    public bool OnGround = false;
    public float groundLength = 0.6f;

    // Update is called once per frame
    void Update()
    {
        OnGround = Physics2D.Raycast(groundpos.transform.position, Vector2.down, groundLength, groundLayer);

        inputmove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        float facedirection = Input.GetAxisRaw("Horizontal");
        inputmove.Normalize();
        if(Input.GetButtonDown("Jump") && OnGround)
        {
            dojump = true;
        }

        if(inputmove == Vector2.zero || _rigidbody2D == null) return;


        
    }
    void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);

    }

    private void FixedUpdate()
    {
        if (inputmove == Vector2.zero || _rigidbody2D == null) return;
        //_rigidbody2D.velocity = inputmove * speed;
        _rigidbody2D.position = _rigidbody2D.position + speed * inputmove * Time.deltaTime;
        if (facedirection != 0)
        {
            _rigidbody2D.transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (dojump)
        {
            dojump = false;
            Jump();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundpos.transform.position, groundpos.transform.position + Vector3.down * groundLength);
    }
}
    