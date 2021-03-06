import Reactotron from 'reactotron-react-native';
import { reactotronRedux } from 'reactotron-redux';
import sagaPlugin from 'reactotron-redux-saga';

const tron = Reactotron
  .configure()
  .useReactNative()
  .use(reactotronRedux())
  .use(sagaPlugin())
  .connect();
tron.clear();
console.tron = tron;
