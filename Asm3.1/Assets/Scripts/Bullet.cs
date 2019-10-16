using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if (timer >= 0.0001)
		{
			gameObject.transform.position += new Vector3(0.5f,  0, 0);
			timer = 0;
		}
    }
}
