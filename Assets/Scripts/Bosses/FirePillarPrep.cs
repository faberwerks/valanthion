using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarPrep : MonoBehaviour {

    [SerializeField]
    private GameObject firePillar;

    [SerializeField]
    private float countdown;

    public float damage;
    
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            firePillar.GetComponent<FirePillar>().damage = damage;
            Instantiate(firePillar,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
