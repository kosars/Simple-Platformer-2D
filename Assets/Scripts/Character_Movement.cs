using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {
    [Range(0.0f, 1.0f)] [SerializeField] public float MovementSpeed = 0.2f; //Скорость движения
    [Range(0f, 25f)] [SerializeField] public float JumpForce = 5f; //Сила прыжка
    //private float posX,posY; //Позиция Персонажа
    private bool isGrouded;  

    Rigidbody2D rb2d;
    Animation anim;
   // Collision2D coll;
    

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collision2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    void FixedUpdate() {
        MoveX();
        if (Input.GetKey(KeyCode.Space) && isGrouded)
        {
            rb2d.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
            isGrouded = false;
        }
    }
    public void MoveX()
    {
        rb2d.position = new Vector2(rb2d.position.x + MovementSpeed, rb2d.position.y);
    }

    void OnCollisionEnter2D( Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log(coll.gameObject.name);
            isGrouded = true;
        }
    }
}

   // Use OnCollisionEnter2D, and then at command jump, give condition blnCollisionGround:
