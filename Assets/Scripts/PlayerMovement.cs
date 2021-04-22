﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{   float speed = 0.015f;
    bool isStop=true;
    private static float z;
    private Touch touch;
    private float valueToIncrease = 0.1f;
    public GameManager game;
    public float move=0;
    Vector3 temp;

    public float sideSpeed;

    // public Rigidbody rbody;
    void Update()
    {
        if(isStop){
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+0.4f);
        }
        // transform.Translate(Vector3.forward * Time.deltaTime * 4f);
        
       if(Input.GetMouseButton(0)){
           MoveSide();
       }
       
        if(Input.touchCount > 0 && isStop)
        {
            touch = Input.GetTouch(0);
        
            if(touch.phase == TouchPhase.Moved )
            {
        
                transform.position = new Vector3(
                    transform.position.x+touch.deltaPosition.x * speed,
                    transform.position.y,
                    transform.position.z);
            }
        }

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x,-201f,-199f);

        transform.position = pos;
        
    }
    void FixedUpdate(){
        // if(Input.GetKey("a")){
        //     rbody.AddForce(-100* Time.deltaTime,0,0,ForceMode.VelocityChange);
        //     // transform.position = new Vector3(transform.position.x - speed * speed,transform.position.y,transform.position.z,ForceMode.VelocityChange);
        // }
        // if(Input.GetKey("d")){
        //     rbody.AddForce(00* Time.deltaTime,0,0,ForceMode.VelocityChange);

        //     // transform.position = new Vector3(transform.position.x + speed * speed,transform.position.y,transform.position.z, ForceMode.VelocityChange);
        // }
    }
    void OnCollisionEnter(Collision col){
        Debug.Log(col);
        Debug.Log("????");
        if(col.gameObject.name == "Finish Line"){
            isStop = false;
            // game.Win();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
  
        
    }

    // private void ScaleUp(){
    //     // transform.localScale += new Vector3(0.1f,0.1f,0.1f);
    //     // transform.localScale += new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);

    //     temp = transform.localScale;
    //     temp.x += Time.deltaTime;
    //     temp.y += Time.deltaTime;
    //     temp.z += Time.deltaTime;
    //     transform.localScale = temp;
    //     transform.position= new Vector3(transform.position.x,transform.position.y+Time.deltaTime, transform.position.z);

    // }

    // private void ScaleDown(){
    //     temp = transform.localScale;
    //     temp.x -= Time.deltaTime;
    //     temp.y -= Time.deltaTime;
    //     temp.z -= Time.deltaTime;
    //     transform.localScale = temp;
    //     transform.position= new Vector3(transform.position.x,transform.position.y-Time.deltaTime, transform.position.z);


    //     // transform.localScale -= new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);
    //     // transform.position= new Vector3(transform.position.x,transform.position.y-valueToIncrease, transform.position.z);
    // }

    public static float GetZ(){
        return PlayerMovement.z;
    }

    void MoveSide(){
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100)){
            transform.position = Vector3.Lerp(transform.position, 
            new Vector3(hit.point.x,transform.position.y,transform.position.z), 
            sideSpeed * Time.deltaTime);
        }
    }
}
