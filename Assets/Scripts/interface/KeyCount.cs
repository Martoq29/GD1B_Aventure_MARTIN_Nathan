using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    public static KeyCount instance;

    public TMP_Text KeyText;
    public int currentKeys = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        KeyText.text = "Key: " + currentKeys.ToString();
    }

    public void IncreaseKeys(int v)
    {
        currentKeys += v;
        KeyText.text = "Key: " + currentKeys.ToString();
    }
}
