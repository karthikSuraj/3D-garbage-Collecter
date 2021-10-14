using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed=12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    private int TrashInHand, TrashDumped;
    [SerializeField] GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        controller.detectCollisions = true;
    }

    // Up
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform .right*x+ transform.forward*z;
        controller.Move(move* speed* Time.deltaTime);
        
        controller.Move(velocity * Time.deltaTime);
        if(controller.transform.position.y<=0.3f)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        gameManage.Instance.trashDeployed = TrashDumped;
        gameManage.Instance.TrashCollected = TrashInHand;



    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Trash"))
        {
            TrashInHand += 1;
           hit.gameObject.SetActive(false);
        }

        if (hit.gameObject.CompareTag("trashCan"))
        {
            TrashDumped +=TrashInHand;
            TrashInHand = 0;
           
        }

        if (hit.gameObject.CompareTag("deployer"))
        {
            gameover.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            speed = 0;
        }

        }
    }
