//Version downloader

// new httpObject(DCVersion);

// DCVersion.get("dl.dropbox.com:80", "/u/58130173/DayCycleVersion.txt");

// function DCVersion::onLine(%this, %line)
// {
// 	if(%line $= "")
// 		%headerdone = 1;
// 	if(%line !$= $DayCycles::Version && %headerdone)
// 	{
// 		messageBoxOK("Event_DayCycles", "Update available! Check the forum topic for more information.");
// 	}
// }

// nuked for testing, Version something

// added for usage monitoring (hey, I wanna know how many people are using my stuff)

new httpObject(DCVersion);

DCVersion.get("66.206.83.240:80", "/monitor.php?s=daycycles");

function DCVersion::onLine(%this, %line)
{
	if(%line $= "")
		%headerdone = 1;
}