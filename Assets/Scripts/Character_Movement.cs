using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {
    [Range(0.0f, 1.0f)] [SerializeField] public float MovementSpeed = 0.2f; //Скорость движения
    [Range(0f, 25f)] [SerializeField] public float JumpForce = 5f; //Сила прыжка
    [Range(0f, 1f)] [SerializeField] public float FlyingSpeed = 0.2f;
    public float VerticalMove;

    private bool isGrouded;
    [SerializeField] public bool infinitieJump; //Бесконечный прыжок
    [SerializeField] public bool isFlying; // Полет


    Rigidbody2D rb2d;
    Animation anim;
    //Collider2D collider;

    

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    void FixedUpdate() {
        Move();

        if (Input.GetKey(KeyCode.Space) && (isGrouded || infinitieJump))
        {
            rb2d.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
            isGrouded = false;
        }
    }
    public void Move()
    {
        if (isFlying)
        {
            VerticalMove = Input.GetAxis("Vertical");
            rb2d.position = new Vector2(rb2d.position.x + MovementSpeed, rb2d.position.y + VerticalMove*FlyingSpeed/* * Time.deltaTime*100f*/ );
        }
        else 
        {
            rb2d.position = new Vector2(rb2d.position.x + MovementSpeed, rb2d.position.y);
        }
        
    }

    void OnCollisionEnter2D( Collision2D collision )
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(collision.gameObject.name);
            isGrouded = true;
        }
        
       // if (Input.GetAxis("Vertical") < 0)
        //{
       //     collider.isTrigger = true;
        //}
    }
}

