using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float Ms;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Horiz * Ms, 0);

        if (transform.position.y > 814f)
        {
            transform.position = new Vector2(transform.position.x, -395f);
        }

        if (transform.position.y < -815f)
        {
            transform.position = new Vector2(transform.position.x, -815f);
        }

    }
}
