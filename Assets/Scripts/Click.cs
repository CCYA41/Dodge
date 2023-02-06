using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("클릭작동!");
        GameObject.FindObjectOfType<PlayerCtrl>().PlayerInitialize();
        GameObject.FindObjectOfType<GameManager>().Initialize();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
