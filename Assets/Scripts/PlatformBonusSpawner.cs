using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBonusSpawner : MonoBehaviour
{
    public GameObject[] BonusObj;
    // Start is called before the first frame update
    void Start()
    {
        float chance = Random.Range(1, 100);
        Transform platform = GetComponent<Transform>();
        if (chance > 90)
        {
            GameObject bonus = Instantiate(BonusObj[Random.Range(0, BonusObj.Length)], new Vector2(platform.position.x, platform.position.y + 1f), Quaternion.identity) as GameObject;
            bonus.transform.parent = transform;
        }
        
    }
}
