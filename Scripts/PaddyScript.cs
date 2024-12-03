using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PaddyScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))

        {
            GameController.instance.IncreasePaddy();
            Destroy(gameObject);
        }
    }

}
