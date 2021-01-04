@ECHO OFF
Title "NordVPN switcher by Nullcheats"
color b
echo "How long would you like to delay before changing proxy (Seconds) ?"
set /p input= "";

cls
Set Counter=0
for /L %%n in (1,0,10) do (
echo "Attempting to connect to a server ! "
cd "C:\Program Files\NordVPN\"
nordvpn --connect
color c
echo "New proxy set <3"
ping -n %input% 127.0.0.1 > nul 
color b
)