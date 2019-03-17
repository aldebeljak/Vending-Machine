# Module 1 Capstone

Vending Machine
When the program is run user will see a main menu consisting of the following optios:

1. Display Vending Machine Items.
2. Purchase Item(s)
Q  Quit
Choice:

When selecting 1 users will see the full list of items along with the main menu.

A1 Potato Crisps        Price $3.05    Chip    Available 5
A2 Stackers             Price $1.45    Chip    Available 5
A3 Grain Waves          Price $2.75    Chip    Available 5
A4 Cloud Popcorn        Price $3.65    Chip    Available 5
B1 Moonpie              Price $1.80    Candy   Available 5
B2 Cowtales             Price $1.50    Candy   Available 5
B3 Wonka Bar            Price $1.50    Candy   Available 5
B4 Crunchie             Price $1.75    Candy   Available 5
C1 Cola                 Price $1.25    Drink   Available 5
C2 Dr. Salt             Price $1.50    Drink   Available 5
C3 Mountain Melter      Price $1.50    Drink   Available 5
C4 Heavy                Price $1.50    Drink   Available 5
D1 U-Chews              Price $0.85    Gum     Available 5
D2 Little League Chew   Price $0.95    Gum     Available 5
D3 Chiclets             Price $0.75    Gum     Available 5
D4 Triplemint           Price $0.75    Gum     Available 5

1. Display Vending Machine Items.
2. Purchase Item(s)
Q  Quit
Choice:

When selecting 2 users will see the full list of items along with the following purchasing menu.

A1 Potato Crisps        Price $3.05    Chip    Available 5
A2 Stackers             Price $1.45    Chip    Available 5
A3 Grain Waves          Price $2.75    Chip    Available 5
A4 Cloud Popcorn        Price $3.65    Chip    Available 5
B1 Moonpie              Price $1.80    Candy   Available 5
B2 Cowtales             Price $1.50    Candy   Available 5
B3 Wonka Bar            Price $1.50    Candy   Available 5
B4 Crunchie             Price $1.75    Candy   Available 5
C1 Cola                 Price $1.25    Drink   Available 5
C2 Dr. Salt             Price $1.50    Drink   Available 5
C3 Mountain Melter      Price $1.50    Drink   Available 5
C4 Heavy                Price $1.50    Drink   Available 5
D1 U-Chews              Price $0.85    Gum     Available 5
D2 Little League Chew   Price $0.95    Gum     Available 5
D3 Chiclets             Price $0.75    Gum     Available 5
D4 Triplemint           Price $0.75    Gum     Available 5

1. Add Funds Balance: $0.0
2. Enter Product ID
3. Finish vending
Q  Quit
Choice:

When selecting 1 from purchasung menu the user will be prompted to enter a value of 1, 5, or 10.

    Please Enter Dollar Amount 1,2,5 or 10 $

If the user enters an unspecified value they will see the amount they tried to enter and an error message and be directed back to the purchase menu.

    Please Enter Dollar Amount 1,2,5 or 10 $3

When a valid value is entered that value will be added to the Balance.
The user will be prompted to either add more funds, enter product ID, or finish the transation.

When selecting 2 the user will be prompted to enter the product ID.

    Please enter LetterNumber item slot to purchase from:

If the user enters an invalid product ID they will see the ID the entered and an error messsage will occur and the user will be prompted to enter a valid product ID.

    Please enter LetterNumber item slot to purchase from: J3

    Selection not valid

When a valid product ID is entered the program prints out that the particular item was purchsed, will update the product quantity, and will update the balance.

    Please enter LetterNumber item slot to purchase from: a1

    Potato Crisps purchased
    A1 Potato Crisps        Price $3.05    Chip    Available 4

When an item is out of stock the display menu will show OUT OF STOCK  in quantity column.

    A1 Potato Crisps        Price $3.05    Chip    Available SOLD OUT


If the user is out of funds the user will be unable to purchase the item and will be directed back to the purchase menu.
The user will be prompted to either add more funds, enter another product ID, or finish the transaction.

When seecting 3 the user will receive ther change back from the remaining balance.
The amount of change will be displayed to the screen along with the number of quarters, dimes, and nickels the user is receiving back.
The user will then see a consumed item message for each item that was purchased printed to the screen.

    Here is the remaining balance of $4.75
    19 Quarter(s), 0 Dime(s), 0 Nickel(s)

    Time to mange!

    Crunch Crunch, Yum!

They will see either of the following messages base on item type:
    Drink --> Glug Glug, Yum!
    Chip --> Crunch Crunch, Yum!
    Candy --> Munch Munch, Yum!
    Gum --> Chew Chew, Yum!

Upon Completion of the program a Log.txt file will be created holding all of the transactions that occured.

    02/08/2019 14:13 $0.0    $10.0   FEED MONEY
    02/08/2019 14:14 $10.0   $8.50   C2 Dr. Salt
    02/08/2019 14:14 $8.50   $0.00   GIVE CHANGE
    02/08/2019 14:23 $0.0    $2.0    FEED MONEY
    02/08/2019 14:23 $2.0    $0.0    GIVE CHANGE
    02/08/2019 14:26 $0.0    $10.0   FEED MONEY
    02/08/2019 14:26 $10.0   $6.95   A1 Potato Crisps
    02/08/2019 14:27 $6.95   $3.90   A1 Potato Crisps
    02/08/2019 14:27 $3.90   $0.85   A1 Potato Crisps
    02/08/2019 14:27 $0.85   $10.85  FEED MONEY
    02/08/2019 14:27 $10.85  $7.80   A1 Potato Crisps
    02/08/2019 14:27 $7.80   $4.75   A1 Potato Crisps
    02/08/2019 14:28 $4.75   $0.00   GIVE CHANGE

	Upon Completion of the program a SalesReport.txt file is created. Sales report shows the total amount of money made and the quantity of items purchased.

	Potato Crisps | 3
	Grain Waves | 2
	**Total Sales** $14.65

