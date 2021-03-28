using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{   
    public GameObject drone1;
    public GameObject drone2;
   

    public Transform waypoints1Parent;
    public Transform waypoints2Parent;

    private List<Transform> waypoints1 = new List<Transform>();
    private List<Transform> waypoints2 = new List<Transform>();
    private int currentWaypoint1 = 0;
    private int currentWaypoint2 = 0;

    private float droneSpeed = 3f;

    void Start()
    {

        InitWaypoints(waypoints1Parent, waypoints1);
        InitWaypoints(waypoints2Parent, waypoints2);
        
    }


    void Update()
    {
        
       StartDrone(waypoints1, drone1, ref currentWaypoint1);
  
       StartDrone(waypoints2, drone2, ref currentWaypoint2);

       
    }

    
    private void InitWaypoints(Transform parent, List<Transform> list){

        foreach(Transform waypoint in parent){

            list.Add(waypoint);

        }

    }

    private void StartDrone(List<Transform> waypoints, GameObject drone, ref int currentWaypoint){

        Vector3 distance = waypoints[currentWaypoint].transform.position - drone.transform.position;
        Vector3 direction = distance.normalized;

        drone.GetComponent<Rigidbody>().velocity = direction * droneSpeed;
      
        if(distance.magnitude < 1){
            
            if(currentWaypoint >= waypoints.Count - 1){

                currentWaypoint = 0;

            }
           
            currentWaypoint++;

        }

        drone.transform.LookAt(waypoints[currentWaypoint], transform.up);

    }


}
