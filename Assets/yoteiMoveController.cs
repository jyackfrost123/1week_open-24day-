using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoteiMoveController : MonoBehaviour
{

    public GameObject centerSchedule;

    public GameObject myselfPrefub;

    public GameObject explosionPrefubs;

    public UIController ui;

    public GameObject hitSE;

    scheduleGeneratorController　schedule;

    SpriteRenderer sprite;

    public Sprite[] damageSprites;

    public Vector3 diffPos;

    public float getTime;

    public int addscore = 1;

    public int numOfDeath;
    
    public int base_numOfDeath;

    float deleteTime= 0.0f;
    // Start is called before the first frame update
    void Start()
    {

        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        sprite = GetComponent<SpriteRenderer>();
        base_numOfDeath = numOfDeath;

        schedule = GameObject.Find("ScheduleGenerator").GetComponent<scheduleGeneratorController>();

        centerSchedule = GameObject.Find("Date");
        diffPos = this.transform.position - centerSchedule.transform.position;
        
        diffPos = new Vector3(diffPos.x, diffPos.y, Random.Range(0.0f, -0.1f) );
        deleteTime = getTime + Random.Range(-1.0f, 1.0f);
        diffPos = diffPos/( (deleteTime)*60.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ui.isGameStart == true){
            transform.Translate(-diffPos);
            deleteTime -= Time.deltaTime;
        }


        if(ui.isClearedforExplosion == true){
            Destroy(this.gameObject);
            Instantiate(explosionPrefubs, this.transform.position, Quaternion.identity);
        }
    }

    public void ClickedThisObject(){
        numOfDeath--;
        ui.AddScore(addscore);
        Instantiate(hitSE, new Vector3(0,0,0), Quaternion.identity);


        if(numOfDeath <= 0){
            //int i = Random.Range(0, schedules.Length);
            //生成を別所で行うべき？
            //float cita = Random.Range(-90.0f, 90.0f) * Mathf.Deg2Rad;
            //GameObject newObj = Instantiate(myselfPrefub, new Vector3(12.5f * Mathf.Sin(cita), 12.5f * Mathf.Cos(cita), this.transform.position.z), Quaternion.identity);
            //newObj.GetComponent<yoteiMoveController>().getTime -= 0.1f;
            schedule.GeneratePointSchedule(base_numOfDeath - 1, getTime);

            if(deleteTime >= 0.0f){
                ui.AddScore((int)deleteTime);
            }


            Destroy(this.gameObject);
        }else{
            sprite.sprite = damageSprites[numOfDeath-1];
            //ui.AddScore(addscore);
        }

    }
}
