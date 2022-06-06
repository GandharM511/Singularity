# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Richmond Ballesteros** The User Interface is one of the most important aspects to our project. For style, I wanted to utilize assets that very much demonstrated our game atmosphere, so I used more "space"-ey assets. From the beginning, the player is shown the main menu where the player is able to either start the game, view the credits page, or quit the game. During gameplay, the HUD displays the current level. In addition, the player can go to the [pause menu](https://github.com/orange-shasta/Singularity/blob/404f777b6b24f1f4474b79fed0b5e7744525a865/Solidarity/Assets/Scripts/UI/PauseMenu.cs#L6), where the player can resume, see the controls, restart the level, or go back to the main menu. Finally, the intro and outro cutscenes were created in order to explain to the player the beginning and ending of our story. These cutscenes were created from UI Text elements and backgrounds.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**Geoffrey Mohn** The animation and visuals came from a unity game tutorial. Originally planning to add assets from the Unity store from Mimu Studio, but implementing it with the already existing scripts and controllers became very convaluted and difficult.
**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**
The back ground was to be changed for each level to give hints but changing one back ground would change the rest all of them. Reskinning any platforms or walls would change every platform and wall.

## Input

**Gandhar Mannur**
The default input configuration utilizes two main playing styles. The first one allows for left and right movement done with the A and D keys respectively
with the E key to interact with powerups and switches, and Left Shift to switch between characters. The other style allows for the left and right arrow keys to move left and right, with the Z key to switch between characters, and the X key to interact with powerups and switches. The universal button for jumping is the Spacebar key, and jumping for longer periods makes the height greater. In order to control the UI system, the mouse pointer and click can be utilized to complete each option that the cursor is hovering over. 

**Add an entry for each platform or input style your project supports.**
<br>[PowerUp Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/PowerUpController.cs#L36)

[Switch Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/Switch.cs#L55)

[CameraController Moving Characters Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Singularity/CameraController.cs#L36)

[Jump Input](https://github.com/orange-shasta/Singularity/blob/8cb92397a0a0ea7eec6010613c62245078af149d/Solidarity/Assets/Scripts/Mechanics/PlayerController.cs#L80)

## Game Logic

**Gandhar Mannur**
I worked on level generation by making the majority of the levels. In a game like this, it becomes a little bit difficult to make levels that are difficult enough that players will take a good amount of time to finish, but also not lose interes. When creating levels I prioritized a variety of level design techniques, such as trapping one player, and timed jumps after stepping off a pressure plate. I also had to consider how I can incorporate skill jumps, and how although the levels might seem simple at first, they require getting used to the mechanics of the game. We worked on 10 levels total, ranging from tutorial style levels to teach the mechanics of the game, to hard levels that require constant switching between characters, and testing what each pressure plate does. We made the levels progressively get more difficult while maintaining interest and relevance to the previous levels. A concept/strategy that you learn in a previous level most likely will be used in the next few levels.
**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio
**Geoffrey Mohn**
**List your assets including their sources and licenses.**
Used the Legend of Zelda sound when completing a level
looping music from the tutorial
 We used Unity the unity tutorial and modified the sound samples and music to bet fit the tone.

**Describe the implementation of your audio system.**
We have an audio manager script and audio source on prefabs that play a sound based on the state of said prefab. This is linked with the animation. There is a looping song that plays throughout the levels.
**Document the sound style.** 
Sci-fi sound style to connect with the space theme.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

https://github.com/orange-shasta/Singularity/tree/main/Solidarity/Testing

**Summarize the key findings from your gameplay tests.**

When we made our build for the playtest, we were not aware of a variety of bugs that we as developers could not expect. After playing the levels exactly how they were meant to be played we got to the point where we were oblivious to shortcomings that only new eyes could see. By testing we gained valuable insight into what we need to fix, and how the game can evolve. Firstly, it was pretty obvious to every tester that the function of the gem was not obvious. Although, we included in the instructions in the tutorial level that this combines both worlds and makes the character into one in order to aid finishing the level, it was hard to see the purpose. From this we added sound effects whenever a character reached a gem so the player knows they are to interact. On the other hand, we were very worried if players would catch on to when to switch between characters. The meta of the game is to press a switch or stand on a pressure plate and switch between characters to see the overall effect. Thankfully after review it was seen that catching on to when to switch was simple, and did not need more attention to clutter the gameplay. With this type  of game, we saw a lot of testers showing interest in making it multiplayer where each human player controls wone of the characters, making it a co-op game. Although, this takes awasy from our single-player vision, it provides more feedback on how the market thinks and what they initially see after one playthrough. The objective of the game was cleaar and the levels became difficult but were still manageable by most testers. On top of that we saw that the interest grew significantly and never plateaued. From throrough testing we found ways to improve our game, and also how well this game targetted the target market.

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

**Richmond Ballesteros** I created an md file for the [press kit](https://github.com/orange-shasta/Singularity/blob/main/Presskit.md). In this press kit md file, I had sections for the game description, game trailer, game screenshots, and project members. I decided to start off with a short description of the game, what genres it is, and an overview of the story. After, I showcased the [trailer](https://www.youtube.com/watch?v=qeFG8bBCwGo). In the trailer, I showcased the intro cutscene in order to give the watchers the story and a lot of gameplay clips to give watchers a gist of how the game is played. Afterwards, I included the screenshots that best represented the game. I included the title screen, some screenshots of levels, and the pause screen, which I think gives a good general overview of what our game looks like. Finally, I included introductions of all the project members and their pictures. 

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
