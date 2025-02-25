using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMusicController : MonoBehaviour
{

    bool changing = false;//曲を変更中かどうか確認

    public int musicNumber = 0;//配列番号

    public float fadeTime;

    public float musicVolume;

    private AudioSource playingSource;//play中の音源

    public AudioClip[] musicLayout;//音楽配列

    //bool gameOver = false;

    bool finishChange = false;

    UIController ui;

    void Awake(){
        playingSource = GetComponent<AudioSource>();
        //playingSource.clip = musicLayout[musicNumber];
    }

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ui.isClearedforExplosion == true && finishChange == false){
            ChangeBGM(0);
            finishChange = true;
        }
    }




        //指定時間フェードアウト、指定時間フェードイン
    public void ChangeBGM(int BGMNum){
        if(!changing && musicNumber != BGMNum){//同じ曲なら変更しない

         AudioClip nextMusic = musicLayout[BGMNum];

         musicNumber = BGMNum;
         StartCoroutine( ChangeMusic(nextMusic, fadeTime) );
        }
    }


     public IEnumerator ChangeMusic(AudioClip nextMusic,float time){
        changing = true;
        yield return null;

        while(this.playingSource.volume > 0){
             FadeOut(time);
            yield return null;
         }

          this.playingSource.Stop();
          yield return null;

          this.playingSource.clip = nextMusic;
          yield return null;

         while(this.playingSource.volume < musicVolume){//BGMなので音量半分くらい
             FadeIn(time);
             yield return null;
         }

        changing = false;
        yield return null;
    }

    public void FadeOut(float time){
        this.playingSource.volume -= 1.0f * (Time.deltaTime / time);
    }


    public void FadeIn(float time){
       if(!playingSource.isPlaying){
         this.playingSource.volume = 0.0f;
         playingSource.Play();
       }
       this.playingSource.volume += 1.0f * (Time.deltaTime / time);
    }
}
