# HƯỚNG DẪN CÁCH CHẠY

Bước 1: Start all of the containers

`docker-compose up -d`

Bước 2: Initialize the replica sets (config servers and shards)



    docker-compose exec configsvr01 sh -c "mongosh < /scripts/init-configserver.js"
    
    docker-compose exec shard01-a sh -c "mongosh < /scripts/init-shard01.js"
    docker-compose exec shard02-a sh -c "mongosh < /scripts/init-shard02.js"
    docker-compose exec shard03-a sh -c "mongosh < /scripts/init-shard03.js"

Bước 3: Initializing the router

`docker-compose exec router01 sh -c "mongosh < /scripts/init-router.js"`

Bước 4: Enable sharding and setup sharding-key (Sample)



    docker-compose exec router01 mongosh --port 27017
    
    // Enable sharding for database `MyDatabase`
    sh.enableSharding("MyDatabase")
    
    // Setup shardingKey for collection `actors`**
    db.adminCommand( { shardCollection: "MyDatabase.actors", key: { _id : 1 } } )

Connect: Connect to cluster with mongodb compass
`mongodb://127.0.0.1:27117,127.0.0.1:27118/`
    

