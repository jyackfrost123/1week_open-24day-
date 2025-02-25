using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追加し忘れ注意


public class EndingMove : MonoBehaviour
{
    private RectTransform hoge;
    public float x;
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
        hoge.localPosition +=new Vector3(x,0.0f,0);　//動いた！
        /*if(hoge.localPosition.y <= -270.0f){
            hoge.localPosition = new Vector3(0, 270.0f, 0);
        }*/
    }
}
