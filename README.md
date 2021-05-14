Cyotek Down Detector
=====================

Monitoring services such as [UptimeRobot][uptimerobot] or
[Application Insights][azure] (plus myriad others!) are useful
things, but often I miss email or slack notifications and
sometimes don't have an always-on dashboard.

Cyotek Down Detector is a simple tool that lives in your
notification area. You define a list of addresses you are
interested in and it will periodically test that the sites are
available. The tray icon will then update to show if there is a
problem.

If it detects a problem with a site, there is a grace period
during which the site is classed as unstable, but not offline.
Should the grace period elapse, then the site will be classed as
offline and an optional notification displayed. And that is
pretty much it. This is a simple tool with one job, one that it
hopefully does well.

For each site you can configure the following attributes

* Address. Well, you won't get far without one!
* Ignore SSL Errors. Useful if you have an untrusted
  certificate, but that is about it. If this flag is not set
  then certificate errors will be treated as offline
* Follow redirects. If enabled and an address redirects, it will
  be followed. Useful for parked domains, or redirects from
  naked to rooted. Not so useful for primary domains as if they
  decide to redirect you really should be notified!
* Use HEAD verb. When set, `HEAD` requests will be made instead
  of `GET`. This should reduce the burden of well behaved sites,
  but not all support it.

The following global settings can be configured

* Check interval. Lets you specify how often each site is checked
* Unstable interval. Defines the interval between a problem
  being identified and deciding the site is offline. Helps avoid
  spurious notifications if an application is restarting or
  simply having a busy moment
* Maximum redirect chain length. How many times a given address
  can redirect. I've deliberately chosen a low number because I
  can only see the need for one or two hops. This is likely a
  temporary setting as I'd prefer to continue _which_ address it
  is allowed to redirect to as this should be static
* Show sites on context menu
* Only show sites that are offline. Having all the sites on a
  menu is probably information overkill, so this lets you only
  show the problems
* Maximum items to display. If you have a lot of sites, the menu
  is going to be worthless. This option lets you cut it down to
  size
* Show notifications. Specifies if desktop notifications are
  displayed. Or you could just rely on the tray icon
* Log dates as UTC. Configure if you want dates written to the
  log file to be in UTC or local time
* Start with Windows. Self explanatory I hope

All settings and statuses are stored in `ctkddtkd.json` in the
same directory as the executable. In addition, `ctkddtkd.log`
contains a running commentary of events (you can view the tail
of the log directly from the application).

Comments
---------

Any questions, raise an issue or drop me an [email][email]

Screen shots
------------

![The addresses configuration screen][addresses]

![The settings configuration screen][settings]

![The log tail screen][logtail]

Acknowledgements
-----------------

* Log tail functionality uses Jon Skeet's
  [ReverseLineReader][reverse] class
* JSON serialisation provided courtesy of [PetaJson][petajson]
* The duration editors are supplied by the
  [TimeSpan2][timespan2] library as I didn't fancy writing my
  own
* Quick sort routine derived from user2149560's
  [QuickSort][quicksort] method

[addresses]: res/addresses.png
[settings]: res/settings.png
[logtail]: res/logtail.png

[uptimerobot]: https://uptimerobot.com/
[azure]: https://docs.microsoft.com/en-gb/azure/azure-monitor/app/monitor-web-app-availability

[email]: mailto:richard.moss@cyotek.com

[petajson]: https://github.com/toptensoftware/JsonKit
[timespan2]: https://github.com/dahall/TimeSpan2
[reverse]: https://stackoverflow.com/a/452945/148962
[quicksort]: https://stackoverflow.com/a/15325195/148962
