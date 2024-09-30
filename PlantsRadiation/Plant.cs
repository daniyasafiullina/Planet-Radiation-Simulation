using System;

namespace PlantsRadiation
{
    public abstract class Plant
    {
        public string Name { get; set; }
        public int NutrientLevel { get; set; }
        public bool IsAlive { get; set; } = true;

        public Plant(string name, int nutrientLevel)
        {
            Name = name;
            NutrientLevel = nutrientLevel;
        }

        public abstract void ModifyLevel(int amount);
        public abstract int GetAlphaDemand();
        public abstract int GetDeltaDemand();
    }

    public class Wombleroot : Plant
    {
        public Wombleroot(string name, int nutrientLevel) : base(name, nutrientLevel) { }

        public override void ModifyLevel(int amount)
        {
            NutrientLevel += amount;
            if (NutrientLevel > 10 || NutrientLevel <= 0)
                IsAlive = false;
        }

        public override int GetAlphaDemand()
        {
            return 10;
        }

        public override int GetDeltaDemand()
        {
            return 0;
        }
    }

    public class Wittenroot : Plant
    {
        public Wittenroot(string name, int nutrientLevel) : base(name, nutrientLevel) { }

        public override void ModifyLevel(int amount)
        {
            NutrientLevel += amount;
            if (NutrientLevel <= 0)
                IsAlive = false;
        }

        public override int GetAlphaDemand()
        {
            return 0;
        }

        public override int GetDeltaDemand()
        {
            if (NutrientLevel < 5) return 4;
            else if (NutrientLevel >= 5 && NutrientLevel <= 10) return 1;
            else return 0;
        }
    }

    public class Woreroot : Plant
    {
        public Woreroot(string name, int nutrientLevel) : base(name, nutrientLevel) { }

        public override void ModifyLevel(int amount)
        {
            NutrientLevel += amount;
            if (NutrientLevel <= 0)
                IsAlive = false;
        }

        public override int GetAlphaDemand()
        {
            return 0;
        }

        public override int GetDeltaDemand()
        {
            return 0;
        }
    }
}
