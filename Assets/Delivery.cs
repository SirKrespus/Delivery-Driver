using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage; //Default bool = false

    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer; // Creating a variable, reference to the Sprite Renderer component of the object.

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //GetComponent stores the reference to the <component> in the variable
    }
   private void OnCollisionEnter2D(Collision2D other) 
   {
       Debug.Log("OUCH! you just steered me right into a wall!");
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Package" && !hasPackage)
       {
           Debug.Log("Picked a present! Time to deliver it!");
           hasPackage = true;
           spriteRenderer.color = hasPackageColor;

           Destroy(other.gameObject,destroyDelay);
       }
       if (other.tag == "DeliveryDestination" && hasPackage)
       {
           Debug.Log("Present Delivered");
           hasPackage = false;
           spriteRenderer.color = noPackageColor;
       }
   }
}
