var NsccTopNavControl = NsccTopNavControl || {};
NsccTopNavControl = (function ($, document)
{
    "use strict";
    var setNav = function (elems)
    {
    	for(var i = 0; i < elems.length; i++)
    	{    		
    		if(elems[i].selector != "") { $(elems[i].selector).addClass(elems[i].styleClass); }
    	}
    };    

    var pub = { setNav: setNav };

    return pub;
}(jQuery, document));
