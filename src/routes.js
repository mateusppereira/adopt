import React from 'react';
import { createStackNavigator, createBottomTabNavigator } from 'react-navigation';
// pages
import Login from 'pages/login';
import Signup from 'pages/signup';
import Main from 'pages/main';
import Chat from 'pages/chat';
import Profile from 'pages/profile';
import Search from 'pages/search';
import Add from 'pages/add';
import Donation from 'pages/donation';

const MainTab = createBottomTabNavigator({
  Main: Main,
  Profile: Profile,
});

const createRoutes = (isLogged = false) => createStackNavigator({
  Login: { screen: Login },
  Signup: { screen: Signup },
  Search: { screen: Search },
  Add: { screen: Add },
  Chat: { screen: Chat },
  Donation: { screen: Donation },
  Main: { screen: MainTab },
}, {
  // initialRouteName: 'Main',
  initialRouteName: !isLogged ? 'Login' : 'Main',
  headerMode: 'none',
});

export default createRoutes;

