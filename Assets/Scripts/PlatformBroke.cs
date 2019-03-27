        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBroke : MonoBehaviour

{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals ("Character"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
     

    }

}
