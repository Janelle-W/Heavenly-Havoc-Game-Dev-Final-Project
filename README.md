# Heavenly Havoc

This repository contains **Heavenly Havoc**, a fully developed action-adventure game created as a final project for a Game Development course.

---

## Description
**Heavenly Havoc** is a 2D action-adventure game where players embody Greek goddesses, each featured in her own mythologically themed level with distinct art, music, and gameplay.  
The game blends platforming, timing, and environmental challenges in a fast-paced loop designed around reflex, rhythm, and precision.

Players progress through three completed levels — **Nike**, **Medea**, and **Gaia** — each offering a different atmosphere, challenge set, and thematic design that reflects the goddess’s personality and domain.  
The game features full scene transitions, sound design, menu navigation, and a cohesive visual and musical experience from start to finish.

---

## Table of Contents
- Overview  
- Core Features  
- Gameplay and Controls  
- Technical Details  
- Running the Project in Unity  
- Project Structure  
- Troubleshooting  
- Credits  
- License  
- Contact  

---

## Overview
**Heavenly Havoc** demonstrates full gameplay systems, integrated audio, and scene management across three distinct levels.  
Developed in **Unity** using **C#**, **ShaderLab**, and **HLSL**, the game showcases character progression, UI interaction, and polished environmental design within a mythological framework.

Each level has its own background track, obstacles, and victory conditions. Completing one goddess’s trial transitions the player seamlessly into the next, creating a divine relay of skill and challenge.

---

## Core Features
- **Three fully developed levels**:
  - **Nike** – A test of agility and speed. Players race through a timed track, leaping over hurdles with precise timing as upbeat background music drives the pace.  
  - **Medea** – A level centered on strategy and control. Players navigate shifting terrain and magical hazards that test quick thinking.  
  - **Gaia** – A balance of movement and endurance. Players overcome environmental obstacles tied to earth and nature, with grounded visual tones and atmospheric effects.  

- **Functional main menu** with animated background and original music  
- **Options menu** with audio and resolution settings, plus navigation to the *Divinities* character selection page  
- **Character selection system (Divinities)** where unlocked characters can be revisited  
- **Smooth transitions** between intro scenes and gameplay using sliding animations  
- **Countdown mechanic** that initiates each level dynamically (“3, 2, 1… Go!”)  
- **Stopwatch system** for timing-based scoring and feedback  
- **Custom audio integration** per scene — each goddess’s world has its own soundtrack  
- **Jump sound and hit response** for interactive feedback  
- **Pause and resume system** allowing players to halt gameplay mid-level  

---

## Gameplay and Controls
The player begins as **Nike** and advances through **Medea** and **Gaia** by completing their unique challenges.  
Each goddess’s level has its own artistic palette, environmental effects, and soundtrack to reinforce her mythology.

**Controls**
- **Move:** A / D or Arrow Keys  
- **Jump:** Spacebar  
- **Pause / Menu:** Esc  

**Gameplay Loop**
1. Enter a goddess’s level through the main menu or Divinities page.  
2. React to timed and environmental challenges.  
3. Complete the scene to unlock the next goddess.  
4. Progress until all levels are completed and replayable.  

---

## Technical Details
- **Engine:** Unity  
- **Languages:** C# for game systems, ShaderLab and HLSL for graphics and effects  
- **Audio:** Scene-specific tracks and sound effects tied to player actions and transitions  
- **Platform:** PC (Windows/macOS), adaptable to other platforms  

---

## Running the Project in Unity
1. Clone the repository:
   ```bash
   git clone https://github.com/Janelle-W/Heavenly-Havoc-Game-Dev-Final-Project.git
   ```
2. Open Unity Hub and add the cloned project.  
3. Allow Unity to import assets and packages.  
4. Open the MainMenu scene from Assets/Scenes/.  
5. Press Play in the Unity Editor to begin.  

---

## Project Structure
- Assets/Scenes/ – Main menu, options menu, Divinities, and three goddess levels (Nike, Medea, Gaia)  
- Assets/Scripts/ – Gameplay, UI, and transition logic  
- Assets/Audio/ – Level-specific background music and sound effects  
- Assets/Art/ – Character sprites, environment art, and backgrounds  
- Assets/UI/ – Menus, HUD, and in-game interface  
- Assets/Shaders/ – Custom visual shaders and lighting effects  

---

## Troubleshooting
- Audio not playing: Check that the AudioSource components are enabled in each scene.  
- Shader issues: Verify the graphics API settings and shader model compatibility.  
- Missing scripts: Ensure that all script references are correctly assigned to GameObjects.  
- Scene loading errors: Confirm that all levels are listed in File → Build Settings.  
