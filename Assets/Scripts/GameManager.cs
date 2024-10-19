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
    [Header("Main Panel")]
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject OptionPanel;
  //  [SerializeField] GameObject LevelPanel;
  //  [SerializeField] GameObject CallPanel;

   /* [Header("CameraMenu")]
    [SerializeField] Transform[] views;
    [SerializeField] float transitionSpeed;
    Transform currentView;
*/

    [Header("Options Panel Game")]
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject SettingsPanel;
  /*  [SerializeField] GameObject PanelTime;*/
    [SerializeField] TMP_Text CoinsCollected;

    [SerializeField]  int items;
 
    
/*    [Header("levelsManager")]
    [SerializeField] string LevelName;
   

    [Header("Director")]
    [SerializeField] PlayableDirector playable;
   */


    private void Start()
    {
       // currentView = transform; // cameras

        // Items
        //items = PlayerPrefs.GetInt("ItemsSave");
        Time.timeScale = 1;

    }

    //------------------------------ menu principal y camaras---------------------------------------------------------
       

    public void OptionsPanel()
    {

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

        SceneManager.LoadScene("Menu");
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

   
}
