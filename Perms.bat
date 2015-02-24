REM Following line in original script incorrectly sets all child folder permissions
REM icacls . /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls app_code /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls app_browsers /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls app_data /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls bin /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls config /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls css /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls data /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls masterpages /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls macroscripts /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls media /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls python /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls scripts /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls umbraco /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls usercontrols /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls xslt /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls web.config /grant "IIS APPPOOL\LeoADaly.com":(OI)(CI)F
icacls web.config /grant "IIS APPPOOL\LeoADaly.com":F
REM If you have installed the Robots.txt editor package you need the following line too
icacls robots.txt /grant "IIS APPPOOL\LeoADaly.com":F