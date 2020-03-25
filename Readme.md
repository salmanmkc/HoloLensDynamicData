This can be compilled for the HoloLens, Windows, or Android.
On the 23.08.19 and prior I would have to manually move DLL files from the x64 compiled output for the HoloLens solution from Unity and move them into the x86 folder for it to run, which was a bug with Unity at the time. It may not be an issue anymore.

HoloLensDynamicData
======
I made **HoloLensDynamicData** to dynamically load data into 3D space with AR, using the HoloLens and/or mobile phones/tablet devices. It does a POST Request to the database at run time when you scan an object, and dynamically loads that data. Based on your database of images you have on Vuforia I have constructed it so that it will generate image trackers and image targets per image in your Vurforia database.

#### Video Demonstration
[![Video Demonstration](https://img.youtube.com/vi/HiRQvAdTFec/0.jpg)](https://www.youtube.com/watch?v=HiRQvAdTFec)



## Usage
1) $ git clone https://github.com/salmanmkc/HoloLensARProject.git
2) Set up your database for Vuforia and link it to the project
3) Open the project in Unity
4) Modify any UI elements to fit your project
5) Edit the Mono cs files so that it deserialises your data from your API
6) Parse your data and modify any links to the Unity projectf



### Third party libraries
* see [Vurforia](https://developer.vuforia.com/)

## License 
* see [LICENSE](https://github.com/salmanmkc/HoloLensARProject/blob/master/LICENSE) file

## Version 
* Version 1.0

## How-to use this code
You need to deserialise your own data, as I've set it up to work with a Graph QL database. All you need to do is create a class to deserialise your data and then parse that data, and set it up to work with whatever fields you want.

## Contact
#### Developer/Company
* e-mail: 13schishti@gmail.com
* Twitter: [@SalmanMKC](https://twitter.com/salmanmkc "salmanmkc on twitter")
* LinkedIn article I wrote about Windows Insiders: https://www.linkedin.com/pulse/come-join-insider-program-salman-chishti/


