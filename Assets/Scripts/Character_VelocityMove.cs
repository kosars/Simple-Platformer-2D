using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_VelocityMove : MonoBehaviour
{
    //физические величины
    [Range(0f, 5f)] [SerializeField] public float MovementSpeed = 3f; //Скорость движения
    [Range(0f, 10f)] [SerializeField] public float JumpForce = 5f; //Сила прыжка по (y)
    [Range(0f, 5f)] [SerializeField] public float JumpDistance = 5f; //Дальнось прыжка (x)
    [Range(0f, 5f)] [SerializeField] public float FlyingSpeed = 5f; //Cкорость полета(вверх-вниз)

    private float VerticalAxis; //Направление полета(вверх-вниз)

    //Счетчикии и максимальные значения
    public int MaxJumpNums;//максимальное колво прыжков
    private int JumpNum=0;//счетчик кол-ва прыжков
   
    public float BonusTime = 0;// счетчие времени жизни бонуса [сек* Timestep(0.02 cек)]
    private float MaxBonusTime = 10f;//максимальное  время жизни бонуса [сек]

    //
    private bool BonusActive = false; //индикатор активности бонуса
    [SerializeField] public bool infinitieJump; //Бесконечный прыжок
    [SerializeField] public bool isFlying; //Полет

    //
    Rigidbody2D rb2d;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        BonusCheck();//проверка бонусов
        Move();//движение
        Jump();//проверка прыжка  
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
        MovementSpeed += 0.0001f;//постепенное увеличение скорости движения }
    }

    //метод прыжка
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && (JumpNum < MaxJumpNums || infinitieJump) && (!isFlying))
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x + JumpDistance, JumpForce *10f + Time.fixedDeltaTime ), ForceMode2D.Impulse);
            JumpNum++;
            //isGrouded = false;  
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //обнуление количества прыжков, если игрок приоснулся земли
        {
            JumpNum = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlyBonus") //если подобрали бонус полёта
        {
            Debug.Log("БОНУС ПОДОБРАН");
            DisableBonuses();//вызов отключения остальных бонусов
            isFlying = true;//включение полета
            BonusActive = true;
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
        else if (collision.gameObject.tag == "JumpBonus") //если подобрали бонус полёта
        {
            Debug.Log("БОНУС ПОДОБРАН");
            DisableBonuses();//вызов отключения остальных бонусов
            infinitieJump = true;//включение бесконечного прыжка
            BonusActive = true;
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
    }

    private void BonusCheck()
    {
        if(BonusActive && BonusTime < MaxBonusTime) //проверка наличия бонуса и не истекло ли время его жизни
        {
            BonusTime += 0.02f;
        }
        else if(BonusTime>MaxBonusTime)
        {
            DisableBonuses();
        }
    }

    private void DisableBonuses() //функция отключения всех бонусов
    {
        BonusActive = false;
        isFlying = false;
        infinitieJump = false;
        BonusTime = 0; 
    }
}
