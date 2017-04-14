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
        EntityValues lizard = new EntityValues("lizard", 0, 250, 1);
        EntityValues dwarf = new EntityValues("dwarf", 2, 250, 75);

        entities.Add(lizard);
        entities.Add(dwarf);
    }



    public static EntityValues GetValues(string name)
    {

        foreach (EntityValues ents in entities)
        {
            if (ents.entityName == name) { return ents; }
        }

        return new EntityValues("EMPTY", 0, 0, 0);

    }

}
