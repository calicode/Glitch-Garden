using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityValuesManager : MonoBehaviour
{

    public static List<EntityValues> entities = new List<EntityValues>();


    public struct EntityValues
    {

        public int starCost, healthAmount, damage;
        public string entityName;
        public EntityValues(string entityName, int starCost, int healthAmount, int damage)
        {
            this.entityName = entityName;
            this.starCost = starCost;
            this.healthAmount = healthAmount;
            this.damage = damage;
        }

    }

    void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        //Defenders
        EntityValues gnome = new EntityValues("Gnome", 2, 250, 75);
        EntityValues cactus = new EntityValues("Cactus", 1, 200, 1);
        EntityValues gravestone = new EntityValues("Gravestone", 3, 500, 0);
        EntityValues startrophy = new EntityValues("StarTrophy", 3, 300, 0);

        //Enemies
        EntityValues fox = new EntityValues("Fox", 0, 200, 1);
        EntityValues lizard = new EntityValues("Lizard", 0, 300, 1);

        entities.Add(gnome);
        entities.Add(cactus);
        entities.Add(gravestone);
        entities.Add(startrophy);
        entities.Add(fox);
        entities.Add(lizard);
    }



    public static EntityValues GetValues(string name)
    {

        Debug.Log("Got value request for " + name);
        foreach (EntityValues ents in entities)
        {
            if (ents.entityName == name) { Debug.Log("Found entity value sending back" + ents.entityName); return ents; }
        }

        return new EntityValues("EMPTY", 0, 0, 0);

    }

}
