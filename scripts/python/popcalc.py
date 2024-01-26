from math import *

class Poptart:
    h =  .25
    l = 4.5
    w = 3 #in inches ^

p = Poptart

def heightToTartH(f,i):

    val = (f*12) + i
    return val/p.h

def heightToTartL(f,i):

    val = (f*12)+i
    return val/p.l

def heightToTartW(f,i):

    val = (f/12)+i
    return val/p.w

print("Select operation.")
print("1.poptart height")
print("2.poptart lenght")
print("3.poptart width")

while True:
    # take input from the user
    choice = input("Enter choice(1/2/3/4): ")

    # check if choice is one of the four options
    if choice in ('1', '2', '3'):
        try:
            feet = float(input("Enter feet: "))
            inch = float(input("Enter inch: "))
        except ValueError:
            print("Invalid input. Please enter a number.")
            continue

        if choice == '1':
            print(feet, "ft", inch, "in"," = ", heightToTartH(feet, inch), " poptarts")

        elif choice == '2':
            print(feet, "ft", inch, "in"," = ", heightToTartL(feet, inch), " poptarts")

        elif choice == '3':
            print(feet, "ft", inch, "in"," = ", heightToTartW(feet, inch), " poptarts")

        
        # check if user wants another calculation
        # break the while loop if answer is no
        next_calculation = input("Let's do next calculation? (yes/no): ")
        if next_calculation == "no":
          break
    else:
        print("Invalid Input")