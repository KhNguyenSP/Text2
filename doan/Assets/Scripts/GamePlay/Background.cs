using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float Speed;
    private Material mater;

    private Vector2 offset = Vector2.zero;

    void Awake() {
        mater = GetComponent<Renderer>().material;
    }

	// Use this for initialization
	void Start () {
        offset = mater.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        offset.y += Speed * Time.deltaTime;
        mater.SetTextureOffset("_MainTex", offset);
	}
}
