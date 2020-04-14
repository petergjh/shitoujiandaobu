using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utils
{
    public static void SwitchAndLoadScene(int index)
    {
        //
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
    public static void EndApp(int index)
    {
        Application.Quit();
    }
}
