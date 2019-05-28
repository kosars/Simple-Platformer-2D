using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform CamTransform;
    public GameObject target;// обьект следования камеры
    
    public Vector2 pos; // позиция камеры относительно персонажа;
    private Vector2 targetPos;
    public float maxHeight = 10f; //максимальная позиция, на которую может подняться камера
    public float minHeight= -10f;//максимальная позиция, на которую может опуститься камера

    // Start is called before the first frame update
    void Start()
    {
         //CamTransform = GetComponent<Transform>();
         GameObject JumpBlocker = GameObject.Find("JumpBlocker");
         JumpBlocker.transform.position = new Vector2(0, maxHeight + 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        //обновление текущей позиции обьекта слежения
        targetPos = target.transform.position;
        //обновление текущей позиции камеры
        if(targetPos.y> maxHeight || targetPos.y<minHeight)
        {
            CamTransform.position = new Vector3((targetPos.x + pos.x), CamTransform.position.y, -1);
        }
        else
        {
            CamTransform.position = new Vector3((targetPos.x + pos.x) + Time.fixedDeltaTime, (targetPos.y + pos.y) + Time.fixedDeltaTime, -1);
        }
        
    }


}
