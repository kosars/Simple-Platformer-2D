using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    
    private void FixedUpdate()
    {
        //уничтожение пустых гейм-обьектов, которые остаются после уничтожения через колижнэнтер и триггерэнтер
        
        GameObject DestroyObj = GameObject.Find("New Game Object");
        Destroy(DestroyObj);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //уничтожение обьектов которые сталкиваются с обьектдестроером
        GameObject DestroyObj = new GameObject();
        DestroyObj = collision.gameObject;

        Destroy(DestroyObj);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //уничтожение обьектов которые сталкиваются с обьектдестроером
        GameObject DestroyObj = new GameObject();
        DestroyObj = collision.gameObject;

        Destroy(DestroyObj);

    }*/
}
