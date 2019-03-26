using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject Platform;
    public Transform CharacterTransform;
    private Vector2 CharacterPosition;
    //хранение последней позиции персонажа
    private Vector2 LastPosition;
    

    //колво спавна платформ
    [Range(0f, 25f)] [SerializeField] public int numberOfPlatforms;
    //высота спавна платформ
    [Range(0f, 25f)] [SerializeField] public float levelHeight;
    //ширина спавна платформ
    [Range(0f, 100f)] [SerializeField] public float minX ;
    [Range(0f, 200f)] public float maxX;

    

    private void Start()
    {
       // Platform = GameObject.Find("Platform");
        GameObject Character =GameObject.Find("Character");
        CharacterTransform = Character.GetComponent<Transform>();
        
        //Debug.Log("START LOG:");
        //Debug.Log("MAX-MIN:");
       // Debug.Log(maxX - minX);

        //обнуление переменных
        LastPosition = new Vector2(0, 0);
        //Debug.Log(LastPosition);
        
    }

    private void FixedUpdate()
    {
        //обновление текущей позиции персонажа
        CharacterPosition = CharacterTransform.position;
        //спавн платформ если позиция больше последней
        if (CharacterPosition.x > LastPosition.x)
        {
            //Debug.Log("_______TRUE _____");
            LastPosition.x +=  (maxX-minX);
            //Вызов спавна платфом
            //SpawnPlatforms(LastPosition.x);
            //NewPlatform(LastPosition.x);
            SpawnPlatforms(LastPosition.x);
        }
    }

    private void NewPlatform(float posx)
    {
        Vector2 spawnPosition = new Vector2(posx, 0);
        Instantiate(Platform, spawnPosition, Quaternion.identity);
       // Debug.Log("PLATFOR HAS BEEN CONSTRUCTED!");
    }





    //метод спавна платформ относительно Х
    private void SpawnPlatforms(float posX)
    {
        Vector2 spawnPosition = new Vector2();

       // Debug.Log("POSITION OF NEW PLATFORM:");
        spawnPosition.x = Random.Range(posX , posX + maxX);
        spawnPosition.y = Random.Range(-levelHeight, levelHeight);
        //Debug.Log(spawnPosition);
        Instantiate(Platform, spawnPosition, Quaternion.identity);
        for (int i = 0; i < numberOfPlatforms; i++)
         {
             spawnPosition.x = Random.Range( posX + minX, posX + maxX);
             spawnPosition.y = Random.Range(-levelHeight, levelHeight);
             Instantiate(Platform, spawnPosition, Quaternion.identity);
             //Debug.Log("Spawn Pos:");
            // Debug.Log(spawnPosition);

         }
        //Debug.Log("PLATFOR HAS BEEN CONSTRUCTED!");
        /* 
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.x = Random.Range(posX + minX, posX + maxX);
            spawnPosition.y = Random.Range(-levelHeight, levelHeight);
            GameObject.Instantiate(Platform);
            Platform.transform.position = spawnPosition;
        }*/
    }

}
