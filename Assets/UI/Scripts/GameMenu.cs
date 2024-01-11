using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI menuMessage;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameMenu = this;
        gameObject.SetActive(false);
    }

    public void SetMessage(string newMessage)
    {
        menuMessage.text = newMessage;
    }
}
