using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadelMove : MonoBehaviour
{

    public GameObject padel;


    private RectTransform rectTransform;
    private void Awake()
    {
        padel = this.gameObject;
        rectTransform = padel.GetComponent<RectTransform>();

        Debug.Log(Screen.width +"      "+Screen.height);
    }

    private void Update()
    {
        //count the touch

        if (Input.touchCount != 0)
        {
            // set input get touch to touch
            Touch touch = Input.GetTouch(0);

            //check it's moving or not
            if (touch.phase == TouchPhase.Moved)
            {
                //Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                //pos.z = 0f;
                ////pos.y = -3.5f;               
                    
                //padel.transform.position = new Vector2(pos.x, -3.5f);

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(touchPosition.x, transform.position.y),2000*Time.deltaTime);//20

                //Debug.Log(pos);
            }
        }

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0); // hardcode the y and z for your use

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition.y = transform.position.y;
        curPosition.z = 0;
        transform.position = curPosition;
    }
}
