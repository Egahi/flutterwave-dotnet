# Contributor's Guide
First off, thanks for taking the time to contribute! 🙌🙌🎉🎉

## Prerequisite

Configure flutterwave secret key

1. [Signup](https://dashboard.flutterwave.com/signup) for a flutterwave account
2. [Login](https://dashboard.flutterwave.com/login) to your account
3. Get your secret key (test or live) under Settings > Api
4. Save your secret key
    * on your local machine as an environmental variable named <br/>`FLUTTERWAVESECRETKEY`
    * on your fork of this repo as a GitHub secret (settings > secrets) named <br/>`FLUTTERWAVESECRETKEY`

## Framework
[.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) <br />
_ps: Installing [visual studio 2022](https://visualstudio.microsoft.com/vs/preview/) comes with .NET 6 by default_

## How to contribute
1. Fork this repository
2. Clone your fork locally
3. Branch off master
4. Write your code and commit them (mutiple commits during development is preferred)
5. Push the new branch to your fork
6. Open a pull request

**ps: All classes under Apis, Models, ModelDTOs should be created in the Flutterwave.Net namespace**

## Testing
Write unit tests to verify your code does what you think it does 😉😉
