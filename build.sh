#Author: Ethan Kamus
#Email: ethajpkamus@csu.fullerton.edu

#Purpose: to emulate a stoplight
echo First remove old binary files
rm *.dll
rm *.exe

echo Compile stoplightuserinterface.cs to create the file: stoplightuserinterface.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:stoplightuserinterface.dll stoplightuserinterface.cs

echo Compile stoplightmain.cs and link the two previously created dll files to create an executable file.
mcs -r:System -r:System.Windows.Forms -r:stoplightuserinterface.dll -out:StopLightProject.exe stoplightmain.cs

echo Run the Assignment 1 program.
./StopLightProject.exe

echo The script has terminated.
