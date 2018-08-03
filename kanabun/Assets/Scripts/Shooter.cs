using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {
    public AudioClip se;
    private AudioSource audiosource;
    public GameObject Bullet;

    [SerializeField]
    private Image aimPointImage;
    RaycastHit hit;

    void Start () {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = se;
	}
	
	void Update () {

        Ray ray = new Ray(transform.position, transform.forward * -1);//Rayをとばす（発射座標、向き）

        if (Physics.Raycast(ray, out hit, 30.0f))
        {

            // Rayがhitしたオブジェクトのタグ名を取得
            string hitTag = hit.collider.tag;

            // タグの名前がEnemyだったら、照準の色が変わる
            if ((hitTag.Equals("Enemy")))
            {
                aimPointImage.color = new Color(1, 0, 0, 1);
            }
            else
            {
                //Enemy以外では水色に
                aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }

            //aim位置の更新
            aimPointImage.transform.position = hit.point;

        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            //Debug.Log("右人差し指トリガーを押した");
            //OnSound();
            OnShot(hit.point);
        }
    }

    private void OnSound()
    {
        audiosource.PlayOneShot(audiosource.clip);
    }

    private void OnShot(Vector3 aimpos)
    {
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();
            bullet_rb.rotation = transform.rotation;
            bullet_rb.AddRelativeForce(0, 30, -500);
    }
}
