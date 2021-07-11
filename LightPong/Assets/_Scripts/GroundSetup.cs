using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSetup : MonoBehaviour
{

    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(Screen.width / Screen.dpi, Screen.height / Screen.dpi);

        //this.transform.localScale = new Vector2(position.x +3, position.y+4);
        this.transform.localScale = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
