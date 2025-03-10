using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VirtualJoystickUI : MonoBehaviour
{
    [Header("UI References")]
    private RectTransform joystickBG;
    private RectTransform joystickHandle;

    [Header("Joystick Settings")]
    public float joystickMaxOffset = 50f;

    public float virtualJoystickOffsetX = 0f;

    void OnEnable()
    {
        GameObject bgObject = GameObject.FindGameObjectWithTag("JoystickBG");
        GameObject handleObject = GameObject.FindGameObjectWithTag("JoystickHandle");

        if (bgObject == null)
        {
            Debug.LogError("JoystickBG not found! Check if the tag is set correctly.");
        }
        else
        {
            joystickBG = bgObject.GetComponent<RectTransform>();
        }

        if (handleObject == null)
        {
            Debug.LogError("JoystickHandle not found! Check if the tag is set correctly.");
        }
        else
        {
            joystickHandle = handleObject.GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        float normalizedHorizontal = virtualJoystickOffsetX / joystickMaxOffset;
        normalizedHorizontal = Mathf.Clamp(normalizedHorizontal, -1f, 1f);

        joystickHandle.anchoredPosition = new Vector2(normalizedHorizontal * joystickMaxOffset, 0f);
    }
}