﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public string[] sentences; // 文章を格納する

    public GameObject se;
    [SerializeField] Text uiText;   // uiTextへの参照

    [SerializeField][Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

    private int currentSentenceNum = 0; //現在表示している文章番号
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数


    void Start () {
        SetNextSentence ();
        Instantiate(se, this.transform.position, Quaternion.identity);
    }
    

    void Update () {
        // 文章の表示完了 / 未完了
        if (IsDisplayComplete ()) {
            //最後の文章ではない & ボタンが押された
            //if (currentSentenceNum < sentences.Length && Input.GetKeyUp (KeyCode.Space)) {
            if (currentSentenceNum < sentences.Length && Input.GetMouseButtonUp(0)) {
                SetNextSentence ();

            }
        } else {
            //ボタンが押された
            //if (Input.GetKeyUp (KeyCode.Space)) {
            if (Input.GetMouseButtonUp(0) ) {
                timeUntilDisplay = 0; //※1
            }
        }

        //表示される文字数を計算
        int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
        //表示される文字数が表示している文字数と違う
        if (displayCharCount != lastUpdateCharCount) {
            uiText.text = currentSentence.Substring (0, displayCharCount);
            //表示している文字数の更新
            lastUpdateCharCount = displayCharCount;
        }
    }

    // 次の文章をセットする
    void SetNextSentence(){
        Instantiate(se, this.transform.position, Quaternion.identity);
        currentSentence = sentences [currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete(){
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }
}
