// onDay and onNight triggers - Because BadSPOT forGOT

//Made by Lugnut (16807)
// ------ Credits ------
//- Ipquarx // Theory
//- Mold // Asking weird questions
//- Treynolds // Participated in topic.

//Math help by: (Offset compatibility wouldn't be possible without him. Also, this would run like crap too.)
//- Nullable

//Event function source stolen without permission from: (it's ok becuz i told him i was gunna do it k?)
//- Mold

//Misc. help + Love + constant bothering + avatar dealer by:
//- Electrk

//Funny fact: I have no idea what goddamned version I'm on. // Next version number will be generated randomly

$DayCycles::Debug = false; //This allows recording of critical events.
$DayCycles::Dev = false; //Enables developer modules
$DayCycles::Version = 11; //This allows version checking

 //Execute everything
 
exec("./events.cs"); //this is what registers the events
exec("./callMeMaybe.cs"); //these are the callbacks
exec("./timeSupport.cs"); //this is the file that calculates what time of day it is
exec("./tickSupport.cs"); //this is the file that makes sure we always have the latest time, and that the callbacks get called.
exec("./listSupport.cs"); //this keeps a list of what bricks the callbacks should call the events on
exec("./package.cs"); //this makes sure to start/stop the tick at the right time.
exec("./versionSupport.cs"); //this will check a file hosted on dropbox for version info 

function DayCyclesDebug(%str) //this function can be called wherever and it'll spew out debug info if debug is enabled. very useful.
{
	if($DayCycles::Debug) //checks if debug is enabled
		echo("DayCyclesDbg >" SPC %str); //echoes a line
}

function serverCmdReloadDayCycles(%client) //reloads the system for testing
{
	if($DayCycles::Dev)
	{
		setModPaths(getModPaths());
		exec("./server.cs");
	}
}