@ECHO OFF
color a
ECHO [ Attempting to switch to Dir ]
cd "C:\Program Files\NordVPN\"
color b
nordvpn --disconnect 
ECHO [ VPN is is disconnecting <3 ]
PAUSE