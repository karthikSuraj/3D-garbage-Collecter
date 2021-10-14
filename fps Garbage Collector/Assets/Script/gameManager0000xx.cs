using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    public int PlayerSpeed;
    public int CameraSensitivity;
    public int TrashCollected; 
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
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            eventManager.buttonPress += printPressed;
            StartCoroutine(timer());
        }
    }
    void printPressed()
    {
        Debug.LogError("Space Button Pressed");
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
        eventManager.buttonPress -= printPressed;
    }
}
