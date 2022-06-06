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

**Richmond Ballesteros** The User Interface is one of the most important aspects to our project. For style, I wanted to utilize assets that very much demonstrated our game atmosphere, so I used more "space"-ey assets. From the beginning, the player is shown the main menu where the player is able to either start the game or view the credits page. During gameplay, the HUD displays the current level. In addition, the player can go to the [pause menu](https://github.com/orange-shasta/Singularity/blob/404f777b6b24f1f4474b79fed0b5e7744525a865/Solidarity/Assets/Scripts/UI/PauseMenu.cs#L6), where the player can resume, see the controls, restart the level, or go back to the main menu. Finally, the intro and outro cutscenes were created in order to explain to the player the beginning and ending of our story. These cutscenes were created from UI Text elements and backgrounds.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**Geoffrey Mohn** The animation and visuals came from a unity game tutorial. Originally planning to add assets from the Unity store from Mimu Studio, but implementing it with the already existing scripts and controllers became very convaluted and difficult.
**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**
The back ground was to be changed for each level to give hints but changing one back ground would change the rest all of them. Reskinning any platforms or walls would change every platform and wall.

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**
**Geoffrey Mohn** We used Unity the unity tutorial and modified the sound samples and music to bet fit the tone.

**Describe the implementation of your audio system.**
We have an audio manager script and audio source on prefabs that play a sound based on the state of said prefab. This is linked with the animation. There is a looping song that plays throughout the levels.
**Document the sound style.** 
Sci-fi sound style to connect with the space theme.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
