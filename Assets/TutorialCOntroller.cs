using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCOntroller : MonoBehaviour
{

    public GameObject button;
    parametorController para;
    // Start is called before the first frame update
    void Start()
    {
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
         button.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(para.notFirst == true&& button.activeSelf == false){
            button.SetActive(true);
        }
    }
}
