# scaling-lamp

# About This Project
## Structure
| Project Name | Layer | Description |
| ------------ | ----- | ----------- |
| ScalingLamp | Application layer | Contains the API controllers, presentation, DTOs, and configurations |
| ScalingLamp.Domain | Domain layer | Contains the business logic services, interfaces, domain models, and DAOs |
| ScalingLamp.Infrastructure | Infrastructure layer | Contains the repository implementations and DB context |
| ScalingLamp.UnitTest | Unit test | Contains the unit test |

## Getting Started
To run the project:
``` bash
cd scaling-lamp\ScalingLamp
dotnet run
```

To run the test
``` bash
cd scaling-lamp\ScalingLamp.UnitTest
dotnet test
```

# Deployment
The project is deployed to both:
- [Azure Web App](https://scaling-lamp-1.azurewebsites.net)
- [Azure Container Instances](http://20.6.4.170/)
  - The image is hosted at [DockerHub](https://hub.docker.com/repository/docker/weisong0908/scaling-lamp)
