# Remote Telepresence using AR and VR
*Combining Augmented and Virtual Reality for Remote Collaboration*.

This project was developed as part of my Master's Degree dissertation.
The sample enables real-time point clouds transmission of a 3D scene captured with a mobile device to a VR headset.

More details about the implementation and findings have also been described in this session at the [Global XR Conference 2022](https://www.youtube.com/watch?v=fLJ_pID_-cA).

Point clouds acquisition has been adapted from the project [iPad LiDAR Depth Sample](https://github.com/TakashiYoshinaga/iPad-LiDAR-Depth-Sample-for-Unity).

![Screenshot](images/remote_telepresence.jpg)

## Installation / Getting started

1. **Run WebSocket Server**
2. **Launch iPhone client**
3. **Launch VR client**

## Building the project

### Steps:
- Clone the project
- Install [Node.js](https://nodejs.org/en/) (alternatively, the WebSocket server can be hosted on a PaaS platform like [Azure App Service](https://azure.microsoft.com/en-gb/services/app-service/))
- Launch the WebSocket server:
```
cd WebSocket
npm install
node app.js
```
- Modify the endpoint URL on the *Utils/WebSocketHelper* project
- Open the Unity project *Telepresence Client* and deploy it to an iPhone Pro or Pro Max device
- Open the Unity project *Telepresence Receiver* and deploy it to a mobile VR headset (e.g. Oculus Quest 2)
- Execute the corresponding projects to visualise the VR scene and point clouds in the VR headset

## Versions Used
- [Unity for Mac Release 2021.2.7f1](https://unity3d.com/unity/whats-new/2021.2.7)
- [Unity AR Foundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.1/manual/index.html)
- [Unity XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@0.9/manual/index.html)
- Tested using Oculus Quest 2 and iPhone 12 Pro Max

## Links
- Reference project for point clouds acquisition:
  - iPad LiDAR Depth Sample for Unity: https://github.com/TakashiYoshinaga/iPad-LiDAR-Depth-Sample-for-Unity

- Assets required for building the VR client application:
  - VR Online Office Template: https://assetstore.unity.com/packages/tools/network/vr-online-office-template-182766

- Unity XR Interaction Toolkit: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.0/manual/components.html

## Licensing
Licensed under the [MIT License](./LICENSE).

## References
D. Zordan, "Combining Augmented and Virtual Reality for Remote Collaboration in the Workplace,”
Master’s Dissertation, Wrexham Glyndŵr University, Wrexham, UK, 2022.

