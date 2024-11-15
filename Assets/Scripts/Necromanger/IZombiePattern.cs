using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IZombiePattern : MonoBehaviour
{
    protected List<GameObject> zombiesInstantiate = new List<GameObject>();

    public abstract IEnumerator RunPattern();

    protected void InvokeZombie(GameObject zombie)
    {
        GameObject zombieInstantiate = Instantiate(zombie, zombie.transform.position, Quaternion.identity, gameObject.transform);
        zombieInstantiate.SetActive(true);
        zombiesInstantiate.Add(zombieInstantiate);
    }

    public virtual void CleanPattern()
    {
        foreach (GameObject zombie in zombiesInstantiate)
        {
            Destroy(zombie);
        }
    }
}
