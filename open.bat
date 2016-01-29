@echo off
set base=C:\Users\sergio.rodrigues\source\minhasresolucoes.github.io
set arg1=%1
set year=%arg1:~0,4%
set month=%arg1:~4,2%
set day=%arg1:~6,2%

notepad %base%\%year%\%month%\%arg1%.html

