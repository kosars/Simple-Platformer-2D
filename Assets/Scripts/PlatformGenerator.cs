using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Character;

    public Transform CharacterTransform;
    private Vector2 CharacterPosition;

    //колво спавна платформ
    public int numberOfPlatforms = 10;
    //высота спавна платформ
    public float levelHeight = 10;
    //ширина спавна платформ
    public float minX = 3;
    public float maxX = 6;

    //хранение последней позиции персонажа
    private Vector2 LastPosition;

    private void Start()
    {
        CharacterTransform = Character.GetComponent<Transform>();

        //обнуление переменных
        LastPosition = new Vector2(0, 0);

    }

    private void Update()
    {
        //обновление текущей позиции персонажа
        CharacterPosition = CharacterTransform.position;
        Debug.Log(CharacterPosition.x);

        //спавн платформ если позиция больше последней
        if (CharacterPosition.x >= LastPosition.x)
        {
            LastPosition.x = CharacterPosition.x + (maxX-minX);
            Debug.Log("Spawned");
            //Вызов спавна платфом
            SpawnPlatforms(LastPosition.x);
        }
    }
    
    //метод спавна платформ относительно Х
    private void SpawnPlatforms(float posX)
    {
        Vector2 spawnPosition = new Vector2();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.x += Random.Range( posX + minX, posX + maxX);
            spawnPosition.y = Random.Range(-levelHeight, levelHeight);
            Instantiate(Platform, spawnPosition, Quaternion.identity);
        }
    }
}
