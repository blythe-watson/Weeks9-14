using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject targetPrefab;
    public int howManyTargets = 5;
    public GameObject star;
    public SpriteRenderer victorySprite;

    public List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        //two different ways to toggle sprites
        victorySprite.enabled = false;
        star.SetActive(false);

        //initialize an arraylist
        targets = new List<GameObject>();


        //create a number of targets equivalent to the integer set earlier
        //give them a random position around the origin point
     for(int i = 0; i < howManyTargets; i++)
        {
            //create a new GameObject using that prefab we dropped in the inspector
            GameObject newTarget = Instantiate(targetPrefab);
            //give it a random position
            newTarget.transform.position = Random.insideUnitCircle * 5;

            //grabs a copy of the Target script and calls it t, which is now the Target component of this prefab we made
            Target t = newTarget.GetComponent<Target>();
            //spawner is a component we coded into the target script earlier - we're telling the target that this script is the spawner it was talking about
            t.spawner = this;

            //add that prefab we defined earlier to the arraylist
            targets.Add(newTarget);
        }
    }

    public void TargetHit(GameObject t)
    {
        targets.Remove(t);
    }

    // Update is called once per frame
    void Update()
    {
        //two different ways to turn on the victory sprite when the array reaches 0
        if(targets.Count == 0)
        {
            victorySprite.enabled = true;
            star.SetActive(true);
        }
    }
}
