using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : Singleton<ManageScene>
{
    public void SimulationScene()
    {
        SceneManager.LoadScene(0);
        TouchResponseManager.Instance.ArMode = false;
    }

    public void ArScene()
    {
        SceneManager.LoadScene(1);
        TouchResponseManager.Instance.ArMode = true;

    }
}
