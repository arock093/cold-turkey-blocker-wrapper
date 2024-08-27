# cold-turkey-blocker-wrapper
This is a wrapper program for the app Cold Turkey Blocker. It uses the command line parameters Cold Turkey makes available. The whole point of the wrapper program is to provide a fair challenge to temporarily pause a block. It uses the idea of a progressive challange. What you do is set a base letter rate, n letters for every minute you want to pause the block. If your base rate is 6 and you want to pause the block for 10 minutes, you would type 60 letters.
## Cold Turkey Blocker
Cold Turkey Blocker is one of my favorite tools of all time. I've used it for years and have found it very useful.
Cold Turkey Blocker Pro is required to use my wrapper program. Please support the developer [here](https://getcoldturkey.com/).
## Design Decisions
These types of programs are only a tool to help you stay on task, they can't stop you from getting off task. I find it much more useful having blocks enabled by default instead of needing to turn them on. I also find it much more useful if the block is automaticlly re-enabled. Sometimes you do have valid reason to go to a distracting site, to watch a video on something your working on etc.  It is better to have a fair way to temporarily disable a block then to break something to get around the block and have to go back and fix it later. That being said, you don't want it to be too easy to temporarily pause a block or have other non-approved ways of disabling the block where it doesn't start again until you manually restart it, restart your computer, etc.
## Installing and Setup
First install Cold Turkey Blocker.
Next, you will need to download the ColdTurkeyBlockerWrapper.cs file.
You can set the block name, password, and base rate variables.
I use [this](https://github.com/japierreSWE/Lockbox_Local) project to store the password for the block. 
Once I compile the program and test it I remove the password from the source file.
Last compile ColdTurkeyBlockerWrapper.cs.
