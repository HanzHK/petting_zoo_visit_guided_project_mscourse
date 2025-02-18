/*
Petting Zoo visit planner
 * - 18 different species of animals
 * - by default, the students are divided into 6 groups
 * - the animals should also be randomly assigned to each group, so as to keep the experience unique
 * 
There are currently three visiting schools

School A has six visiting groups (the default number)
School B has three visiting groups
School C has two visiting groups
For each visiting school, perform the following tasks

Randomize the animals
Assign the animals to the correct number of groups
Print the school name
Print the animal groups
*/


using System;

internal class Program
{
    static void Main(string[] args)
    {


        SchoolList schoolList = new SchoolList();
        schoolList.AddSchool();

        Result result = new Result();
        result.PrintResult(schoolList);

    }


}
internal class Result
{
    public void PrintResult(SchoolList schoolList)
    {
        ZooAnimals zooAnimals = new ZooAnimals();

        // School list
        List<School> schools = schoolList.GetSchools();

        foreach (var school in schools)
        {
            // Randomly assign animals to groups
            string[][] animalGroups = zooAnimals.RandomizeAnimals(school.GroupCount);

            // Print the name of the school
            Console.WriteLine($"School Name: {school.Name}");
            for (int i = 0; i < animalGroups.Length; i++)
            {
                // Print out animals in each group
                Console.WriteLine($"Group {i + 1}: {string.Join(", ", animalGroups[i])}");
            }
            Console.WriteLine();
        }
    }
}


internal class ZooAnimals
{
    public string[] GetAnimalList()
    {
        return AnimalList();
    }

    private string[] AnimalList()
    {
        return new string[]
        {
        "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
        "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
        "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };
    }


    /* In this method I need to randomize it:
     * We have 18 animals (preferably we can use array.length) so we have to generate random number 0-18, compare it with array, 
     * check if we didnt use it before and assign it to the new "group" array
     * */
    public string[][] RandomizeAnimals(int numberOfGroups)
    {
        string[] animals = AnimalList();
        int numberOfAnimals = animals.Length;

        string[] randomizedAnimals = new string[numberOfAnimals];
        bool[] usedIndices = new bool[numberOfAnimals];

        Random random = new Random();

        int index = 0;
        while (index < numberOfAnimals)
        {
            int generatedRandom = random.Next(numberOfAnimals);
            if (usedIndices[generatedRandom] == false)
            {
                randomizedAnimals[index] = animals[generatedRandom];
                index++;
                usedIndices[generatedRandom] = true;
            }
        }

        // 
        string[][] groups = new string[numberOfGroups][];
        int animalsPerGroup = numberOfAnimals / numberOfGroups;
        int extraAnimals = numberOfAnimals % numberOfGroups;

        index = 0;
        for (int i = 0; i < numberOfGroups; i++)
        {
            int groupSize = animalsPerGroup + (i < extraAnimals ? 1 : 0);
            groups[i] = new string[groupSize];
            for (int j = 0; j < groupSize; j++)
            {
                groups[i][j] = randomizedAnimals[index++];
            }
        }



        return groups;
    }

    // In this method I have to 
    // AssignGroup();

}
// We use this class class and constructor so we can use school object for filling our list with schools
internal class School
{
    // Private fields for the school name & group count
    private string name;
    private int groupCount;

    
    // Public properties to access the private fields
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int GroupCount
    {
        get { return groupCount; }
        private set { groupCount = value; }
    }

    // Class constructor
    public School(string name, int groupCount)
    {
        Name = name;
        GroupCount = groupCount;
    }
}

// In this class we fill our list of schools with data: school name, number of groups
internal class SchoolList
{
    // Declare the list of schools as a class member
    private List<School> schools = new List<School>
    {
        new School("School A", 6),
        new School("School B", 3),
        new School("School C", 2)
    };

    // Method to return the list of schools
    public List<School> GetSchools()
    {
        return schools;
    }

    // Method to add a new school to the list
    public void AddSchool()
    {
        Console.Write("Enter the name of the school: ");
        string name = Console.ReadLine();

        int groupCount = 0;
        bool isValidGroupCount = false;

        // Loop until the user enters a valid number of groups
        while (!isValidGroupCount)
        {
            Console.Write("Enter the number of groups: ");
            string input = Console.ReadLine();

            // Try to convert the input to an integer
            if (int.TryParse(input, out groupCount) && groupCount > 0)
            {
                isValidGroupCount = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer for the number of groups.");
            }
        }

        // Add the new school to the list
        schools.Add(new School(name, groupCount));
        Console.WriteLine($"School '{name}' with {groupCount} groups has been added to the list.");
    }
}

