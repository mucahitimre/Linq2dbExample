# Linq2dbExample

CliclkHouse db startup and crud operations with Linq2db.

## Requirements

- Docker: [Visit Docker website for installation](https://www.docker.com/)

## Installation

1. Pull mongo latest version:
```bash
docker pull clickhouse/clickhouse-server
```

2. Run mongo:
```bash
docker run -d -p 18123:8123 -p19000:9000 --name some-clickhouse-server --ulimit nofile=262144:262144 clickhouse/clickhouse-server
```
## Optional

If there is clickhouse with the same name:
```bash
docker start some-clickhouse-server
```

## References
- https://github.com/linq2db/linq2db

## More

Still have questions left? Check out its issues or create new issue
