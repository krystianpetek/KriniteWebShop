$containers = @{
    "webshop-productcatalog-mongo"   = "docker start webshop-productcatalog-mongo";
    "webshop-productcart-redis"      = "docker start webshop-productcart-redis";
    "webshop-productcoupon-postgres" = "docker start webshop-productcoupon-postgres";
    "webshop-productorder-sql"       = "docker start webshop-productorder-sql";
    "webshop-rabbitmq"               = "docker start webshop-rabbitmq";
}

# foreach ($container in $containers.GetEnumerator()) {
#     if ((docker inspect -f '{{.State.Status}}' $container.Key) -ne 'running') {
#         Invoke-Expression -Command $container.Value
#     }
# }

$containersArray = @(
    "webshop-productcatalog-mongo",
    "webshop-productcart-redis",
    "webshop-productcoupon-postgres",
    "webshop-productcoupon-postgres",
    "webshop-rabbitmq"
)

foreach ($container in $containers.GetEnumerator()) {
    if ((docker inspect -f '{{.State.Status}}' $container.Key) -ne 'running') {
        Invoke-Expression -Command "docker start $($container.Value)"
    }
    else {
        Invoke-Expression -Command "docker stop $($container.Value)"
    }
}