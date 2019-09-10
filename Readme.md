This can be compilled for the HoloLens, Windows, or Android
On the 23.08.19 and prior I would have to manually move DLL files from the x64 compiled output for the HoloLens solution from Unity and move them into the x86 folder for it to run, which was a bug with Unity at the time. It may not be an issue anymore.

HoloLensARProject
======
**HoloLensARProject** was made to dynamically load data into 3D space, AR, using the HoloLens and/or mobile phones/tablet devices. It does deos a POST Request to the database in at run time when you scan an obkect, and dynamically loads that data. Based on your database of images you have on Vuforia I have contructed it so that it will generate image trackers and image targets per image in your Vurforia database.

#### Video Demonstration
[![Video Demonstration](https://img.youtube.com/vi/HiRQvAdTFec/0.jpg)](https://www.youtube.com/watch?v=HiRQvAdTFec)



## Usage
```$ git clone https://github.com/salmanmkc/HoloLensARProject.git
...
```


### Third party libraries
* see [Vurforia](https://developer.vuforia.com/)

## License 
* see [LICENSE](https://github.com/username/sw-name/blob/master/LICENSE.md) file

## Version 
* Version 1.0

## How-to use this code
You need to deserialise your own data, as I've set it up to work with a Graph QL database. All you need to do is create a class to deserialise your data and then parse that data, and set it up to work with whatever fields you want.

## Contact
#### Developer/Company
* e-mail: 13schishti@gmail.com
* Twitter: [@SalmanMKC](https://twitter.com/salmanmkc "salmanmkc on twitter")
* LinkedIn article I wrote about Windows Insiders: https://www.linkedin.com/pulse/come-join-insider-program-salman-chishti/


