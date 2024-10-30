using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEditor;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int playSceneIndex = 1;

    public void OpenPlayScene()
    {
        SceneManager.LoadScene(playSceneIndex);
    }

    public void OpenScene(int numb)
    {
        SceneManager.LoadScene(numb);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;


#else
         Application.Quit();
#endif
    }
}
