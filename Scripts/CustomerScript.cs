using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private int want,AMT;
    private bool Runn;
    // Start is called before the first frame update
    void Start()
    {
        Runn = true;
        agent = GetComponent<NavMeshAgent>();
        want = Random.Range(0, 1);
        AMT = Random.Range(1, 5);

        Debug.Log($"want=:{want}  AMT=:{AMT}");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Customermanager.instance.Counter.transform.position;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("CCounter") && GameController.instance.demand==7)
        {
            Runn = false;
            GameController.instance.QueueProduct(want,AMT);
            StartCoroutine(Wait());
        }
        else if (collision.gameObject.CompareTag("Terminator"))
        {
            Destroy(gameObject);
            GameController.instance.CustomerCount--;
        } 
    }
    private IEnumerator Wait()
    {
        while (true)
        {
            if(GameController.instance.demand==7)
            {
                agent.destination= Customermanager.instance.Terminator.transform.position;
                Runn = true;
            }
            yield return null;
        }
    }
}