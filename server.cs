// onDay and onNight triggers - Because BadSPOT forGOT

// +-------------------------+
// |-|\-----/|---------|\/|--|
// |-| \___/ |---------|  |--|
// |-| o   o |---------|  |--|
// |-|   ^   |---------|  |--|
// |-|   V   |________/  /---|
// |-\_______/    \       \--|
// |-----| |.      |      |--|
// |-----|________/_______/--|
// |-----|/ \/------|/--|/---|
// |-----U---U------U---U----|
// +-------------------------+

//Made by Lugnut (16807)
// ------ Credits ------
//- Ipquarx // Theory
//- Mold // Asking weird questions
//- Treynolds // Participated in topic.

//Math help by: (Offset compatibility wouldn't be possible without him. Also, this would run like crap too.) - LOL THIS IS FUNNY BECAUSE IT DID RUN LIKE CRAP BUT THAT WAS MY IDEA
//- Nullable

//Future Predictor by:
//- Zack0Wack0

//Event function source stolen without permission from: (it's ok becuz i told him i was gunna do it k?)
//- Mold

//Misc. help + Love + constant bothering + avatar dealer by:
//- Electrk

//Funny fact: I have no idea what goddamned version I'm on. // Next version number will be generated randomly

$DayCycles::Dev = false; //Enables developer modules
$DayCycles::Version = 17; //This allows version checking

 //Execute everything
 
exec("./events.cs"); //this is what registers the events
exec("./callMeMaybe.cs"); //these are the callbacks
exec("./timeSupport.cs"); //this is the file that calculates what time of day it is
exec("./tickSupport.cs"); //this is the file that makes sure we always have the latest time, and that the callbacks get called.
exec("./listSupport.cs"); //this keeps a list of what bricks the callbacks should call the events on
exec("./package.cs"); //this makes sure to start/stop the tick at the right time.
exec("./versionSupport.cs"); //this will check a file hosted on dropbox for version info 

function DayCyclesDebug(%str) //this function will log data to a debug file.
{
	if(!isObject(DayCyclesDebugFO))
	{
		new fileObject("DayCyclesDebugFO");
		DayCyclesDebugFO.openForWrite("config/server/Event_DayCycles/debug.log");
	}
	DayCyclesDebugFO.writeLine(%str);
	if($DayCycles::Dev)
	{
		talk("DEBUG: " @ %str);
	}
}

function serverCmdReloadDayCycles(%client) //reloads the system for testing
{
	if($DayCycles::Dev)
	{
		setModPaths(getModPaths());
		exec("./server.cs");
	}
}

// testing git again