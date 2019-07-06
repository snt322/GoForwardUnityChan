using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    [SerializeField]
    GameObject mGround = null;
    [SerializeField]
    GameObject mCubePrefab = null;



    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject tmpObj = collision.gameObject;

        //Cube自身のワールド座標(Cubeの中心座標)
        Vector3 tmpCubePos = this.gameObject.transform.position;

        //音を鳴らすフラグ
        bool isPlay = false;

        //Block自身の下部にほかのブロックまたはグラウンドが有り、衝突した場合
        foreach (ContactPoint2D cPoint in collision.contacts)
        {
            if (cPoint.point.y < tmpCubePos.y && (collision.gameObject.name == mGround.name || collision.gameObject.name == mCubePrefab.name))       //キューブ自身の下部が「ground」または「CubePrefab」と接触した場合、上に乗ったキューブ(このキューブ)が効果音を鳴らす
            {
                isPlay = true;
            }
        }

        if (isPlay)
        {
            AudioSource tmpSource = this.gameObject.GetComponent<AudioSource>() as AudioSource;
            if(tmpSource == null)
            {
                Debug.Log("AudioSource tmpSource is null");
            }
            else
            {
                tmpSource.volume = BGMController.BGM_Volume;
                tmpSource.Play();
            }


        }
    }

}



