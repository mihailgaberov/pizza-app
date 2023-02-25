# Love Pizza

>_I have written a tutorial about how I did this. You can find it [here](https://www.mihailgaberov.com/how-to-build-a-spa-with-vue.js-and-c-using-.net-core)
or [here](https://www.freecodecamp.org/news/how-to-build-an-spa-with-vuejs-and-c-using-net-core/)_

### SPA with Vue.js and C# using .NET Core
A web app where users can signup/login, and just tell us how much they love pizzas by pressing an "I love it" button.
There are no restrictions on the number of times each user can tell us their appreciation, the only requirement is that only logged in users can vote.
In the home page, along with the signup/login buttons, we can put a little bar-chart displaying the top 10 users with the highest appreciation (in the X-axis) and in the Y-axis the number of votes.


### Screenshots
![screenshot](https://github.com/mihailgaberov/pizza-app/blob/master/screenshots/login.png)
![screenshot](https://github.com/mihailgaberov/pizza-app/blob/master/screenshots/dashboard.png)

### Test users

mihail.gaberov@abv.bg:test123JLL

bionicman@abv.bg:test123JLL

...or register a new one via SIGN UP option on the login screen.

### Stargazers
[![Stargazers repo roster for @mihailgaberov/pizza-app](https://reporoster.com/stars/mihailgaberov/pizza-app)](https://github.com/mihailgaberov/pizza-app/stargazers)
### Forkers
[![Forkers repo roster for @mihailgaberov/pizza-app](https://reporoster.com/forks/mihailgaberov/pizza-app)](https://github.com/mihailgaberov/pizza-app/network/members)


### Frontend

#### Project setup
From root project directory:
```
cd /frontend && npm install
```

#### Compiles and hot-reloads for development
From root project directory:
```
cd /frontend && npm run serve
```

#### Compiles and minifies for production
From root project directory:
```
cd /frontend && npm run build
```

#### Run your unit tests
From root project directory:
```
cd /frontend && npm run test:unit
```

#### Run your end-to-end tests
First start the server from `/backend` folder:
```
dotnet run
```
Then from `/frontend` folder:
```
npm run test:e2e
```

### Backend
#### To run the server app:
```
cd /backend && dotnet run
```

#### To run the back-end tests:
```
cd /backend/tests && dotnet test
```

###### Note:
The frontend URL is: https://localhost:5001/, not https://localhost:8080/.

## Star History

[![Star History Chart](https://api.star-history.com/svg?repos=mihailgaberov/pizza-app&type=Date)](https://star-history.com/#mihailgaberov/pizza-app&Date)

