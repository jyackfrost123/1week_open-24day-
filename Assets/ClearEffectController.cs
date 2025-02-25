using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearEffectController : MonoBehaviour
{
    public Image[] images;
    public float alpha = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < images.Length; i++){
           images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, alpha);
       } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(alpha < 185.0f/255.0f){
         alpha += 1.0f/255.0f;

         for(int i = 0; i < images.Length; i++){
           images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, alpha);
         } 

       }
        
    }
}
