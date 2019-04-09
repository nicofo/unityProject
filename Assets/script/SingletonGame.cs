using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonGame : MonoBehaviour
{

    //private static SingletonGame _instance;

    //public static SingletonGame Instance { get { return _instance; } }
    
    public double gold = 0.0;
    public double wood = 0.0;
    public double food = 0.0;
    public int population = 0;
    public double maxGold = 0.0;
    public double maxWood = 0.0;
    public double maxFood = 0.0;
    public int maxPoulation = 0;
    public int freePeople = 0;

    public int objectiveGold = 50;

    public float restFoodByPerson;
    public float deathRate;
    public float birthRate;
    public float birthDeadState = 0;

    public bool active = true;
    public TimeScript time;

    public float timeMultiplier = 1.0f;

    public List<InstanitiatedBuilding> buildings = new List<InstanitiatedBuilding>();

    public Dictionary<string, InstanitiatedBuilding> buildPosition = new Dictionary<string, InstanitiatedBuilding>();
    public Dictionary<string, int> buildQunatity = new Dictionary<string, int>();

    public PopUpScript popup;


    private void Awake()
    {
        //this.buildings = new List<InstanitiatedBuilding>();
        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    _instance = this;   
        //}
    }

    

    public void AddPersonToBuild(int index)
    {
        if (freePeople > 0)
        {
            InstanitiatedBuilding build = buildings[index];
            if (build.people >= build.build.space.population) return;
            build.people += 1;
            buildings[index] = build;
            freePeople -= 1;
        }
    }

    public void RestPersonToBuild(int index)
    {
        
        InstanitiatedBuilding build = buildings[index];
        if (build.people <= 0) return;
        build.people -= 1;
        buildings[index] = build;
        freePeople += 1;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active)
        {
            time.timeStarted = false;
            return;
        }
        else time.timeStarted = true;

        float dt = Time.deltaTime * timeMultiplier;
        for (int i = 0; i < buildings.Count; i++)
        {
            GameAttributes profit = buildings[i].getProfit();
            gold += (time.actualMultiplier * profit.gold * buildings[i].people * dt);
           
            wood += (time.actualMultiplier * profit.wood * buildings[i].people * dt);
            
            food += (time.actualMultiplier * profit.food * buildings[i].people * dt);
            
        }


        food -= (population * restFoodByPerson * dt);
        if (food < 0) food = 0;
        if (gold < 0) gold = 0;
        if (wood < 0) wood = 0;
        if (food > maxFood) food = maxFood;
        if (gold > maxGold) gold = maxGold;
        if (wood > maxWood) wood = maxWood;

        if (food <= 0 && birthDeadState > 0 || food > 0 && birthDeadState < 0)
        {
            birthDeadState = 0;
        }
        if (gold >= objectiveGold)
        {
            PopupEndGame("You Win");
        }

        if (food > 0)
        {
            birthDeadState += birthRate * dt;
        } else
        {
            birthDeadState -= deathRate * dt;
        }

        if (birthDeadState >= 1)
        {
            birthDeadState = 0;
            if (population < maxPoulation)
            {
                population += 1;
                freePeople += 1;
            }

        } else if (birthDeadState <= -1)
        {
            birthDeadState = 0;
            population -= 1;
            if (population <= 0)
            {
                PopupEndGame("You killed all your population");
            }
            else if (freePeople > 0) freePeople -= 1;
            else
            {
                for (int i = 0; i < buildings.Count; i++)
                {
                    if (buildings[i].people > 0)
                    {
                        buildings[i].people -= 1;
                    }

                }
            }
        }
    }

    public string positionToString(int x, int y)
    {
        return x.ToString() + "," + y.ToString();
    }

    public InstanitiatedBuilding getBuildPosition(int x, int y)
    {
        return buildPosition.ContainsKey(positionToString(x, y)) ? buildPosition[positionToString(x, y)] : null;
    }

    public int getIndex(InstanitiatedBuilding b)
    {
       for (int i = 0; i < buildings.Count; i++)
        {
            if (b.position.x == buildings[i].position.x && b.position.y == buildings[i].position.y)
            return i;
        }
        return -1;
    }


    public void AddBuilding(InstanitiatedBuilding b)
    {
        buildings.Add(b);
        if (buildQunatity.ContainsKey(b.build.name))
        {
            buildQunatity[b.build.name] = buildQunatity[b.build.name] + 1;
        } else
        {
            buildQunatity.Add(b.build.name, 1);
        }
        for (int x = b.position.x; x < b.build.dimension.x + b.position.x; x++)
        {
            for (int y = b.position.y; y < b.build.dimension.y + b.position.y; y++)
            {
                buildPosition.Add(positionToString(x, y), b);
            }
        }

        maxGold += b.build.space.gold;
        maxFood += b.build.space.food;
        maxWood += b.build.space.wood;

        if (b.build.isHouse)
        {
            maxPoulation += b.build.space.population;
            //freePeople += b.build.space.population;
        }

    }

    void PopupMessage(string text)
    {
        popup.gameObject.SetActive(true);
        popup.SetMessage(text);
    }

    void PopupEndGame(string text)
    {
        popup.gameObject.SetActive(true);
        popup.SetEndGame(text, time.years.ToString() + " Years  " + (time.days != 0 ? time.days.ToString() + " Days" : "365 Days"));
    }
}
