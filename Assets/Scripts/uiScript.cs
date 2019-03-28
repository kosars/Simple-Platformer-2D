using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class uiScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject PauseMenu;
    public GameObject onGame;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }

        if (rb2d.position.y < -20) //проверка на выпадание за экран
        {
            Reset();
        }
    }

    public void Pause()
    {
        if(isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            onGame.SetActive(false);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            onGame.SetActive(true);
        }
    }

    public void Reset()
    {
        string scene = SceneManager.GetActiveScene().name;
        //загрузка текущей сцены
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        isPaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        //string scene = SceneManager.;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
