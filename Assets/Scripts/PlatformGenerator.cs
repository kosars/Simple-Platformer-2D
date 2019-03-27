using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] Platform;
    public Transform CharacterTransform;
    public Vector2 CharacterPosition;
    //хранение последней позиции персонажа
    public Vector2 LastPosition;
    

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

    //метод спавна платформ относительно Х
    private void SpawnPlatforms(float posX)
    {
        float ChanceOfSpawn; //шанс спавна платформы какого-то типа [%]
        Vector2 spawnPosition = new Vector2();

        for (int i = 0; i < numberOfPlatforms; i++)
         {
            
            //позиция спавна
            spawnPosition.x = Random.Range( posX + minX, posX + maxX);
            spawnPosition.y = Random.Range(-levelHeight, levelHeight);

            ChanceOfSpawn = Random.Range(0, 100); //шанс спавна платформы какого-то типа [%]

            if ((spawnPosition.y) <= (-levelHeight/2)) // если позиция меньше  нижней 1/4 экрана
            {
                

                if (ChanceOfSpawn >= 55)//45% шанс спавна ломающейся платформы
                {
                    Instantiate(Platform[1], spawnPosition, Quaternion.identity);
                }
                else if (ChanceOfSpawn >= 50)//5% шанс спавна ничего
                {

                }
                else//cпавн обыкновенной платформы
                {
                    Instantiate(Platform[0], spawnPosition, Quaternion.identity);
                }
            }

            else if((spawnPosition.y) >= (-levelHeight / 2))// если позиция больше нижней 1/4 экрана
            {
                if (ChanceOfSpawn >= 95)//5% шанс спавна ломающейся платформы
                {
                    Instantiate(Platform[1], spawnPosition, Quaternion.identity);
                }
                else if (ChanceOfSpawn >= 90)//5% шанс спавна ничего
                { }
                else//cпавн обыкновенной платформы
                {
                    Instantiate(Platform[0], spawnPosition, Quaternion.identity);
                }
            }
            
            
        }
    }

}
