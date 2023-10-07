## Animal Parkour
![parkour-the-office.gif](img%2Fparkour-the-office.gif)
Welcome to the Animal Parkour game! This README file will provide you with all the essential information you need to understand, set up, and enjoy my Unity game.

### Introduction
Animal Parkour is an exciting Unity game where you control various animals as they navigate challenging parkour courses. Collect food items along the way, avoid eating unhealthy and avoid enemies. All that while racing against time to achieve the highest score possible.

### Built With
[![My Skills](https://skillicons.dev/icons?i=unity)](https://skillicons.dev)

## Gameplay
In Animal Parkour, the main objective is to guide your chosen animal from point A to point B through intricate parkour courses while collecting food items along the way. Your score is determined by the number of collected food items and the time spent

### Additional Challenge:
- **Energy Level:** Some items may be considered trash/unhealthy; colliding with them will lower your energy, which makes you slower.
- **Enemies:** Beware of moving enemies! touching them results in a game over.

## Requirements
### Menu
The game features a user-friendly menu with the following options:
- **Animal Selection:** Choose your preferred animal character.
- **Enter Name:** Input your player name.

### New Input System
Control your animal character using the following input commands:
- **W, A, S, D:** Move your character.
- **Spacebar:** Jump.

### Physics
Engage in parkour challenges that involve:
- **Jump:** Animals can jump over obstacles.
- **Roll Under:** Rolling under obstacles.
- **Swim:** Certain animals can swim through water.
- **Dodge Enemies:** Avoid touching moving enemies to prevent a game over.

### Scenes
The game comprises three main scenes:
- **Home:** Welcome screen where the game can be started or the highscore can be seen.
- **Menu:** Navigate through the game options.
- **Highscore:** View the top player scores.
- **Game:** The heart of the game where you control your animal character.
  - **Overlay:** Throuout the game the time and points are visible

### Pausable Timer
The game includes a timer that can be paused, allowing you to strategize and take a breather during challenging moments.

## My To-Do's
- [x] Add character Movement/Jump
- [x] Add Character Menu
- [x] Add changes to all characters
- [x] Animate basic movements to all characters
- [x] Add Scenes Manager
- [x] Create first Parkour 
- [x] Animate Parkour
- [x] Add Points System
- [x] Animate Points
- [x] Create Overlay during game with time and hearts
- [x] Add Trash (minus Points)
- [x] Camera movement changes, when swimming
- [x] swimming animation (somewhat)
- [ ] Add rolling under obstacles
- [ ] Add moving enemies to empty field
- [ ] Make Energy move obviouse (add animation when eating trash, add red/green glow to food)
- [ ] After Game finished, enter name (for highscore)
- [ ] Add Highscore with only time
- [ ] MAKE PRETTY CUS EW


## Bugs that still need to be fixed
- When the player Restarts the game, or when they go to the menu to select a new character and start the game again, the character got "destroyed" (as far as i understood it).<br> 
=> This can be solved instantiating the characters, like we do with the pause menu for example.

- Since it's hard to differentiate the fruits with the sweets, i tried to give them a slight glow. For the fruits a green glow and for the sweet a red glow.<br>
I tried to do it with [Post Processing](https://docs.unity3d.com/Manual/PostProcessingOverview.html) with the Layer and Volume. ![layer.png](img%2Flayer.png) <br>
But when i tried to add a material to the fruits (that had no colour, only Emission with intensity 2), it coloured the whole object with that colour. Like this:<br> ![layer.png](img%2Fapple-glow.png) <br>
Even when i tried to layer the materials, the green overwrote the apples material :![layer.png](img%2Fapple-material.png)



## Assets
Please make sure to support these asset creators by downloading their assets if you intend to modify or expand upon the game.
### [Quirky Series - FREE Animals Pack](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
Used for the characters
![animal_asset.jpg](img%2Fanimal_asset.jpg)

### [LowPoly Food Lite](https://assetstore.unity.com/packages/3d/props/food/low-poly-food-lite-258693)
Used for the points
![food_asset.jpg](img%2Ffood_asset.jpg)

### [Low Poly Fence Pack](https://assetstore.unity.com/packages/3d/props/exterior/low-poly-fence-pack-61661)
Used for the Vegetation
![fence_asset.png](img%2Ffence_asset.png)

### [LowPoly Trees and Rocks](https://assetstore.unity.com/packages/3d/vegetation/lowpoly-trees-and-rocks-88376)
_Will be used_ for the Vegetation
![vegetation_asset.png](img%2Fvegetation_asset.png)