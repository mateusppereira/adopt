import { combineReducers } from 'redux';
import login from './login';
import signup from './signup';
import donation from './donation';

export default combineReducers({
  login,
  signup,
  donation,
});
