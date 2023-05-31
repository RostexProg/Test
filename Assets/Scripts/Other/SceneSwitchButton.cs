using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour
{
    public string sceneName; // Имя сцены, на которую нужно перейти

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

