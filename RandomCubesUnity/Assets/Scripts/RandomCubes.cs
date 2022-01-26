/****
 * Created By: Tyrese Peoples
 * Date Created: Jan. 24, 2022
 * Last Edited By: Tyrese Peoples
 * Last Edited Date: Jan. 26, 2022
 * 
 * Description: Spawn multiple cube prefabs into the scene.
 ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; //amount each cube will shrink each frame
    public int numberOfCubes = 0; // Total # of cubes created
    
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes



    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiatates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //adding to the number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //creates cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instances

        Color randColor = new Color(Random.value, Random.value, Random.value);


        gObj.transform.position = Random.insideUnitSphere; //random location inside a sphere radius of 1 out from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>(); // list for removed

        foreach(GameObject goTemp in gameObjectList){
            float scale = goTemp.transform.localScale.x; // records current scale
            scale *= scalingFactor; //scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if (scale <= 0.1f)
        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);
        }

    }
}
