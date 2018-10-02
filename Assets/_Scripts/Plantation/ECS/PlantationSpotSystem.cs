using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PlantationSpotSystem : ComponentSystem {
    struct plantationSpotComponents
    {
       public PlantationSpot plantationSpot;

    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        foreach (var c in GetEntities<plantationSpotComponents>())
        {
            if (!c.plantationSpot.canBeUsed)
            {
                c.plantationSpot.outliner.enabled = false;
            }
            c.plantationSpot.audioS = c.plantationSpot.GetComponent<AudioSource>();
            //fait un cast pour référencer tous les plantationSpot a proximité.
            c.plantationSpot.FindYourNeighbours();
            if (!PlantationManager.instance.plantationList.Contains(c.plantationSpot))
            {
                PlantationManager.instance.plantationList.Add(c.plantationSpot);
            }
        }
    }
    protected override void OnUpdate()
    {
        foreach (var c in GetEntities<plantationSpotComponents>())
        {
            if (c.plantationSpot.isGrowing)
            {
                if (Time.time > c.plantationSpot.growthStartTime + c.plantationSpot.timeToGrow)
                {
                    //faire evoluer la plante
                    c.plantationSpot.ChangePlantState();
                    c.plantationSpot.growthStartTime = Time.time;
                    c.plantationSpot.growthBoosted = false;
                }
            }
        } 
    }
}
