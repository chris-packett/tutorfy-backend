dotnet publish -c Release

cp dockerfile ./bin/release/netcoreapp2.1/publish

docker build -t tutorfy-backend-image ./bin/release/netcoreapp2.1/publish

docker tag tutorfy-backend-image registry.heroku.com/tutorfy/web

docker push registry.heroku.com/tutorfy/web

heroku container:release web -a tutorfy