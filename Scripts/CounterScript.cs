using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))

        {
            GameController.instance.Unload();
            Debug.Log("Unload attempted");
        }
    }

}
