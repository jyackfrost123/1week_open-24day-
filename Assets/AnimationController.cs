using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public SpriteRenderer img;

    public Sprite[] anime;

    float time = 0.0f;
    public float changeTime = 0.5f;

    int animePointer = 0;

    //public gameObject 

    public bool isAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        img.sprite = anime[0];
        animePointer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAnimation == true){
         time += Time.deltaTime;
        }
        if(changeTime <= time){
            img.sprite = anime[animePointer];
            animePointer++;

            if(animePointer == anime.Length){
                Destroy(this.gameObject);
                //animePointer = 0;
            }
            time = 0;
        }
    }
}
