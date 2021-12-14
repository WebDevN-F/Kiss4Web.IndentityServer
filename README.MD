[![Build status](https://ci.appveyor.com/api/projects/status/p3iet9wrmg8jxlmx?svg=true)](https://ci.appveyor.com/project/ngnam/kiss4web-indentityserver)

## A sample project Idsr4 & minimal-API NET6 implementation for KISS Principle

- Nguyen Van Nam
- Email: nguyen.van.nam@outlook.com
- Phone: 0928351036

### Some things will implements

- A IdentityServer is middleware that adds the spec compliant OpenID Connect and OAuth 2.0 endpoints to an arbitrary ASP.NET Core application. [Big picture](https://identityserver4.readthedocs.io/en/release/intro/big_picture.html#how-identityserver4-can-help)
- A Client JS Authenticate with openIDClient [OpenID-passport](http://www.passportjs.org/packages/openid-client/)
- idsr4database will store in a In-memory Database [In-memory Database](https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/in-memory-databases)
- A generate repository pattern access to idsr4database
- When you don't alway must register for every new service, I can use autofac to scan and register types. [Autofac](https://autofac.readthedocs.io/en/latest/register/scanning.html)
- Which one to use Lifestyle [AddTransient - (lightweight, no-state), addScoped - state, addSingleton-reused everywhere](https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences)
- Register DI use [SimpleInjection](https://docs.simpleinjector.org/en/latest/quickstart.html)
- Injecting service with different lifetimes into another
	
	+ Never inject Scoped & Transient services into Singleton service. (This effectively converts the transient or scoped service into the singleton.)
	+ Never inject Transient services into scoped service (This converts the transient service into the scoped.)

- [The global.json file allows you to define which .NET SDK version is used when you run .NET CLI commands](https://docs.microsoft.com/en-us/dotnet/core/tools/global-json?tabs=netcore3x)

### Conclusion
Create A WebAPI helps to your applications Sign Sign On, Authentication with a OpenID service side or a OAuth 2.0 for providers local account và externals other.

### Thanks

If you find this project useful — or just feeling generous, consider buying me a beer or a coffee. Cheers! :beers: :coffee:
|               |               |
| ------------- |:-------------:|
| <a href="https://www.paypal.me/ngnam39"><img src="https://github.com/ngnam/Resources/blob/master/donate_paypal.svg" height="40"></a> | [![BMC](https://github.com/ngnam/Resources/blob/master/donate_coffee.png)](https://www.buymeacoffee.com/ngnam) |