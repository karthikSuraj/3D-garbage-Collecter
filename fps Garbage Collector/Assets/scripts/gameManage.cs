using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManage : MonoBehaviour
{
    public static gameManage Instance;



    public int trashDeployed, TrashCollected;
    public Text trashDumped, Trashcollected,finalTrashDumped;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        trashDumped.text = " TRASH DUMPED:" + trashDeployed.ToString();
        Trashcollected.text = " TRASH COLLECTED :" + TrashCollected.ToString();
        finalTrashDumped.text = " TRASH DUMPED:" + trashDeployed.ToString();


    }

   public  void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }
   public void OnClickQuit()
    {
        SceneManager.LoadScene(0);
    }

}

