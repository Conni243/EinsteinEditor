# EinsteinEditor
An artful way to edit your bibite's brains!

To download/install:
 1. Go to https://github.com/quaris628/EinsteinEditor/releases/
 2. Select a version
 3. Download the EinsteinEditor.zip file
 4. Exract the zip file to wherever you like (open your downloads folder, right-click the file > "Extract All..." > Select a location > Extract)

To use:
 1. Run EinsteinEditor/bin/Einstein.exe
   
Note: Windows will warn you about running this file because I'm not a verified publisher. You'll just have to trust me that I didn't write anything malicious in this.
(And if it's any comfort, I do virus scans on all released files.)

If you want a shortcut on your desktop, right-click Einstein.exe in the file explorer > "Send To" > "Desktop (Create Shortcut)"

Left-click to add or drag neurons. Middle-click neurons to remove.

Right-click neurons to add synapses. Middle-click synapses to remove.

 -----

What this can do:
 - Allow you to create and edit small, weak, inefficient, and dumb bibite brains
 - Crash spectacularly, or otherwise break (consider this a disclaimer)
 - Save/Load brain to/from a bibite file
 - Show/Hide input and output neurons in the editing area
 - Create/Delete hidden neurons
 - View types and descriptions of neurons
 - Create/Delete synapses
 - Edit/View synapse strengths
 - Drag neurons around the brain editor area
 - Gracefully handle window resizing (up to 2048x1080)
 - Handle crashes with a prompt to report them and by logging info to a file

What this can't do (and probably never will):
 - Edit bibite genes
 - Edit world files
 - Make you a milkshake

What this sucks at doing (known bugs):
 - Counterproductive at helping you get a life
 - When loading from a file, synapses point to upper left corner
 - Resizing to a smaller window size can hide neurons
 - Bug reports don't show very much information (mainly missing the stack trace)
 - Brain values and last input/output is reset for neurons when saving brain

What this will do (planned enhancements):
 - When neurons are added, have their spawn location staggered (would probably also fix the synapses always pointing to the upper left when loading from a file)
 - A button to auto-arrange neurons in a prettier and more clean arrangement

What this might do (future ideas):
 - Sentience (?)
 - Have the default folder location persist between sessions
 - Somehow handle neurons with duplicate descriptions (assign new ones?)
 - Create a blank bibite
 - Allow bibite version to be configured (or auto-adjust?) (Not currently a strong need for this)
 - Keyboard shortcuts
 - Edit neuron descriptions
 - Edit neuron type
 - Allow showing multiple icons for input neurons (especially for the Constant)
 - (Credit to Wazzah) Create color groups for neurons !!!
    - Hide/Show certain color groups, or just make transparent
	- Drag and drop whole color groups
	- Delete a whole color group
 - Get some sort of visual indicator of the flow of any arbitrary input combination? Or allow testing certain input values?
 - Show an explanation of what the input and output neurons do, and the range of values for input neurons
 - Zoom in/out
 - (Credit to Lucifer) Make positions of neurons persist between saving/loading by saving position data in Inov or Index or another unused property
 - Look pretty

 -----

To any potential contributors:
 - I want to talk with you about what you want to work on! (If it hasn't been too long since I wrote this, anyway.) In order of my preference, Discord: quaris#9905 Reddit: u/quaris628 Email: quaris314@gmail.com Carrier pigeon: Polly usually flies the fastest, but Gary is also pretty good.
 - I've been using Visual Studio 2019 for an IDE. Just FYI so that if you're running into problems with another IDE, you can always try switching to VS 2019 as a workaround.
 - This project uses the phi graphics "library"/framework/whatever thing, which is a separate project I partnered in creating a few years ago. It has its own repository (https://github.com/quaris628/PhiGraphicsEngine), so if you spot any issues with or want to contribute to any of the code in the 'phi' folder, consider also going to that repo to write up an issue or pull request (or whatever). If you don't, I'll still try to keep the two in sync myself. [Edit: Given how many small fixes and enhancements I've been making, I'm just giving up on keeping the other repo in sync. I'll do a larger sync sometime around when I do a full release of the Einstein Editor.]
