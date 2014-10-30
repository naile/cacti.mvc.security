Cacti asp.net mvc security
=============

Security related filters, modules and atributes.

Installation
------------

    Install-Package Cacti.Mvc.Security

Filters
-------
* RequireAntiForgeryToken (global filter)
* RequireHTTPSAttribute for WebAPI
* DoNotResetAuthCookieAttribute (forms auth)

Attributes
----------
* SkipCSRFtoken (explicit skip, use together with global filter)

Modules
-------
* RemoveHTTPHeadersModule

