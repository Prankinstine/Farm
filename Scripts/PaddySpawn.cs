using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddySpawn : MonoBehaviour
{
    public GameObject paddy;   // The paddy prefab to instantiate
    public Transform spawnPoint;     // The location where paddy will spawn
    private GameObject currentPaddy; // Holds the current spawned paddy
    public float period = 5f, Offset=3f;
    private int waterlevel;
    private void Start()
    {
        waterlevel = 2;
        StartCoroutine(SpawnPaddyRoutine());
    }

    private IEnumerator SpawnPaddyRoutine()
    {
        while (true)
        {
                if (currentPaddy == null && iswatered()) // Checks if the spawn point is empty
                {
                    yield return new WaitForSeconds(period); // Wait 10 seconds
                    currentPaddy = Instantiate(paddy, gameObject.transform.position + new Vector3(0, Offset, 0), Quaternion.identity);
                    waterlevel--;
                }

                yield return null; // Wait until next frame before checking again
            
        }
    }
    private bool iswatered()
    {
        return (waterlevel > 0);
    }
    public void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("player") && Input.GetKey(KeyCode.Y))
        {
            Debug.Log("watered drysoil");
            waterr();
        }
    }
    public void waterr()
    {
        waterlevel = GameController.instance.TryWater(waterlevel);
    }
}
