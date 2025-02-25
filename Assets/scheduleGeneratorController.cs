using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;


public class scheduleGeneratorController : MonoBehaviour
{
    public GameObject[] schedules;

    public float areaR = 10.5f;
    public float decreaseSpeed = 0.1f;

    public UIController ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        InvokeRepeating ("GenerateSchedule", 10f, 7f);        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void GenerateSchedule(){
        if(ui.isClearedforExplosion == false && ui.isGameOverforLast == false){
           int i = Random.Range(0, schedules.Length);

           float cita = Random.Range(-90.0f, 90.0f) * Mathf.Deg2Rad;
           Instantiate(schedules[i], new Vector3(areaR * Mathf.Sin(cita), areaR * Mathf.Cos(cita), this.transform.position.z), Quaternion.identity);
           //Instantiate(schedules[i], new Vector3(0,0,0));
        }

    }

    public void GeneratePointSchedule(int num, float getforTime){
        if(ui.isClearedforExplosion == false && ui.isGameOverforLast == false){


        int i = num;

        float cita = Random.Range(-90.0f, 90.0f) * Mathf.Deg2Rad;
        //Instantiate(schedules[i], new Vector3(areaR * Mathf.Sin(cita), areaR * Mathf.Cos(cita), this.transform.position.z), Quaternion.identity);
        //Instantiate(schedules[i], new Vector3(0,0,0));
        GameObject newObj = Instantiate(schedules[i], new Vector3(12.5f * Mathf.Sin(cita), 12.5f * Mathf.Cos(cita), this.transform.position.z), Quaternion.identity);
        
        if(newObj.GetComponent<yoteiMoveController>().getTime >= 2.9){
            newObj.GetComponent<yoteiMoveController>().getTime = getforTime - decreaseSpeed;
        }

        }
    }
}
