using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetect : MonoBehaviour
{
    public static int buttonDoor1;
    public static int buttonDoor2;
    public static int keyGet;
    public GameObject door1;
    public GameObject door2;

    // Start is called before the first frame update
    void Start()
    {
        buttonDoor1 = 0;
        buttonDoor2 = 0;
        keyGet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "Button1" && Input.GetButtonDown("Jump"))
            {
                buttonDoor1 = 1;
            }
            else if (hit.collider.gameObject.name == "Button2" && Input.GetButtonDown("Jump"))
            {
                buttonDoor2 = 1;
            }
        }
        if (buttonDoor1 == 1)
        {
            Vector3 posChange1 = door1.transform.position;
            posChange1.y -= 0.1f;
            door1.transform.position = posChange1;
        }
        if (buttonDoor2 == 1 && keyGet == 1)
        {
            Vector3 posChange2 = door2.transform.position;
            posChange2.y -= 0.1f;
            door2.transform.position = posChange2;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.collider.gameObject.name == "key")
        {
            keyGet = 1;
            Destroy(other.gameObject);
        }


    }
}