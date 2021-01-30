## Tutorial 2 - Options Menu

This tutorial continues on from the previous one and will assume you have read it, but can still be used as its own.

Within the canvas game object, add a new empty game object. Call this object "optionsMenu". Create a new C# script, call it "optionsMenuScript" and add it to the optionsMenu object. Within this script we will add the required functionality for a settings menu.

Before adding anything to the script, first create a slider, which can be found under UI, and add it under the optionsMenu. This will be used to control the audio volume. You may also wish to disable any other UI elements for the time being so as not to clutter the screen.

To control the audio we will first need to be able to reference the volume from the audio mixer. To do this click on "window" at the top of the screen and under UI select "Audio manager". In the widow that opens there will be a plus icon which can be clicked to create a new audio mixer, name it "mainMixer". Then select the mixer's audio and right click on volume, choose "Expose to script". If you now click on where it says "Exposed Parameters" you should see "MyExposedParam". Right click and rename to "volume".

Now open optionsMenuScript. First, void Update will not be used for this script and can be safely deleted to keep things tidy. Next the script will need to be able to use access things related to audio, to do this add the line "using UnityEngine.Audio;" to the top of the script, above where it says public class. Now create a new public variable of the type "AudioMixer" name it"audioMixer". Save the script and then select optionsMenu. Drag and drop mainMixer into the Audio Mixer slot that will now be open on optionsMenu. The audio mixer is now hooked up to the script.

Next we need to use the script to connect the audio mixer with the slider. Create a new method and call it "public void SetVolume (float volume)". Within it add the line "audioMixer.SetFloat("volume", volume);". This line takes the volume parameter from the audio mixer and sets it to the value input by the method. The code should look as below
```
public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
```
Finally this method must be hooked up to the slider. To do this, select the slide and add an event to "On Value Changed (Single)". Drag optionsMenu into the "None (Object)" slot. Then under the "No fuction" dropdown choose "SetVolume" under optionsMenuScript, Dynamic float. Finally set the slider's Min Value to -80 and Max Value to 0, as these are the corresponding values used by the audio mixer.

Next we will add a full screen toggle. Create a new method, name it "public void SetFullscreen (bool isFullscreen)". Within it add the line "Screen.fullScreen = isFullscreen;". This toggles fullscreen. The code should look as below.
```
public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
```
Under UI, add a toggle to optionsMenu. Add an event to On Value Changed (Boolean), use optionsMenu as the object and SetFullscreen as the method. this checkbox will now toggle fullscreen.

Next add a dropdown to optionsMenu, this will contain the quality settings. Inside the script create a new method with the following code.
```
public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
```
This will set the quality settings level to the value of "qualityIndex", which will be the value entered in the dropdown once it is connected. As previously, select the dropdown, add a new event, add optionsMenu as the object, and then select SetQuality as the function. Add as many options to the dropdown as there are quality settings,

To connect this menu with the main menu, create a new button and lable it "back". Add two events to the button. For the first, use the main menu's game object and for the function have it set the object to be enabled. For the second event, do almost the same thing, but intead use the optionsMenu object and set it to disabled. This will cause the options menu to vanish and main menu to appear upon clicking the button. You can do this in reverse with the options button on the main menu.
