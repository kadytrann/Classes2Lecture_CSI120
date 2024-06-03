namespace Classes2Lecture_CSI120
{
    internal class Program
    {
        // Kady Tran
        // 6/2/2024
        // Classes Part 2


        // Array
        // Create a FoodItem with a size of 5
        static FoodItem[] foodItems = new FoodItem[5];

        static void Main()
        {   // Setting up the array with the original data
            Preload();

            // Calling our Menu method
            Menu();


        } // End of main

        public static void Menu()
        {
            // using a bool to keep our program running
            bool running = true;

            // This while loop will ensure that our program is running until user decides to exit
            while (running)
            {

                // Display menu options
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add New Food Item");
                Console.WriteLine("2. Double Array Size");
                Console.WriteLine("3. Display All Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                // Reading user input
                string choice = Console.ReadLine();

                // Using a switch case to redirect user to the correct path
                switch (choice)
                {
                    case "1":
                        // Add a new food item
                        try
                        {
                            // Asking for food item details
                            Console.Write("Enter food name: ");
                            string name = Console.ReadLine(); // reading user input

                            Console.Write("Enter quantity: ");
                            double qty = double.Parse(Console.ReadLine());

                            Console.Write("Enter calories: ");
                            double calories = double.Parse(Console.ReadLine());

                            // Creating a new FoodItem object
                            FoodItem newFoodItem = new FoodItem(name, qty, calories);
                            // Add the new FoodItem to the array
                            AddNewFoodItem(newFoodItem);

                            Console.WriteLine("Food item added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        // Double the array size
                        DoubleArraySize();

                        Console.WriteLine("The array size has been doubled.");

                        break;

                    case "3":
                        // Display all food items
                        Console.WriteLine("Displaying all food items:");
                        

                        foreach (FoodItem singleFoodItem in foodItems)
                        {
                            if (singleFoodItem != null)
                            {
                                Console.WriteLine(singleFoodItem.DisplayFoodInformation());
                            }
                            else
                            {
                                Console.WriteLine("Empty slot");
                            }
                        }
                        break;

                    case "4":
                        // Exit the program
                        running = false;
                        Console.WriteLine("You have exited");
                        break;

                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid choice, please enter a correct input.");
                        break;
                } // end of switch
            } // End of while loop
        } // End of menu()


        // Lecture notes below

        public static void KiwiExample()
        {
            FoodItem kiwi = new FoodItem("Kiwi", 1, 42);

            //DoubleArraySize();

            try
            {
                AddNewFoodItem(kiwi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (FoodItem singleFoodItem in foodItems)
            {
                if (singleFoodItem != null)
                {
                    Console.WriteLine(singleFoodItem.DisplayFoodInformation());
                }

            }
        }

        public static void DoubleArraySizeExample()
        {

            int ogArraySize = foodItems.Length;

            Console.WriteLine($"Original Array Size: {foodItems.Length}");

            DoubleArraySize();

            int doubleArraySize = ogArraySize * 2;
            bool isArraySizeDoubled = doubleArraySize == foodItems.Length;

            if (isArraySizeDoubled)
            {
                Console.WriteLine("The array size has doubled");

                foreach (FoodItem singleItem in foodItems)
                {
                    // How do we prevent a null exception error
                    // We check to see if something is not null

                    if (singleItem != null)
                    {
                        Console.WriteLine(singleItem.DisplayFoodInformation());
                    }
                    else
                    {
                        Console.WriteLine("Item not found");
                    }

                }
            }
            else
            {
                Console.WriteLine("The array size did not doubled");
            }
        }

        public static void AddNewFoodItem(FoodItem newFoodItem)
        {
      
            // Else return error no space found
            // Loop through my food Item Array
            for (int i = 0; i < foodItems.Length; i++)
            {
                // check for an empty spot
                if (foodItems[i] == null)
                {
                    // if an empty spot is found, add to space
                    foodItems[i] = newFoodItem;
                    // you can use the return keyword in a method that is void to leave the method
                    return; 

                }
            }

            // Throw a new exception
            throw new Exception("No more room in the array");
            
        }


        // DoubleArraySize()
        public static void DoubleArraySize()
        {
            int arraySize = foodItems.Length;
            int newSize = arraySize * 2;

            FoodItem[] tempArray = new FoodItem[newSize];
            for (int i = 0; i < foodItems.Length; i++)
            {
                tempArray[i] = foodItems[i];
            }

            foodItems = tempArray;



        }

        public static void Preload()
        {
            // Apple 7 95 665
            foodItems[0] = new FoodItem("Apple", 7, 95);

            // Banana 4 105 420
            foodItems[1] = new FoodItem("Banana", 4, 105);

            // Chicken Breast 8 165 1320
            foodItems[2] = new FoodItem("Chicken breast", 8, 165);

            // Broccoli 5 55 275
            foodItems[3] = new FoodItem("Broccoli", 5, 55);

            // Almonds 7 70 490
            foodItems[4] = new FoodItem("Almonds", 7, 70);

        }

        public static void ClassMethodExample()
        {
            // FoodItem() ; Default Constructor
            // Then we've changed into so now the new Constructor is FoodItem(string, double, double), if it's throwing an error, then it's looking for that
            FoodItem apple = new FoodItem("Apple", 7, 95);
            FoodItem noValues = new FoodItem();

            // FoodItem
            // Name
            // Qty
            // Calories

            // Here, we try to change the value of 7 quantity to 9
            apple.Qty = 9;
            Console.WriteLine(apple.DisplayFoodInformation());

            //Console.WriteLine(apple.Calories);
        }


        // Talk about throwing exceptions
        // Class Methods
        // Arrays

    } // End of class

    // Creating a class - we can do this by:
    // access modifier class keyword name ( starts with an uppercase, and is singular )

    public class FoodItem
    {
        // Fields
        public string Name;
        public double Qty;
        public double Calories;

        // Constructors
        // Name of Class - And no return type, ( so just public NAME() )
        public FoodItem(string name, double qty, double calories) // Making a constructor is to ensure that the user will put all of the required data, as stated in the parameters.
        {
            // Fields = argument
            Name = name;
            Qty = qty;
            Calories = calories;
        } // FoodItem

        // Overloading methods
        // Overloading methods allows you to name similar methods the same name, but with different parameters. Example ( if the above was string, double, double) then this new method with the same name can be ( double, string, double ), it just can't have the same parameters
        public FoodItem()
        {
            Name = "Placeholder";
            Qty = 1;
            Calories = 0;
        }

        // Methods
        // Total Calories : Returns the Qty * Calories
        // public static void ClassMethodExample()
        public double TotalCalories()
        {
            return Qty * Calories;
        } // TotalCalories()

        // Display Data
        // Name | Qty | Calories | Total Calories
        public string DisplayFoodInformation()
        {
            return $"{Name} | {Qty} | {Calories} | {TotalCalories()}";
        }


    } // Class FoodItem

} // End of namespace
