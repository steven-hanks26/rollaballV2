using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public float boost;
    //public Text countText;
    //public Text winText;
    
    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        boost = 30;
        //SetCountText ();
        //winText.text ="";
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            rb.AddForce(0,0,boost);
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce (movement);
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {

            other.gameObject.SetActive (false);
            count = count + 1;
            //SetCountText ();
        }
    }
    void SetCountText ()
    {
        //countText.text = "count:" + count.ToString ();
        if (count >=8)
        {
            //winText.text = "you Win";
        }
       
    }
}
