using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {
    [SerializeField]
    AudioSource mSource = null;
    [SerializeField]
    UnityEngine.UI.Slider mSlider = null;

    private static float mBGMVolume = 0.3f;                  //音量を格納するstatic変数
                                                            //ゲームオーバー後のリスタートで音量を保持したままにするために使用
    
	// Use this for initialization
	void Start () {
        if(mSource != null && mSlider != null)
        {
            mSource.volume = mBGMVolume;                    //BGMの音量を初期化
            mSlider.value = mBGMVolume;                     //音量調整スライダーを初期化
        }
	}
	
	// Update is called once per frame
	void Update () {

	}


    public void SetBGMVolume()                              //mSliderのvalueが変更される度に呼び出される関数
    {
        mBGMVolume = mSlider.value;
        mSource.volume = mBGMVolume;
    }

    public static float BGM_Volume
    {
        get { return mBGMVolume; }
    }

    
}
