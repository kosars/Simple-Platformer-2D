using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //направления
    private float VerticalAxis; 
    private float HorizontalAxis;
    

    //флаги
    public bool isJumped = false;
    public bool isDead = false;
    public bool isPaused = false;

    //
    public Rigidbody2D rb;
    public uiScript ui;
    public Movement move;
    public BonusSystem bs;

    
    void Start()
    {
        
    }

    void Update()
    {
        MovementUpdate();
        if (rb.position.y < -20) //проверка на выпадание за экран
        {
            ui.Death();
            isDead = true;
        }
    }

    private void MovementUpdate()
    {
        if (!isDead && !isPaused)
        {
            move.ConstantMove(rb);
            move.JumpFixer(rb);
            if (bs.isFlying)                           {FlyInput();}
            else if (!isJumped || bs.infinitieJump)    {JumpInput();}
        }
    }

    public void FlyInput()
    {
        if (Input.GetAxis("Vertical") != 0) 
        {
            VerticalAxis = Input.GetAxis("Vertical");
        }
        else
        {
            VerticalAxis = ui.joystick.Vertical;
        }
        move.Fly(rb, VerticalAxis);
    }

    public void JumpInput()
    {
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0))
        {
            move.VelocityJump(rb);
            isJumped = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            isJumped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FlyBonus") //если подобрали бонус полёта
        {
            Debug.Log("БОНУС ПОЛЁТА");
            bs.FlyBonus();
            bs.isFlying = true;//включение полета
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
        else if (collision.gameObject.tag == "JumpBonus") //если подобрали бонус полёта
        {
            Debug.Log("БОНУС ПРЫЖКА");
            bs.JumpBonus();
            bs.infinitieJump = true;//включение бесконечного прыжка
            GameObject.Destroy(collision.gameObject, 0); //уничтожение триггера
        }
    }
}
