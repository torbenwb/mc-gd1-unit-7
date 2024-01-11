using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObjectActive : MonoBehaviour
{
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
