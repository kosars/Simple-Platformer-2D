using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject Trigger;
    public uiScript ui;
    
    public Vector2 TriggerPosition;//хранение позиции триггера спавна
    [Range(0f, 100f)] [SerializeField] public float TriggerDistance; //расстояние спавна триггера




    private void Start()
    {
        TriggerPosition = new Vector2(ui.hiscore,0);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("TriggerEntered");
        if (coll.gameObject.tag == "SpawnTrigger" )
        {
            GameObject.Destroy(coll.gameObject,0); //уничтожение триггера
            //Instantiate(Trigger, TriggerPosition, Quaternion.identity); //создание нового триггера
        }
    }



}

