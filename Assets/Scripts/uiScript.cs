using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
public class uiScript : MonoBehaviour
{
   // public Rigidbody2D rb2d;

    public GameObject PauseMenu;
    public GameObject onGame;
    public GameObject DeathScreen;
    public GameObject RewardScreen;
    public GameObject BonuseScreen;
    public GameObject jumpButton;
    public GameObject flyJoystick;
    public Joystick joystick;

    public bool isPaused = false ;
    public bool isDead = false;

    public float score;
    public int hiscore;

    //public AudioMixer audio;
    public TextMesh ScoreText;
    public TextMesh DeathScore;
    public TextMesh DeathHiScore;

    public TextMeshProUGUI DeathText;
    public TextMeshProUGUI RewardText;
    public TextMeshProUGUI BonusesText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        hiscore = PlayerPrefs.GetInt("Hiscore");
        RewardScreen.SetActive(false);;
        jumpButton.SetActive(false);//кнопка прыжка неактивна
        flyJoystick.SetActive(false);//джойстик полета активен
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && !isPaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Pause();
            }
            AddPoints(0.01f);
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
        Application.Quit();
    }

    public void AddPoints(float points)
    {
        score += points;

        if (score > hiscore)
        {
            ScoreText.color = Color.red;
        }

        ScoreText.text= Mathf.Round(score).ToString();
    }

    public void Death()
    {   
        isDead = true;
        if (score > hiscore)
        {
            hiscore = Mathf.RoundToInt(score);
            PlayerPrefs.SetInt("Hiscore", hiscore);
            DeathText.SetText("NEW HISCORE!!!");
        }
        else
        {
            DeathText.SetText("TRY AGAIN");
        }
        PauseMenu.SetActive(false);
        onGame.SetActive(false);
        DeathScreen.SetActive(true);
        DeathScore.text = Mathf.Round(score).ToString();
        DeathHiScore.text = hiscore.ToString();
        
    }
}
