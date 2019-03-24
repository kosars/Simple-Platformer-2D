using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_VelocityMove : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] public float MovementSpeed = 3f; //Скорость движения
    [Range(0f, 10f)] [SerializeField] public float JumpForce = 5f;
    [Range(0f, 5f)] [SerializeField] public float JumpScale = 5f; //Сила прыжка
    [Range(0f, 5f)] [SerializeField] public float FlyingSpeed = 5f;
    public int MaxJumpNums;//максимальное колво прыжков
    private int JumpNum;//счетчик кол-ва прыжков
    private float VerticalAxis;

   // private bool isGrouded = false;
    [SerializeField] public bool infinitieJump; //Бесконечный прыжок
    [SerializeField] public bool isFlying; //Полет

    Rigidbody2D rb2d;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        JumpNum = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
        if (Input.GetButtonDown("Jump") && (JumpNum<MaxJumpNums || infinitieJump) && (!isFlying))
        {
            Jump();
        }    
    }

    private void Move()
    {
        if (isFlying)
        {
            VerticalAxis = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(MovementSpeed * 10f, VerticalAxis * FlyingSpeed * 10f);
            
        }
        else
        {
            rb2d.velocity = new Vector2(MovementSpeed * 10f, rb2d.velocity.y); 
        }
        MovementSpeed += 0.0005f;//постепенное увеличение скорости движения }
    }
    //метод прыжка
    private void Jump()
    {
            rb2d.AddForce(new Vector2(rb2d.velocity.x + JumpScale, JumpForce *10f + Time.fixedDeltaTime ), ForceMode2D.Impulse);
            JumpNum++;
            //isGrouded = false;  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
          //  isGrouded = true;
            JumpNum = 0;
        }
    }
}
