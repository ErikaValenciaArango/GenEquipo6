using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject SettingsPanel;

   

   
   void Start()
   {
       SettingsPanel.SetActive(false);
   }
   public void OptionsPanel()
    {

        //MainPanel.SetActive(false);
        MenuPanel.SetActive(true);
       

    }
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void Settings()
    {
        //  opciones de sonido y video
        optionsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        //PanelTime.SetActive(false);
        Debug.Log("opciones");
    }
    public void quit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void back(){
        optionsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        Debug.Log("return");
    }
}
