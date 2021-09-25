using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boll : MonoBehaviour
{

    private Rigidbody2D _rd;
    public bool isStart=false;

    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //change random color 
        if (other.gameObject.GetComponent<Image>()!=null)
        {
             Image _image= other.gameObject.GetComponent<Image>();

            _image.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        //random apply velocity on ball for stop looping issue
        Vector2 loopissue = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));

        _rd.velocity += loopissue * 25f * Time.deltaTime;


        // first time move 
        if (other.gameObject.tag=="Padel" && !isStart)
        {
            isStart = true;
            
            _rd.velocity = new Vector2(10f, -20f) * 25f * Time.deltaTime ;
        }
        
    }

}
