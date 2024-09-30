using System;
using System.Collections.Generic;
using System.IO;

namespace PlantsRadiation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file
            Console.WriteLine("Enter the filename:");
            string filename = Console.ReadLine();
            string[] lines = File.ReadAllLines(filename);

            // Initialize plants
            int plantCount = int.Parse(lines[0]);
            List<Plant> plants = new List<Plant>();

            for (int i = 1; i <= plantCount; i++)
            {
                string[] plantData = lines[i].Split(' ');
                string name = plantData[0];
                string species = plantData[1];
                int nutrientLevel = int.Parse(plantData[2]);

                if (species == "wom")
                    plants.Add(new Wombleroot(name, nutrientLevel));
                else if (species == "wit")
                    plants.Add(new Wittenroot(name, nutrientLevel));
                else if (species == "wor")
                    plants.Add(new Woreroot(name, nutrientLevel));
            }

            int days = int.Parse(lines[plantCount + 1]);

            // Simulate days
            IRadiation alpha = Alpha.Instance();
            IRadiation delta = Delta.Instance();
            IRadiation noRadiation = NoRadiation.Instance();

            IRadiation currentRadiation = noRadiation;

            for (int day = 0; day < days; day++)
            {
                Console.WriteLine($"Day {day + 1}: Radiation = {currentRadiation.GetType().Name}");

                // Apply the radiation and update nutrient levels
                foreach (var plant in plants)
                {
                    if (plant.IsAlive)
                    {
                        if (plant is Wombleroot wombleroot)
                            currentRadiation.ModifyNutrientLevel(wombleroot);
                        else if (plant is Wittenroot wittenroot)
                            currentRadiation.ModifyNutrientLevel(wittenroot);
                        else if (plant is Woreroot woreroot)
                            currentRadiation.ModifyNutrientLevel(woreroot);

                        Console.WriteLine($"{plant.Name} ({plant.GetType().Name}): Nutrient Level = {plant.NutrientLevel}, Alive = {plant.IsAlive}");
                    }
                }

                int alphaDemand = 0;
                int deltaDemand = 0;


                foreach (var plant in plants)
                {
                    if (plant.IsAlive)
                    {
                        alphaDemand += plant.GetAlphaDemand();
                        deltaDemand += plant.GetDeltaDemand();
                    }
                }


                if (alphaDemand > deltaDemand + 3)
                    currentRadiation = alpha;
                else if (deltaDemand > alphaDemand + 3)
                    currentRadiation = delta;
                else
                    currentRadiation = noRadiation;
            }


            Plant strongestPlant = null;
            foreach (var plant in plants)
            {
                if (plant.IsAlive && (strongestPlant == null || plant.NutrientLevel > strongestPlant.NutrientLevel))
                    strongestPlant = plant;
            }

            if (strongestPlant != null)
            {
                Console.WriteLine($"The strongest plant after {days} days is {strongestPlant.Name} ({strongestPlant.GetType().Name}) with a nutrient level of {strongestPlant.NutrientLevel}");
            }
            else
            {
                Console.WriteLine($"No plants survived after {days} days.");
            }
        }
    }
}