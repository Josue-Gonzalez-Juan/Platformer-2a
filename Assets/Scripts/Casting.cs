using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Casting : MonoBehaviour
{
    
    public float rayLength;
    public LayerMask layermask;
    public Text coinDisplay;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                print(hit.collider.name);
                if (hit.collider.name == "Brick(Clone)")
                {
                    Destroy(hit.collider.gameObject);
                }else if (hit.collider.name == "QuestionBox(Clone)")
                {
                    coins++;
                    coinDisplay.text = "x" + coins.ToString();
                }
            }
        }
    }
}
