# Tachyon - DotNet Core App Using Redis & SignalR

It is simple distributed producer/consumer “n-scale” cloud app using Redis and SignalR - ported on .Net Core and ASP.Net Core. It can run cross-platform either as a portable or self-contained app. 

#Objective

Schedule N-number of producers and M-number of consumers (with variable processing time) independently. Monitor current work items in a queue with a goal of how quickly (time) & efficiently (compute/$) system can reach equilibrium.

![alt tag](https://github.com/uday31in/Tachyon/blob/master/Tachyon.jpg)

# Docker Compose

**************************************************
Building Docker Image
**************************************************
docker-compose -f win-tachyon.yml -p tachyon build --force-rm
**************************************************

**************************************************
Deploying Docker Service
**************************************************
docker-compose -f win-tachyon.yml -p tachyon up -d
**************************************************

Creating tachyon_redis_1
Creating tachyon_producer_1
Creating tachyon_watcher_1
Creating tachyon_consumer_1

**************************************************
List Docker Containers
**************************************************
docker-compose -f win-tachyon.yml -p tachyon ps
**************************************************

       Name                     Command               State           Ports
------------------------------------------------------------------------------------
tachyon_consumer_1   /win10-x64/Consumer/Consum ...   Up
tachyon_producer_1   /win10-x64/Producer/Produc ...   Up
tachyon_redis_1      cmd /S /C redis-server.exe ...   Up      0.0.0.0:6379->6379/tcp
tachyon_watcher_1    /win10-x64/Watcher/Watcher.exe   Up

**************************************************
Scale Up Docker Container - Producer
**************************************************
docker-compose -f win-tachyon.yml -p tachyon scale producer=5
**************************************************

Creating and starting tachyon_producer_2 ... done
Creating and starting tachyon_producer_3 ... done
Creating and starting tachyon_producer_4 ... done
Creating and starting tachyon_producer_5 ... done

**************************************************
Scale Up Docker Container - Consumer
**************************************************
docker-compose -f win-tachyon.yml -p tachyon scale consumer=5
**************************************************

Creating and starting tachyon_consumer_2 ... done
Creating and starting tachyon_consumer_3 ... done
Creating and starting tachyon_consumer_4 ... done
Creating and starting tachyon_consumer_5 ... done

**************************************************
Scale Down Docker Container - Producer
**************************************************
docker-compose -f win-tachyon.yml -p tachyon scale producer=1
**************************************************

Stopping and removing tachyon_producer_2 ... done
Stopping and removing tachyon_producer_3 ... done
Stopping and removing tachyon_producer_4 ... done
Stopping and removing tachyon_producer_5 ... done

**************************************************
Scale Down Docker Container - Consumer
**************************************************
docker-compose -f win-tachyon.yml -p tachyon scale consumer=1
**************************************************

Stopping and removing tachyon_consumer_2 ... done
Stopping and removing tachyon_consumer_3 ... done
Stopping and removing tachyon_consumer_4 ... done
Stopping and removing tachyon_consumer_5 ... done

**************************************************
     Removing Service
**************************************************
docker-compose -f win-tachyon.yml -p tachyon stop
**************************************************

Stopping tachyon_consumer_1 ... done
Stopping tachyon_watcher_1 ... done
Stopping tachyon_producer_1 ... done
Stopping tachyon_redis_1 ... done
PS C:\Tachyon\Tachyon\build\Tachyon>
