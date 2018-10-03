using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour {

    [SerializeField, HideInInspector]
    private int energy, maxEnergy;
    public Slider energyBar;

    private int currentConsommation = 0;
    private bool isConsoRunning = false;

    private List<IConsommation> ObjsUsingFuel = new List<IConsommation>();

    #region setter / getter

    public int Energy
    {
        get => energy;
        set
        {
            energy = value;
            if (energyBar)
            {
                energyBar.value = energy;
            }
            energy = (energy < 0) ? 0 : (energy > maxEnergy) ? maxEnergy : energy;
        }
    }

    public int MaxEnergy
    {
        get => maxEnergy;
        set
        {
            maxEnergy = value;
            if (energyBar)
                energyBar.maxValue = maxEnergy;
            if (energy > maxEnergy)
                Energy = maxEnergy;
        }
    }


    public int CurrentConsommation
    {
        get => currentConsommation;
        set
        {
            currentConsommation = (value < 0) ? 0 : value;
        }
    }

    public bool HaveEnougthEnergy(int conso)
    {
        return Energy - conso >= 0;
    }

    #endregion

    public void Replenish()
    {
        Energy = MaxEnergy;
    }

    public bool Conso(IConsommation obj)
    {
        if(Energy - obj.ConsoBoost >= 0)
        {
            Energy -= obj.ConsoBoost;
            return true;
        }
        return false;
    }

    public bool StartConso(IConsommation obj)
    {
        if(Energy - CurrentConsommation + obj.Conso >= 0)
        {
            CurrentConsommation += obj.Conso;
            if (!isConsoRunning)
            {
                StartCoroutine(ConsommationCoroutine());
            }
            if(!ObjsUsingFuel.Contains(obj))
                ObjsUsingFuel.Add(obj);
            return true;
        }
        return false;
    }

    public void StopConso(IConsommation obj)
    {
        CurrentConsommation -= obj.Conso;
        ObjsUsingFuel.Remove(obj);
    }


    public void FailContinueAllConso()
    {
        foreach(var obj in ObjsUsingFuel)
        {
            obj.FailConsommation();
        }
    }

    public void FailConso(IConsommation obj)
    {
        obj.FailConsommation();
    }

    IEnumerator ConsommationCoroutine()
    {
        isConsoRunning = true;
        while (isConsoRunning && energy-CurrentConsommation >= 0 && currentConsommation > 0)
        {
            Energy -= CurrentConsommation;
            yield return new WaitForSeconds(1);
        }

        if (energy - CurrentConsommation >= 0)
            FailContinueAllConso();

        isConsoRunning = false;


    }
}
