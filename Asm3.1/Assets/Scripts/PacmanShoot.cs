using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanShoot : MonoBehaviour
{
	public GameObject Bullet;
	public AudioClip ShootSound;
	public AudioSource audio;

	void Awake()
	{
		audio = transform.GetComponent<AudioSource>();
	}
	
    // Update is called once per frame
    void Update()
    {
		shoot();

	}

    //shoot bullet/dot!
    void shoot()
	{
		if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Game").GetComponent<GameBoard>().isStage2 ==2)
		{
			Vector3 pos = gameObject.transform.position + new Vector3(0.5f, 0, 0);

			Instantiate(Bullet, pos, gameObject.transform.rotation);
			audio.PlayOneShot(ShootSound);
		}
	}
}
