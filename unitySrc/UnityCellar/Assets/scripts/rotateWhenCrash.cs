using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWhenCrash : MonoBehaviour
{

    public float speed = 0.5f;
    public bool moveDown = false;
    public float degreesPerSecond = 45;

    int stepsSinceNoCrash = 0;

    private void OnCollisionEnter(Collision other){

        stepsSinceNoCrash = 0;

        if(other.collider.tag == "Estante"){
            Debug.Log("heyyy");
            transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
            if(moveDown == true){
                this.transform.Translate(Vector3.up * Time.deltaTime * speed);
            } else {
                this.transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
        }
        
    }

    private void onCollisionStay(Collider other){
        if(other.GetComponent<Collider>().tag == "Estante"){
            Debug.Log("heyyy");
        }
        

    }
    private void onCollisionExit(Collider other){
        Debug.Log("UUUUUU");
        if(other.tag == "Estante"){
            Debug.Log("heyyy");
        }
    }

    void Start(){

    }
    void Update(){
        print(stepsSinceNoCrash);
        if(stepsSinceNoCrash > 2000) degreesPerSecond = degreesPerSecond * -1;
        stepsSinceNoCrash ++;
    }
}
