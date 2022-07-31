using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromanger : MonoBehaviour
{
    public GameObject zombieShield;
    public IZombiePattern currentPattern;
    public ZombieCirclePattern zombieCirclePattern;
    public ZombieGeneratorPattern zombieSpiralPattern;
    public ZombieGeneratorPattern zombieSlalomPattern;

    private float time = 0;
    private bool havePatternRunning = false;
    private int phase = 1;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            RunPhase(zombieCirclePattern, 25f);
        }

        if (phase == 2)
        {
            RunPhase(zombieSpiralPattern, 30f);
        }

        if (phase == 3)
        {
            RunPhase(zombieSlalomPattern, 35f);
        }
        if (phase > 3)
        {
            int choice = Random.Range(1, 4);
            switch (choice)
            {
                case 1:
                    RunPhase(zombieCirclePattern, 25f);
                    break;
                case 2:
                    RunPhase(zombieSpiralPattern, 30f);
                    break;
                case 3:
                    RunPhase(zombieSlalomPattern, 35f);
                    break;
                default:
                    break;
            }
        }
    }

    private void RunPhase(IZombiePattern pattern,float runningTime)
    {
        if (!havePatternRunning)
        {
            time = 0;
            if (pattern is ZombieGeneratorPattern)
            {
                (pattern as ZombieGeneratorPattern).StopInvoking = false;
            }
            StartCoroutine(pattern.RunPattern(phase));
            havePatternRunning = true;
            currentPattern = pattern;
        }
        time += Time.deltaTime;
        if (time >= runningTime)
        {
            time = 0;
            currentPattern.CleanPattern(phase);
            StopAllCoroutines();
            havePatternRunning = false;
            phase++;
        }
    }
}
