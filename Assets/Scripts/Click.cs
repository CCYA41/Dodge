using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("Ŭ���۵�!");
        GameObject.FindObjectOfType<PlayerCtrl>().PlayerInitialize();
        GameObject.FindObjectOfType<GameManager>().Initialize();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
