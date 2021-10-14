using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DeployerGoTo : MonoBehaviour
   
{
    public static DeployerGoTo sharedInstance;
    private List<GameObject> poolobjects;
    [SerializeField]private GameObject[] trash;
    private NavMeshAgent aiDriver;
    public GameObject target1;

    // Start is called before the first frame update

    void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        aiDriver = GetComponent<NavMeshAgent>();

        
        poolobjects = new List<GameObject>();
        for(int i = 0; i< trash.Length;i++)
        {
            GameObject obj = (GameObject)Instantiate(trash[i]);
            obj.transform.position = transform.position + new Vector3(Random.Range(-2.13f, 4.2f), -0.45f, Random.Range(-2.13f, 3.2f));

            obj.SetActive(true);
            poolobjects.Add(obj);
        }

    }

    // Update is called once per frame
    void Update()
    {
        goTO(target1);
        //timer();
        TrashThrow();
        
    }
    public void goTO(GameObject target)
    {
        aiDriver.SetDestination(target.transform.position);
    }

    public GameObject AllocatePoolIteam()
    {
        for (int i = 0; i < trash.Length; i++)
        {
            if (!poolobjects[i].activeInHierarchy)
                return poolobjects[i];

        }
        return null;
    }

    public void TrashThrow() { 
   
        GameObject cloneTrash = DeployerGoTo.sharedInstance.AllocatePoolIteam();

                if (cloneTrash != null)
                {
                    cloneTrash.transform.position = transform.position + new Vector3(0, -0.45f, Random.Range(-2.13f,3.2f));
            


                    cloneTrash.SetActive(true);
                }   
                
    }

    //IEnumerator timer()
    //{
    //    yield return new WaitForSeconds(5);
    //    for (int i = 0; i < trash.Length; i++)
    //    {
    //        if (poolobjects[i].activeInHierarchy)
    //        {
    //            Debug.LogError("SDd");
    //            poolobjects[i].SetActive(false);
    //        }

    //    }

    //}


}
