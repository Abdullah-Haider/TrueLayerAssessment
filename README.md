# TrueLayer Assessment

Please find below the instructions to run this application. Please also ensure that you have put all files in this repository in a folder.

## Installation

Please insure before beginning that you have [Docker](https://www.docker.com/products/docker-desktop) installed on your PC/Mac. Insure that it is running

## Running

Please open your commad line terminal and locate to the TrueLayerAssessment Folder. 

```bash
cd YourPath
```

Once you are in the folder please run the following command to create our docker image

```bash
docker build -t assessment -f Dockerfile .
```
Check that the image is created by entering the following command

```bash
docker images
```

Run this command to create a container 

```bash
docker create assessment
```

Run the following command to check container details

```bash
docker ps -a
```

To now start the application please get the name of the container which should be under the NAMES column and run the following command

```bash
docker start -i NAME
```

## Additional Info

Please note if the program fails to run using the docker or is giving some issue, please run the program normally using visual studio code and setting the project as the start up project.

