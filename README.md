# Skybox to Cubemap
![GitHub](https://img.shields.io/github/license/dbqt/SkyboxToCubemap)

Simple tool to capture the environment from a camera to a cubemap texture in Unity.

![instructions for usage](./VisualInstructions.png?raw=true)

## Usage

### Capturing cubemap from the scene
1. Open your scene in Unity.
2. Place a camera where you want the environment to be captured from
3. Optionally create a new cubemap (you can use the included example cubemap instead) - whichever you use will be overwritten!
4. Make sure the cubemap has `Readable` enabled, and configure the settings as you like
5. Open the menu for `Tools > Skybox to CubeMap`
6. Assign the camera and a cubemap to overwrite
7. Click on `Capture`

### Converting a cubemap to 6 textures
1. Open the menu for `Tools > Cubemap to Textures`
2. Assign the cubemap to convert
3. Specify the path where the textures will be saved
4. Click on `Convert`

## Installation

- Download the unitypackage from the [Releases](https://github.com/dbqt/SkyboxToCubemap/releases)
- Import the unitypackage into your Unity project