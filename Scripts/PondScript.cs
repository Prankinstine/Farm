using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") && Input.GetKey(KeyCode.Y))
        {
            GameController.instance.fillbucket();
        }
    }
}
