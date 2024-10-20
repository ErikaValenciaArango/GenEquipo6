using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Playables;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Main Panel")]
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject OptionPanel;
    [Header("Options Panel Game")]
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] TMP_Text CoinsCollected;
    [SerializeField] AudioClip levelMusic;
    public bool gameOver;

    [SerializeField]  int items;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;

    }

    //------------------------------ menu principal y camaras---------------------------------------------------------
       

    public void OptionsPanel()
    {
        if (gameOver == true)
        {
            return;
        }
        Time.timeScale = 0;
        //MainPanel.SetActive(false);
        OptionPanel.SetActive(true);
        //currentView = views[2];

    }

   /* public void Levelselect()
    {
        MainPanel.SetActive(false);
        LevelPanel.SetActive(true);
        currentView = views[1];

    }
   */
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

       
   
    //------------------------------ menu opciones y game Over ---------------------------------------------------------

    public void OptionsPanelGame()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
     //   PanelTime.SetActive(false);
    }

    public void gamePanel()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
       // PanelTime.SetActive(false);
        Debug.Log("gamePanel");
    }


    public void playAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PanelTime.SetActive(true);
        Debug.Log("Again!!");

    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        //PanelTime.SetActive(true);
        Debug.Log("return");
    }

  /*  public void SaveAndExit()
    {

        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("ItemsSave", items);
        LevelName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("sceneName", LevelName);
        PlayerPrefs.Save();

    }*/

    public void Settings()
    {
        //  opciones de sonido y video
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
       // PanelTime.SetActive(false);
        Debug.Log("opciones");
    }

    public void goBack(){
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        Debug.Log("return");
    }
    
    public void goMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.DeleteAll();

    }

    public void QuitGame()
    {
        Debug.Log("Saliiiiir");
        Application.Quit();
    }

    /*public void loadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }*/




    //------------------------------ Items ---------------------------------------------------------

    //Coins

    public void TotalCoins()
    {
        items += 5;
        PlayerPrefs.SetInt("ItemsSave", items);
        CoinsCollected.text = items.ToString();
        Debug.Log("coin");

    }
    /*    public void TotalCoinsSmall()
        {
            items++;
            PlayerPrefs.SetInt("ItemsSave", items);
            CoinsCollected.text = items.ToString();
            Debug.Log("coin");

        }
    */

    //--------------------------------------------Director / Timeline------------------------------------------------

    public void GameOverPanel()
    {
        Invoke("Pause", 1);
        gameOverPanel.SetActive(true);
        gameOver = true;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

}
