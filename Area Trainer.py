UArray = ["John"]
PArray = ["Doe"]
Scores = ["0"]
LoggedIn = False
UserSesh = ""
PassSesh = ""
import randint from random
def CreateAccount():
    Username = input("Enter a username")
    Password = input("Enter a password")

    UArray.append(Username)
    PArray.append(Password)

def Login():
    Username = input("Enter a username")
    for i in range (0, len(UArray)):
        if UArray[i] == Username:
            Password = ""
            while Password != PArray[i]:
                Password = input("Enter a password")
                LoggedIn = False
            LoggedIn = True


Count = 0   
while Count < 1 or Count > 3:
    Count = int(input("1.Circle\n2.Square\n3.Rectangle\nEnter number for shape:\n"))
print(Count)

if Count == 1:
    radius = randint(1,80)
    print("The Radius is " + radius)
    
    CArea = 3.14159265359 * radius * radius
    Options1= randint(radius-10,radius+10)
    Options2= randint(radius-10,radius+10)
    Options3= randint(radius-10,radius+10)
elif Count == 2:
    side = randint(1,80)
    SArea = side * side
