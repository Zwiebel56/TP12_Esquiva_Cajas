using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision col){
            if(col.gameObject.CompareTag("Player")){
                Destroy(col.gameObject);
            }else if(col.gameObject.CompareTag("Piso")){
                //reposicionarse
            }
        }
    }
}
