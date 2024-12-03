using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customermanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject Counter;
    [SerializeField]
    public GameObject Terminator;
    [SerializeField]
    public GameObject Customer;
    public static Customermanager instance;
    void Start()
    {
        instance= this;
    }

    // Update is called once per frame
  
}
