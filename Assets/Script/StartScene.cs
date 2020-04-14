using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public void LoadGame()
    {
        Utils.SwitchAndLoadScene(1);
    }
    public void LoadSettingGame()
    {
        Utils.SwitchAndLoadScene(3);
    }
    public void ExitGame()
    {
        Utils.EndApp(1);
    }
}
