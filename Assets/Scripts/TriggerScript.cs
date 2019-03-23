using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject Trigger;
    
    public Vector2 TriggerPosition;//хранение позиции триггера спавна
    [Range(0f, 100f)] [SerializeField] public float TriggerDistance; //расстояние спавна триггера




    private void Start()
    {
        TriggerPosition = Trigger.transform.position;
    }

    private void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("TriggerEntered");
        if (coll.gameObject.tag == "SpawnTrigger" )
        {
            TriggerPosition.x += TriggerDistance; //обновление позиции триггера
            GameObject.Destroy(coll.gameObject,0); //уничтожение триггера
            Instantiate(Trigger, TriggerPosition, Quaternion.identity); //создание нового триггера
        }
    }



}

