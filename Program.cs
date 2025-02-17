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
    public string[] RandomizeAnimals(int numberOfGroups)
    {
        string[] animals = AnimalList();
        int numberOfAnimals = animals.Length;

        Random random = new Random();
        int generatedRandom = random.Next(numberOfAnimals);

        return groupArray;
    }

    // In this method I have to 
    // AssignGroup();

}
internal class School
{
    // We use this class class and constructor so we can use school object for filling our list with schools

    public string Name { get; }
    public int GroupCount { get; }

    public School(string name, int groupCount)
    {
        Name = name;
        GroupCount = groupCount;
    }
}
internal class SchoolList
{

    // In this class we fill our list of schools with data: school name, number of groups
    List<School> schools = new List<School>
{
    new School("School A", 6),
    new School("School B", 3),
    new School("School C", 2)
};

}
