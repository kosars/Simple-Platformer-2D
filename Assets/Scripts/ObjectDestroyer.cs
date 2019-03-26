using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public Transform target; //цель слежения;
    public float padding = 50f; // отступ от цели слежения по оси х
    private Transform objDestroyer;

    private void Start()
    {
        objDestroyer = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        //уничтожение пустых гейм-обьектов, которые остаются после уничтожения через колижнэнтер и триггерэнтер
        
        GameObject DestroyObj = GameObject.Find("New Game Object");
        Destroy(DestroyObj);
    }
    private void Update()
    {
        objDestroyer.position = new Vector2(target.position.x - padding, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //уничтожение обьектов которые сталкиваются с обьектдестроером
        GameObject DestroyObj = new GameObject();
        DestroyObj = collision.gameObject;

        Destroy(DestroyObj);
    }

}
