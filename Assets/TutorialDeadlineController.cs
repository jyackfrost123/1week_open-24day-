using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDeadlineController : MonoBehaviour
{
    public float barSpeed = 2.00f;

    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(){}//ゲームスタート
        
            time += Time.deltaTime;
            transform.Translate(new Vector3(0.0f, -barSpeed/60.0f, 0.0f));

        if(this.transform.position.y <= -4.6){
            this.transform.position = new Vector3(this.transform.position.x + 2.0f, 3.35f, -4.0f);
            if(this.transform.position.x >= 1.0) this.transform.position = new Vector3(-6.05f, 3.35f, -4.0f);
        }



    }
}
