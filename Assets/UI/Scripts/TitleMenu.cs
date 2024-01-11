using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    public void Play()
    {
        GameManager.NextLevel();
    }

    public void Quit()
    {
        GameManager.Quit();
    }
}
