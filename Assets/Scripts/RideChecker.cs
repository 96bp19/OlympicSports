using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideChecker : MonoBehaviour
{
    [HideInInspector]
    public ARideable currentRidable;
    private AnimationController animController;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ride"))
        {
            currentRidable = other.GetComponent<ARideable>();
            other.transform.SetParent(transform);
            Ride(true);
            
        }
    }

    void AdjustPivotForRidables(ARideable ride)
    {
        Vector3 localpos = new Vector3(0, ride.ridingHeight, 0);
        ride.transform.SetParent(transform);
        ride.transform.localPosition = localpos;
        Destroy(ride.GetComponent<Collider>());
    }

    void Ride(bool val)
    {  
        currentRidable.PlayPlayerRideAnimation(animController,val);        
    }

    public void Unride()
    {
        Ride(false);
        Destroy(currentRidable.gameObject);
        currentRidable = null;
    }
}
