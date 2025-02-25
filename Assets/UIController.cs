using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text killMyselfText;

    public GameObject wroteText;
    public GameObject wroteTextBox;
    public GameObject buttons;

    public GameObject clears;
    public GameObject snowBack;

    public ButtonController buttonScore;

    public int score = 0;

    public dateController data;

    public bool isClearedforExplosion = false;
    public bool isGameOverforLast = false;

    public bool isGameStart = false;

    float time = 0;

    float gameStartTime = 4.2f;

    public bool isKillmyself  = false;

    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(false);
        clears.SetActive(false);
        snowBack.SetActive(false);
        gameOverText.text = "";
        killMyselfText.text = "";

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isClearedforExplosion = data.isClear;
        isGameOverforLast = data.isGameOver;
        scoreText.text = "Score\n"+score;

                

        if(isGameStart != true){

            gameStartTime -= Time.deltaTime;

            if(gameStartTime <= 1.0f){
                isGameStart = true;
            }
            
            gameOverText.text = ""+ (int)gameStartTime;



        }else{
            if(gameStartTime >= -0.5f){
                gameStartTime -= Time.deltaTime;
               if(gameStartTime >= 0.0f){
                gameOverText.text = "Start!";
               }else{
                 gameOverText.text = "";
               }
            }else{
              if(isClearedforExplosion == false && isGameOverforLast == false){
                gameOverText.text = "";
              }

            }
        }

        if( (isGameOverforLast == true || data.isClear == true)&& buttons.activeSelf != true ){

            if(time >= 1.0f && buttons.activeSelf != true){
             buttons.SetActive(true);
            }else{
             time += Time.deltaTime;
            }

             if(isGameOverforLast == true){
                 if(isKillmyself == true){
                    //gameOverText.text = "";
                    killMyselfText.text = "彼女との約束を、\nキャンセルしてしまった。";
                 }else{
                    gameOverText.text = "リア充爆発！";
                 }

                 //Score送信
                 if(SceneManager.GetActiveScene().name == "EndressGameScene"){
                    UnityroomApiClient.Instance.SendScore(2, (float)score, ScoreboardWriteMode.Always);
                 }else{
                    UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.Always);
                 }
                 
             }else if(isClearedforExplosion == true && clears.activeSelf == false){
                 clears.SetActive(true);
                 snowBack.SetActive(true);
                 wroteText.SetActive(false);
                 wroteTextBox.SetActive(false);
                 //Score送信
                 UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.Always);
             }
        }
    }

    public void AddScore(int add){
        if(isGameOverforLast != true && data.isClear != true){
            score += add;
        }
    }

    public void GoResult(){
        buttonScore.goResult(score);
    }

    public void Go2ndResult(){
        buttonScore.go2ndResult(score);
    }

    public void GoTweet(){
        
        if(isKillmyself == true){
            naichilab.UnityRoomTweet.Tweet ("24th_schedule", score+"個の予定を断ったが、彼女とのデートは爆発した。", "24日夜あいてますか", "unity1week");
        }else if(isGameOverforLast == true){
            naichilab.UnityRoomTweet.Tweet ("24th_schedule", score+"個の予定を断ったが、予定は空かずリア充は爆発した。", "24日夜あいてますか", "unity1week");
        }else{
            naichilab.UnityRoomTweet.Tweet ("24th_schedule", score+"個の予定を断り、彼女とのデートを守った。", "24日夜あいてますか", "unity1week");
        }

    }

    public void Go2ndTweet(){
        if(isKillmyself == true){
            naichilab.UnityRoomTweet.Tweet ("24th_schedule", score+"個の予定を断ったが、彼女とのデートは爆発した。", "24日夜あいてますか", "unity1week");
        }else{
            naichilab.UnityRoomTweet.Tweet ("24th_schedule", "彼女のため、"+score+"個の予定を断った。", "24日夜あいてますか", "unity1week");
        }
    }
}
