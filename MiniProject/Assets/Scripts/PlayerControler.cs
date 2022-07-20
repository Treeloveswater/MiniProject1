using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject role;
    [SerializeField] public float speed = 5.0f;

    private Rigidbody2D _rigidbody2D = null;

    private Vector2 inputmove = Vector2.zero;
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputmove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        inputmove.Normalize();

        if(inputmove == Vector2.zero || _rigidbody2D == null) return;

    }

    private void FixedUpdate()
    {
        if (inputmove == Vector2.zero || _rigidbody2D == null) return;
        //_rigidbody2D.velocity = inputmove * speed;
        _rigidbody2D.position = _rigidbody2D.position + speed * inputmove * Time.deltaTime;
    }
}
    