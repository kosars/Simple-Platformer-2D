using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private float BonusTime = 0;// счетчие времени жизни бонуса [сек* Timestep(0.02 cек)]
    private float MaxBonusTime = 10f;//максимальное  время жизни бонуса [сек]

    //
    private bool BonusActive = false; //индикатор активности бонуса
    private bool infinitieJump = false; //Бесконечный прыжок
    public bool isFlying = false; //Полет

    

    //
    Rigidbody2D rb2d;
    //Animation anim;

    public uiScript ui;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //ui = new uiScript();
    }

    private void Update()
    {
        if (!ui.isDead && !ui.isPaused)
        {

            //проверка прыжка
            if (Input.GetButtonDown("Jump") || (Input.touchCount > 0))//прыжок при нажатии пробела или тачскрина
            { Jump();}

            if (rb2d.position.y < -20) //проверка на выпадание за экран
            {
                ui.Death();
            }
            //взятие напраления для полета
            if(isFlying)
            {
                if(Input.GetAxis("Vertical") != 0)
                {
                    VerticalAxis = Input.GetAxis("Vertical");
                }
                else
                {
                    VerticalAxis = ui.joystick.Vertical;
                }
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (!ui.isDead && !ui.isPaused)
        {
            BonusCheck();//проверка бонусов
            Move();//движение
        }
    }

    private void Move()
    {
        if (isFlying)
        {
            rb2d.velocity = new Vector2(MovementSpeed * 10f, VerticalAxis * FlyingSpeed * 10f);   
        }
        else
        {
            rb2d.velocity = new Vector2(MovementSpeed * 10f, rb2d.velocity.y); 
        }
        MovementSpeed += 0.0001f;//постепенное увеличение скорости движения }
    }

    //метод прыжка
    public void Jump()
    {
        
        if((JumpNum < MaxJumpNums || infinitieJump) && (!isFlying))
        {
            
            rb2d.AddForce(new Vector2(rb2d.velocity.x + JumpDistance, JumpForce *10f + Time.fixedDeltaTime ), ForceMode2D.Impulse);
            JumpNum++;
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
            ui.BonusesText.SetText("Fly Bonus!"); //вывод названия бонуса на экран
            ui.BonuseScreen.SetActive(true);
            ui.jumpButton.SetActive(false);//кнопка прыжка неактивна
            ui.flyJoystick.SetActive(true);//джойстик полета активен
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
        else if (collision.gameObject.tag == "JumpBonus") //если подобрали бонус полёта
        {
            Debug.Log("БОНУС ПОДОБРАН");
            DisableBonuses();//вызов отключения остальных бонусов
            infinitieJump = true;//включение бесконечного прыжка
            BonusActive = true;
            ui.BonusesText.SetText("Infinite Jump Bonus!");//вывод названия бонуса на экран
            ui.BonuseScreen.SetActive(true);
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
    }

    private void BonusCheck()
    {
        if(BonusActive && BonusTime < MaxBonusTime) //проверка наличия бонуса и не истекло ли время его жизни
        {
            BonusTime += 0.02f;//обновляем текущее врямя бонуса
        }
        else if(BonusTime>MaxBonusTime)
        {
            DisableBonuses();//отключаем бонус если время его жизни вышло
        }
    }

    private void DisableBonuses() //функция отключения всех бонусов
    {
        BonusActive = false;
        isFlying = false;
        infinitieJump = false;
        BonusTime = 0;
        ui.flyJoystick.SetActive(false);
        ui.BonuseScreen.SetActive(false);
        ui.jumpButton.SetActive(true);
    }

   
   
}
