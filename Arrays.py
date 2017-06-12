Desserts = ["Ice Cream", "Cookies"]
Desserts.sort()
print(Desserts.index("Ice Cream"))

Food = Desserts[:]

Food.append("Broccoli")
Food.append("Turnips")

print("Desserts = ", Desserts)
print("Food = ", Food)

Food.remove("Cookies")
print(Food[0:2])


Breakfast = ["Cookies", "Cookies", "Cooies"]
