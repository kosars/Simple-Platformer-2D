using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpForce;
    public float jumpVelocity;
    public float movementSpeed;
    public float flySpeed;

   


    //метод прыжка
    public void ForceJump(Rigidbody2D rb)
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce * 10f), ForceMode2D.Impulse);
    }
    public void VelocityJump(Rigidbody2D rb)
    {
        rb.velocity += Vector2.up * jumpVelocity;
    }

    public void JumpFixer(Rigidbody2D rb)
    {
        if (rb.velocity.y < 0) //если тело падает, то скорость его падения увеличится
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump") && (Input.touchCount < 1) ) //если прыжок больше не нажат,заставляет тело падать
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
    }

    public void ConstantMove(Rigidbody2D rb) //метод для постоянного движения
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    public void Move(Rigidbody2D rb, float Axis)
    {
        rb.velocity += Vector2.right * movementSpeed;
    }

    public void Fly(Rigidbody2D rb,float Axis)//скорость по оси y влияет только направление
    {
        rb.velocity = new Vector2(rb.velocity.x, Axis * flySpeed);
    }
    
}
