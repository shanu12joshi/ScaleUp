using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butter : MonoBehaviour
{
    bool isStop=true;
    Vector3 temp;

    public Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnCollisionEnter(Collision col){
            Debug.Log("WHATTTT");
        if(col.gameObject.name == "Finish Line"){
            isStop = false;
            // game.Win();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if(col.gameObject.name!= "Player" && col.gameObject.name!= "Plane")
        { 
            if(gameObject.GetComponent<MeshRenderer>().material.name == col.gameObject.GetComponent<MeshRenderer>().material.name)
            {
                Destroy(col.gameObject);
                ScaleUp();
                
            } 
            else{
            Destroy(col.gameObject);
            ScaleDown();
        }

    }
       
        
    }

        private void ScaleUp(){
        // transform.localScale += new Vector3(0.1f,0.1f,0.1f);
        // transform.localScale += new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);

        temp = transform.localScale;
        temp.x += Time.deltaTime;
        temp.y += Time.deltaTime;
        temp.z += Time.deltaTime;
        transform.localScale = temp;
        transform.position= new Vector3(transform.position.x,transform.position.y+Time.deltaTime, transform.position.z);
        
        player.position = new Vector3(player.transform.position.x,player.transform.position.y+Time.deltaTime, player.transform.position.z);

    }

    private void ScaleDown(){
        temp = transform.localScale;
        temp.x -= Time.deltaTime;
        temp.y -= Time.deltaTime;
        temp.z -= Time.deltaTime;
        transform.localScale = temp;
        transform.position= new Vector3(transform.position.x,transform.position.y-Time.deltaTime, transform.position.z);

        player.position = new Vector3(player.transform.position.x,player.transform.position.y-Time.deltaTime, player.transform.position.z);


        // transform.localScale -= new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);
        // transform.position= new Vector3(transform.position.x,transform.position.y-valueToIncrease, transform.position.z);
    }

}
