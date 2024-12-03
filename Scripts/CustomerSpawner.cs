using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    // Start is called before the first frame update // The paddy prefab to instantiate
    private GameObject currentPaddy; // Holds the current spawned paddy
    public float period = 10f, Offset = 3f;
    private int maxCustomer;
    private void Start()
    {
        maxCustomer = 3;
        StartCoroutine(SpawnPaddyRoutine());
    }

    private IEnumerator SpawnPaddyRoutine()
    {
        while (true)
        {
            if (currentPaddy == null && NotMax()) // Checks if the spawn point is empty
            {
                yield return new WaitForSeconds(period); // Wait 10 seconds
                currentPaddy = Instantiate(Customermanager.instance.Customer, gameObject.transform.position + new Vector3(0, Offset, 0), Quaternion.identity);
                GameController.instance.CustomerCount++;
            }

            yield return null; // Wait until next frame before checking again

        }
       
    }
    public bool NotMax()
    {
        return(GameController.instance.CustomerCount<maxCustomer);
    }

    // Update is called once per frame

    
}
