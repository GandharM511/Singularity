# Game Basic Information #

## Summary ##

Specimen 153, an intergalatic anomaly, was captured by hostile aliens to be tested on in their lab. They were subjugated to deadly experiments and tests, one of which broke their existence in two. While split apart, the specimen must now escape the aliens' lab to finally become one again - a Singularity.

Singularity is a 2D Puzzle Platformer that takes place between two seperate realms. Players must traverse these connected dimenstions to complete each trial, all in hope to become one again.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**
The goal of this game is to solve platforming puzzles in order to progress through the different levels. Switch between worlds utilizing either the Z or Left Shift keys, in order to figure out how to get to your goals. Each level gets increasingly difficult, and utilizes mechanisms such as pressure plates, switches, and combining gems to affect the other worlds. As you play with the switches and pressure plates, find out what they move, and make the fastest path to the goal. 

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

## User Interface

**Richmond Ballesteros**
The User Interface is one of the most important aspects to our project. For style, I wanted to utilize assets that very much demonstrated our game atmosphere, so I used more "space"-ey assets. From the beginning, the player is shown the **main menu** where the player is able to either start the game, view the credits page, or quit the game. During gameplay, the [HUD](https://github.com/orange-shasta/Singularity/blob/344aa61e4df5545b5f65c498504b2339cd0e880a/Solidarity/Assets/Scripts/UI/InGameUI.cs#L7) displays the current level. In addition, the player can go to the [pause menu](https://github.com/orange-shasta/Singularity/blob/404f777b6b24f1f4474b79fed0b5e7744525a865/Solidarity/Assets/Scripts/UI/PauseMenu.cs#L6), where the player can resume, see the controls, restart the level, or go back to the main menu. Finally, the intro and outro cutscenes were created in order to explain to the player the beginning and ending of our story. These cutscenes were created from UI Text elements and backgrounds.

## Movement/Physics

**Christopher Havens**
In general, Singularity uses the standard physics model, with just a few modifications. With the premise of the game being that there are two seperate characters operating in 2 different wolrds that somehow inpact the other, I had the challenge of allowing the player to switch between characters. The modification to the physics model is here, when the player is switched from we (freeze its movement)[https://github.com/orange-shasta/Singularity/blob/344aa61e4df5545b5f65c498504b2339cd0e880a/Solidarity/Assets/Scripts/Singularity/CameraController.cs#L63] and [lock it in mid air](https://github.com/orange-shasta/Singularity/blob/f2d0d9d1bf3ec897f6b02023d1f0ca2cbe80215b/Solidarity/Assets/Scripts/Mechanics/KinematicObject.cs#L105). This was done by just adding an if condition to a kinematic object, if it is frozen then don't move it! This is so that the character doesn't move at all when the camera is not focused on their world. This is the main adaptation our game needed to the physics model. A few more notes though, all platforms move with zero acceleration and a constant speed. 

The last task I had to complete to get the physics just right for our game was setting up the correct player movements speed and jumping heights. The core of our game comes down to jumping height and running speeds, levels are designed such that the player can make some jumps and cannot make other jumps so getting these values right and sticking too them was crucial. I chose the values off of what felt the best for the size of our character compared to the size of the world.

I worked very closely with a player controller as well as a camera controller that allows us to see the different worlds when we switch characters. When the player wants to switch to the other character we take away the ability to control this character. This is used by setting a [flag (control enabled)](https://github.com/orange-shasta/Singularity/blob/f2d0d9d1bf3ec897f6b02023d1f0ca2cbe80215b/Solidarity/Assets/Scripts/Singularity/CameraController.cs#L54). 

A very similar thing had to be done when the player wants to combine the two worlds into a third world. The way the scene is set up is the 3rd world is just a 3rd seperate player game object whose control is disabled until the user collects the powerups and combines the worlds!

Throughout this role I worked closely with input and writing the logic behind some of these mechanics.

## Animation and Visuals

**Geoffrey Mohn**
The animation and visuals came from a unity game [tutorial](https://learn.unity.com/project/2d-platformer-template). Originally planning to add assets from the Unity store from Mimu Studio, but implementing it with the already existing scripts and controllers became very convaluted and difficult.

The back ground was to be changed for each level to give hints but changing one back ground would change the rest all of them. Reskinning any platforms or walls would change every platform and wall.

## Input

**Gandhar Mannur**
The default input configuration utilizes two main playing styles. The first one allows for left and right movement done with the A and D keys respectively
with the E key to interact with powerups and switches, and Left Shift to switch between characters. The other style allows for the left and right arrow keys to move left and right, with the Z key to switch between characters, and the X key to interact with powerups and switches. The universal button for jumping is the Spacebar key, and jumping for longer periods makes the height greater. In order to control the UI system, the mouse pointer and click can be utilized to complete each option that the cursor is hovering over. 

[PowerUp Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/PowerUpController.cs#L36)

[Switch Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/Switch.cs#L55)

[CameraController Moving Characters Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/CameraController.cs#L36)

[Jump Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Mechanics/PlayerController.cs#L80)

## Game Logic

There are various different states the game presents to the user. On open, the user is meets a main menu, where they can start the game, view credits, or quit. When playing the game, the player naviates through different levels that all exist in their own scene. In any of these scenes, the user can open a pause menu to both restart play on the current scene, return to the main menu scene, or view other on screen information.

**Arjun Kahlon**
In my contribution I worked with my other team members to create and string our levels together. Furthermore I implemented varying gameplay mechanims into these levels, which played upon certain design patterns. One example of this can be the Publisher Subscriber Pattern seen in our platforms and switches. In this case, platforms can subscribe to either a switch or a pressure plate. These switches then publish and notify their current state to their subscribters. This implementation is very broad, and allows lots of room for new interaction in the subscribers. Another design patter present is the Singleton Audio Manager, which the game to have persistant audio. This was important because across all our scenes it should only be neccesary to instantiate one audio manager. Below are pictures of the scene to scene logic, alongside diagrams to visualize the Publisher Subscriber Patter.

![Game State Loop](/Solidarity/Assets/Images/GameStateLoop.png)
![Publisher Subscriber](/Solidarity/Assets/Images/PublisherSubscriber.png)

**Gandhar Mannur**
I worked on level generation by making the majority of the levels. In a game like this, it becomes a little bit difficult to make levels that are difficult enough that players will take a good amount of time to finish, but also not lose interes. When creating levels I prioritized a variety of level design techniques, such as trapping one player, and timed jumps after stepping off a pressure plate. I also had to consider how I can incorporate skill jumps, and how although the levels might seem simple at first, they require getting used to the mechanics of the game. We worked on 10 levels total, ranging from tutorial style levels to teach the mechanics of the game, to hard levels that require constant switching between characters, and testing what each pressure plate does. We made the levels progressively get more difficult while maintaining interest and relevance to the previous levels. A concept/strategy that you learn in a previous level most likely will be used in the next few levels.

# Sub-Roles

## Audio

**Geoffrey Mohn**
Used the Legend of Zelda sound when completing a level, looping music from the tutorial
We used Unity the unity tutorial and modified the sound samples and music to bet fit the tone.

We have an audio manager script and audio source on prefabs that play a sound based on the state of said prefab. This is linked with the animation. There is a looping song that plays throughout the levels.

Sci-fi sound style to connect with the space theme.

## Gameplay Testing

**Gandhar Mannur**
When we made our build for the playtest, we were not aware of a variety of bugs that we as developers could not expect. After playing the levels exactly how they were meant to be played we got to the point where we were oblivious to shortcomings that only new eyes could see. By testing we gained valuable insight into what we need to fix, and how the game can evolve. Firstly, it was pretty obvious to every tester that the function of the gem was not obvious. Although, we included in the instructions in the tutorial level that this combines both worlds and makes the character into one in order to aid finishing the level, it was hard to see the purpose. From this we added sound effects whenever a character reached a gem so the player knows they are to interact. On the other hand, we were very worried if players would catch on to when to switch between characters. The meta of the game is to press a switch or stand on a pressure plate and switch between characters to see the overall effect. Thankfully after review it was seen that catching on to when to switch was simple, and did not need more attention to clutter the gameplay. With this type  of game, we saw a lot of testers showing interest in making it multiplayer where each human player controls wone of the characters, making it a co-op game. Although, this takes awasy from our single-player vision, it provides more feedback on how the market thinks and what they initially see after one playthrough. The objective of the game was cleaar and the levels became difficult but were still manageable by most testers. On top of that we saw that the interest grew significantly and never plateaued. From throrough testing we found ways to improve our game, and also how well this game targetted the target market.

[Playtests](https://github.com/orange-shasta/Singularity/tree/main/Solidarity/Testing)

## Narrative Design

**Arjun Kahlon**
When presented the theme "it was the best of times, it was the worst of times", my mind was directed towards duality. In this game we tried to address this duality, with hope to reach Singularity. As highlighted in the opening cutscene, the narrative of this game revolves around Specimen 153 trying to become one again. To implement this in the gameplay, we ensured that progress requires the user to switch back and forth between these split realities. Furthermore we wanted to push to goal of singulairty by introducing the gem powerup, which combines the specimen back into one.

## Press Kit and Trailer

**Richmond Ballesteros**
I created an md file for the [press kit](https://github.com/orange-shasta/Singularity/blob/main/Presskit.md). In this press kit md file, I had sections for the game description, game trailer, game screenshots, and project members. I decided to start off with a short description of the game, what genres it is, and an overview of the story. After, I showcased the [trailer](https://www.youtube.com/watch?v=qeFG8bBCwGo). In the trailer, I showcased the intro cutscene in order to give the watchers the story and a lot of gameplay clips to give watchers a gist of how the game is played. Afterwards, I included the screenshots that best represented the game. I included the title screen, some screenshots of levels, and the pause screen, which I think gives a good general overview of what our game looks like. Finally, I included introductions of all the project members and their pictures. 

## Game Feel

**Christopher Havens**
Because I also worked on Movement and Physics a lot of my roles overlapped with each other. This was helpful because it was easy to see my role within the team. I added scripts that gave functionality to [Switches](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/Switch.cs#L10) and [Pressure Plates](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/PressurePlate.cs#L10). Both of these game objects implement a publisher in a publisher subscriber design pattern. This pub/sub is slightly modified from the one that we implemented in the Pikmini exercise. This on has two callback functions, when the circuit is turned [On](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/OnOffPublisher.cs#L34), and when it is turned [Off](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/OnOffPublisher.cs#L43). The subscribers gets to decide what happens within these callback functions. An Abstract Switchable item that just implements the proper publisher subscriber methods was used in order to abstract the difference between the two scripts, as they do very similar things but in different ways. A switch is [toggle](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/Switch.cs#L55-L74) via input. The pressure plate implements is [held](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Singularity/PressurePlate.cs#L34-L63) down while it is stood on.

The next thing I added to make the game feel more satisfying was adding sounds and movement/animations to these switches and pressure plates. For example the switch object is rotated 90 degrees to make it look like the lever was moved, and the pressure plate moves down to simulate standing on the plate. Sounds were also added to make these interactions feel better. Sounds were also added into when the power up was [collected](https://github.com/orange-shasta/Singularity/blob/e304debb4f5e66a72ee352c4ab3faecc41595bee/Solidarity/Assets/Scripts/Mechanics/TokenInstance.cs#L51-L59). With time restraints I couldn't add all of the sounds effects that I wanted like switching between the two worlds/characters and combining the worlds into 2. Most of the game feel comes from these sounds, and from the gameplay testing component of this game I saw that some people would have liked more clear indicators of switching worlds.

Some of the things that I changed for the physics model also impacted the feel of the game. For example, disabling the player model to fall when the focus is switched off of them makes the game feel a lot better, because the character does not move off while off screen.

## Extra Notes
As our game came from this Unity [Tutorial](https://learn.unity.com/project/2d-platformer-template) we need to differentiate what we did and what was provided via the tutorial. Some items from the tutorial that we do not use in our build have yet to be removed from the repo. 

All of the scenes were created for our game.

All of the scripts we created and used are in the folder Solidarity/Assets/Scripts/Singularity. These are the scripts solely developed by our team. Some of the scripts such as TokenInstance, PlayerController, KinematicObject were all modififed from their original state within the tutorial to support our game.
