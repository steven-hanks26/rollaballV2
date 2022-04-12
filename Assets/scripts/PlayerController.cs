using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpspeed = 10f;
    public float minY = -50f;
    public string horizontalbutton = "Horizontal_P1";
    public string verticalbutton = "Vertical_P1";

    private Rigidbody rb;
    private int count;
    public  Vector3 startLocation;
   
    public float boost;
    //public Text countText;
    //public Text winText;
    public float distancetoground = 4.375f;
    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        count = 0;
        boost = 30;
        startLocation = (transform.position);
        //SetCountText ();
        //winText.text ="";
    }

    void FixedUpdate()
    {
       
        Debug.Log (isGrounded());
        if (Input.GetKey(KeyCode.LeftShift)){
            rb.AddForce(0,0,boost);
        }
        if (Input.GetKey(KeyCode.Space)&&isGrounded()){
            Vector3 jumpVelocity = new Vector3 (0f, jumpspeed, 0f);
            rb.velocity = rb.velocity + jumpVelocity;
        }
        
        float moveHorizontal = Input.GetAxis(horizontalbutton);
        float moveVertical = Input.GetAxis(verticalbutton);
        Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

        rb.AddForce (movement);
    }
    void Update(){
        if (transform.position.y <= minY){
            transform.position = startLocation;
            rb.velocity = new Vector3(0, -2, 0);
        }
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

bool isGrounded(){
    return Physics.Raycast(transform.position,Vector3.down, distancetoground);
}
}