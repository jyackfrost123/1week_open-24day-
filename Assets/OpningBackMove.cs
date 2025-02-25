using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追加し忘れ注意


public class OpningBackMove : MonoBehaviour
{
    private RectTransform hoge;
    public float x,y,z;
    // Start is called before the first frame update
    void Start()
    {
      hoge = this.GetComponent<RectTransform>();
      
      //hoge.localPosition=new Vector3(x,y,z);　//動いた！
    }

    // Update is called once per frame
    void Update()
    {
        //hoge.Translate(0.0f, 0.1f, 0.0f);
        hoge.localPosition +=new Vector3(0,-1.0f,0);　//動いた！
        if(hoge.localPosition.y <= -270.0f){
            hoge.localPosition = new Vector3(this.transform.localPosition.x, 270.0f, this.transform.localPosition.z);
        }
    }
}
