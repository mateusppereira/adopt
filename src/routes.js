import React from 'react';
import { createStackNavigator } from 'react-navigation';
// pages
import Login from 'pages/login';
import Signup from 'pages/signup';
import Main from 'pages/main';

const MainTab = createBottomTabNavigator({
  Main: Main,
  Chat: Chat,
  Profile: Profile,
});

const createRoutes = (isLogged = false) => createStackNavigator({
  Login: { screen: Login },
  Signup: { screen: Signup },
  Main: { screen: TabNavigation },
}, {
  initialRouteName: !isLogged ? 'Login' : 'Main',
  headerMode: 'none',
});

export default createRoutes;

