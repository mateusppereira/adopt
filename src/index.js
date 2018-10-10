import React from 'react';
import 'config/ReactotronConfig'
import createRoutes from 'routes';
import { store } from 'store';
import { Provider } from 'react-redux';
import { StyleSheet, Text, View } from 'react-native';

export default class App extends React.Component {
  render() {
    const Routes = createRoutes(false);
    return (
      <Provider store={store}>
        <Routes />
      </Provider>
    );
  }
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#eee',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
