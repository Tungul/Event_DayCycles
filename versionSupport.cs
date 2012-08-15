//Version downloader

new httpObject(DCVersion);

DCVersion.get("dl.dropbox.com:80", "/u/58130173/DayCycleVersion.txt");

function DCVersion::onLine(%this, %line)
{
	if(%line $= "")
		%headerdone = 1;
	if(%line !$= $DayCycles::Version && %headerdone)
	{
		messageBoxOK("Event_DayCycles", "Update available! Check the forum topic for more information.");
	}
}