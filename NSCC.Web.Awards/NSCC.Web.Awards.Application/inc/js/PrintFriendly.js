// Variable to hold the querystring in an array this is now available globally to all
// javascript functions
var qsParm = new Array();
function GetQueryString ()
{
	var query = window.location.search.substring(1);
	var parms = query.split('&');
	for (var i=0; i<parms.length; i++)
	{
		var pos = parms[i].indexOf('=');
		if (pos > 0)
		{
			var key = parms[i].substring(0,pos);
			var val = parms[i].substring(pos+1);
			qsParm[key] = val;
		}
	}
}

function HideDivForPrint()
{
      //Inititalize the querystring variable in case none have come in
      qsParm['print'] = false;
GetQueryString ();

	if (qsParm['print'] == "true")
	{
		var cssAdd = document.createElement('link');
		cssAdd.type = 'text/css';
		cssAdd.rel = 'stylesheet';
		cssAdd.href = '/inc/css/print.css';
		cssAdd.media = 'screen';
		cssAdd.title = 'dynamicLoadedSheet';
		document.getElementsByTagName("head")[0].appendChild(cssAdd);
	}
}