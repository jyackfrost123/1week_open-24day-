using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dateController : MonoBehaviour
{

    SpriteRenderer sprite;

    public Sprite[] gameOverSprites;
    
    public bool isGameOver = false;

    public bool isClear = false;

    public GameObject explosionPrefub;
    public GameObject explosionSE;

    public int deathDate = 10;

    public UIController ui;

    public Sprite[] deathSprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit!");
        if(other.gameObject.tag == "enemy" && isGameOver == false){
            //Destroy(this.gameObject);
            Instantiate(explosionPrefub, this.transform.position, Quaternion.identity);
            Instantiate(explosionSE, this.transform.position, Quaternion.identity);
            //Debug.Log(other.gameObject.GetComponent<yoteiMoveController>().base_numOfDeath - 1);
            sprite.sprite = gameOverSprites[other.gameObject.GetComponent<yoteiMoveController>().base_numOfDeath - 1];
            isGameOver = true;
        }else if(isGameOver != true && other.gameObject.tag == "deadline"){
            isClear = true;
            Instantiate(explosionSE, this.transform.position, Quaternion.identity);
        }

    }

    public void DeathTouch(){


        if( ui.isClearedforExplosion == false && ui.isGameOverforLast == false){
            deathDate--;
            if(deathDate > 0){
               sprite.sprite = deathSprite[ (deathDate) / 2];
            }

            if(deathDate == 0){
             Instantiate(explosionPrefub, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.5f), Quaternion.identity);
             Instantiate(explosionSE, this.transform.position, Quaternion.identity);
             //Debug.Log(other.gameObject.GetComponent<yoteiMoveController>().base_numOfDeath - 1);
             sprite.sprite = null;
             //sprite.sprite  = gameOverSprites[1];//演出用
             isGameOver = true;
             ui.isKillmyself = true;
        }
        }

 

    }


}
