using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   float speed = 0.015f;
    bool isStop=true;
    private static float z;
    private Touch touch;
    private float valueToIncrease = 0.2f;
    public GameManager game;
    public float move=0;
    void Update()
    {
        if(isStop){
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+0.4f);
        }
        // transform.Translate(Vector3.forward * Time.deltaTime * 4f);
        
       
       
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

        pos.x = Mathf.Clamp(transform.position.x,-1.2f,+1.2f);

        transform.position = pos;
        
    }
    void FixedUpdate(){
        if(Input.GetKey("a")){
            transform.position = new Vector3(transform.position.x - speed * speed,transform.position.y,transform.position.z);
        }
        if(Input.GetKey("d")){
            transform.position = new Vector3(transform.position.x + speed * speed,transform.position.y,transform.position.z);
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Finish Line"){
            isStop = false;
            game.Win();
        }
        else if(gameObject.GetComponent<MeshRenderer>().material.name == col.gameObject.GetComponent<MeshRenderer>().material.name)
        {
            Destroy(col.gameObject);
            ScaleUp();
            
        } 
        else{
            Destroy(col.gameObject);
            ScaleDown();
        }
        
    }

    private void ScaleUp(){
        // transform.localScale += new Vector3(0.1f,0.1f,0.1f);
        transform.localScale += new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);
        transform.position= new Vector3(transform.position.x,transform.position.y+valueToIncrease, transform.position.z);
    }

    private void ScaleDown(){
        transform.localScale -= new Vector3(valueToIncrease,valueToIncrease,valueToIncrease);
        transform.position= new Vector3(transform.position.x,transform.position.y-valueToIncrease, transform.position.z);
    }

    public static float GetZ(){
        return PlayerMovement.z;
    }
}
