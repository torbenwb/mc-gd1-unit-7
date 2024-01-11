using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance { get; private set; }
    static Vector3 defaultPosition;
    static float shakeTime = 0f;
    static float shakeSeverity = 0.05f;

    private void Awake()
    {
        instance = this;
        defaultPosition= transform.position;
    }

    public static void CameraShake()
    {
        shakeTime = GameManager._gameSettings.cameraShakeTime;
        shakeSeverity = GameManager._gameSettings.cameraShakeStrength;
    }


    private void Update()
    {
        if (shakeTime > 0f)
        {
            shakeTime -= Time.deltaTime;
            transform.position += new Vector3(
                Random.Range(-shakeSeverity, shakeSeverity),
                Random.Range(-shakeSeverity, shakeSeverity),
                Random.Range(-shakeSeverity, shakeSeverity));
            if (shakeTime <= 0f)
            {
                shakeTime = 0f;
                transform.position = defaultPosition;
            }
        }
    }
}
