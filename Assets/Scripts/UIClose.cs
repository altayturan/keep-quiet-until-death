using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Invoke("Close", 3.5f);
            GetComponent<Animator>().SetTrigger("Close");
        }

    }
    void Close() { Destroy(gameObject); }
}
