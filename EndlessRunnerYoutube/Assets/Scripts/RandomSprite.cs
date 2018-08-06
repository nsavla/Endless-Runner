using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

    public Sprite[] sprites;
    public string resourceName;

	// Use this for initialization
	void Start () {
        if (resourceName != null)
        {
            sprites = Resources.LoadAll<Sprite>(resourceName);
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)]; 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
