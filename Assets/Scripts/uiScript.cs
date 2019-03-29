using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class uiScript : MonoBehaviour
{
   // public Rigidbody2D rb2d;

    public GameObject PauseMenu;
    public GameObject onGame;
    public GameObject ScoreScreen;
    bool isPaused = false ;

    public float score;

    public AudioMixer audio;
    public TextMesh ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = ScoreScreen.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
        AddPoints(0.01f);
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

    public void AddPoints(float points)
    {
        score += points;
        ScoreText.text= Mathf.Round(score).ToString();
    }
}
