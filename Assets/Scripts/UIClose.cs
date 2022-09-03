using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Destroy(gameObject);
    }
}
