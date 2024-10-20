using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicEnd : MonoBehaviour
{
    public PlayableDirector director; // Asigna aquí el PlayableDirector desde el Inspector
    public string menuSceneName = "MenuScene"; // Nombre de la escena del menú

    void Start()
    {
        // Suscribirse al evento cuando termine el Timeline
        director.stopped += OnCinematicEnd;
    }

    void OnCinematicEnd(PlayableDirector director)
    {
        // Cambia a la escena del menú
        SceneManager.LoadScene(menuSceneName);
    }

    void OnDestroy()
    {
        // Desuscribirse para evitar posibles errores
        director.stopped -= OnCinematicEnd;
    }
}

