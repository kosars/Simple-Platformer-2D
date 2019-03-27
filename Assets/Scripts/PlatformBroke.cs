using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBroke : MonoBehaviour

{
    void OnCollisionEnter2D(Collision2D collision)
    { 
        Destroy(gameObject, 0.05f);  
    }
}
