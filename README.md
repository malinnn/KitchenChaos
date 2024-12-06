# Kitchen Chaos

## What is this project about?
This project is a small game developed in Unity, starting with a relatively simple idea that was later modified to meet specific requirements.

## What is the game about, and what is its objective?
The game is a straightforward cooking game. Every few seconds, new orders (recipes) are generated, and players must complete them within a set time. Within the project, the recipe generation rate and the gameplay duration can be adjusted using Unity's `[SerializeField]` attribute, even though these values are private. When the time runs out, the game ends, but players can start a new session, resetting the progress to zero.

## Technical Details

### Menus and User Interfaces
The first screen players encounter is the **Main Menu**, which is simple and includes two buttons: 
- **Play** to start the game 
- **Quit** to close the application.

<p align="center"><img width="652" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/e46488d9-8cc6-4182-ae97-123c48d96ec9"></p>

After pressing **Play**, the game starts. The UI is intuitive, displaying active orders, a countdown timer, and a circular progress indicator.

<p align="center"><img width="651" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/b1b7f546-986e-43bb-8622-3f8f7c18a0db"></p>

The **Pause Menu** can be accessed by pressing the `ESC` key. It features three options:
- **Resume** to continue the game
- **Options** to configure settings
- **Main Menu** to return to the start screen.

<p align="center"><img width="654" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/44f0d8b5-feed-4d64-83e7-90ce3327537c"></p>

The **Options Menu** allows players to adjust audio volumes (music and sound effects) and key bindings. A **Cancel** button closes the settings menu.

<p align="center"><img width="649" alt="image" style="width:65%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/817f9967-db3a-472d-bc8c-7d3e56d8d93e"></p>

### Displaying 3D Objects
Unity's built-in **Unity Engine** powers this project. It supports rendering both 2D and 3D objects using its **Rendering Pipeline**. Features utilized include:
- Scenes
- 3D Objects
- Transform Components
- Materials and Shaders
- Camera Settings

### Advanced Transformations
The project implements the following transformations: **translation**, **rotation**, **scaling**, **deformation**, and **mirroring**.  
- **Translation** is evident in the player's movement system and in the items they hold (e.g., food or plates), which move in sync with the player.  
- **Rotation** can be achieved by holding movement keys or by instantly rotating the player 90° with the `;` key, using the `transform.Rotate()` method.  
<p align="center"><img width="270" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/951a6e45-4b27-4f6a-88a9-093601b6e972"></p>

- **Scaling** adds fun to the game: pressing `,` or `.` scales the player up or down using the `transform.localScale` property.  
<p align="center"><img width="287" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/7058396c-b3bd-44aa-ae5f-68ed06b0546c"></p>

- **Deformation** allows the player to "widen" or "shrink" along the X-axis using `[` and `]`.  
<p align="center"><img width="372" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/f1bd969c-7f71-4a1e-962d-9132050ebc4f"></p>

- **Mirroring** creates a mirror effect using a plane, custom texture, and an additional camera.

### Shader Programming
Shaders enhance the game's aesthetics through Unity's **Global Volume** settings, allowing for customized visual effects.
<p align="center">
<img width="222" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/6cf701fb-1a31-436b-ad3a-58290199fc11">
<img width="223" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/640fe557-678f-49c8-b419-319f69fd1098">
</p>

### Lighting
Lighting is managed using the **Directional Light** object, which determines how light interacts with the scene.
<p align="center"><img width="232" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/8e0ed1b4-09ca-4ad9-8aec-9f6133288b7f"></p>

### Cameras and View
The game uses a camera positioned above the player for a top-down view.
<p align="center"><img width="652" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/c84f8979-acae-4b34-a057-d64ff6e5bb96"></p>

### Interaction
Interactions occur primarily through keyboard input, except in menus where the left mouse button is used. Key bindings are displayed at the start of the game.
<p align="center"><img width="650" alt="image" style="width:60%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/30d238b7-4518-4b51-bd03-a7d534ca06f1"></p>

### Sound
For music, a **MusicManager** object controls playback and volume adjustment.
<p align="center">
<img width="233" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/66664289-eca8-4391-8601-2d3ea7693939">
<img width="368" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/59889f81-5a6d-427f-a017-2b26440fb402">
</p>

Sound effects (SFX) are managed by a **SoundManager** using event triggers activated during specific interactions.
<p align="center">
<img width="234" alt="image" src="https://github.com/malinnn/KitchenChaos/assets/116735318/040ba15a-e154-45a9-9bc0-02cda0aeaf23">
<img width="400" alt="image" style="width:50%" src="https://github.com/malinnn/KitchenChaos/assets/116735318/5a5c7a06-bd46-4949-a650-fd900f7a4eab">
</p>
