using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadLineController : MonoBehaviour
{

    public float barSpeed = 2.00f;

    public float time = 0.0f;

    public UIController ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        //this.transform.position = new Vec
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(){}//ゲームスタート
        
        if(ui.isGameStart == true){
            time += Time.deltaTime;
            transform.Translate(new Vector3(0.0f, -barSpeed/60.0f, 0.0f));
        }

        if(this.transform.position.y <= -4.6){
            this.transform.position = new Vector3(this.transform.position.x + 2.0f, 3.35f, -4.0f);
        }

    }
}
